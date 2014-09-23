ECHO Create a single dll to add in the NuGet package

IF EXIST "Merged.Storm.Cli" rmdir /s /q "Merged.Storm.Cli"
mkdir "Merged.Storm.Cli"

ILRepack.exe /target:exe /internalize /out:"Merged.Storm.Cli/stormcli.exe" ^
  Flyingpie.Storm.Cli.exe ^
  CommandLine.dll ^
  Flyingpie.Storm.dll ^
  Flyingpie.Storm.Dapper.dll ^
  Dapper.dll