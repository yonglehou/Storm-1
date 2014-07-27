param(
	[switch]$skipBuild,
	[switch]$skipUnitTests,
	[switch]$skipNuGetPackage,
	[switch]$verbose,
	[switch]$autoExit
)

. ".\Functions.ps1"

Write-Host "Creating Storm NuGet package..."

# Platform tools
$msbuild = "C:\Windows\Microsoft.Net\Framework\v4.0.30319\MSBuild.exe"
$vstest = "C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
$nuget = "..\.nuget\NuGet.exe"
$here = Split-Path -Parent $MyInvocation.MyCommand.Definition
$root = (Get-Item $here).Parent.FullName

# Project variables
$unittestdll = "..\Storm.Test\bin\Release\Flyingpie.Storm.Test.dll"
$versionfile = "version.txt"
$releasefolder = "Release"

$apikeyfile = "apikey.txt"

CheckFile $msbuild
CheckFile $vstest
CheckFile $nuget

if ($skipBuild -ne $true) {
	Green "Building Storm..."
	& $msbuild "..\Storm.sln" /p:Configuration=Release
	CheckExitCode "Build"
	Green "Buid successful"
} else {
	Write-Host "Skipping build" -f yellow
}

if ($skipUnitTests -ne $true) {
	Green "Running unit tests..."
	& $vstest $unittestdll
	CheckExitCode "Unit tests"
	Green "Unit test run successful"
} else {
	Write-Host "Skipping unit tests" -f yellow
}

if ($skipNuGetPackage -ne $true) {
	Green "Updating NuGet..." 
	& $nuget Update -self
	CheckExitCode "NuGet Update"
	
	if (Test-Path $versionfile) {
		$version = Get-Content $versionfile
	} else {
		Write-Host "No version file found, using 1.0.0" -f yellow
		$version = "1.0.0"
	}
	
	& $nuget Pack "Storm.nuspec" -OutputDirectory $releasefolder -Version $version -BasePath $root
	& $nuget Pack "Storm.Dapper.nuspec" -OutputDirectory $releasefolder -Version $version -BasePath $root
	& $nuget Pack "Storm.T4.nuspec" -OutputDirectory $releasefolder -Version $version -BasePath $root
	& $nuget Pack "Storm.Cli.nuspec" -OutputDirectory $releasefolder -Version $version -BasePath $root
	CheckExitCode "NuGet Pack"
	
	if (Test-Path $apikeyfile) {
		$doPublish = Read-Host "Publish to NuGet.org? (y/N)"
		
		if ($doPublish -eq "y")
		{
			$apiKey = Get-Content $apikeyfile
			& $nuget SetApiKey $apiKey
			
			& $nuget Push "$releasefolder\Storm.$version.nupkg"
			& $nuget Push "$releasefolder\Storm.Dapper.$version.nupkg"
			& $nuget Push "$releasefolder\Storm.T4.$version.nupkg"
			& $nuget Push "$releasefolder\Storm.Cli.$version.nupkg"
			
			CheckExitCode "NuGet Push"
		} else {
			Write-Host "Skipping publishment to NuGet.org"
		}
	} else {
		Write-Host "No api key file found, skipping publish"
	}
} else {
	Write-Host "Skipping creation of NuGet package" -f yellow
}

Write-Host "Done" -f green
if ($autoExit -ne $true) {
	Quit
}