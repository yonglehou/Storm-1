Write-Host "Hello!"

$command = "
USE master

IF EXISTS(select * from sys.databases where name='Storm')
BEGIN
	ALTER DATABASE Storm SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE Storm SET ONLINE;

	DROP DATABASE Storm;
END

CREATE DATABASE Storm";

$connection = New-Object System.Data.SqlClient.SQLConnection("Data Source=.;Integrated Security=True;");
$connection.Open();

$command = New-Object System.Data.SqlClient.SqlCommand($command, $connection);

if ($command.ExecuteNonQuery() -ne -1)
{
    throw "Failed to (re)create database";
}
else
{
	Write-Host "Successfully (re)created database";
}

$connection.Close();