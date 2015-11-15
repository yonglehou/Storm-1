# Recreate database
$sql = Get-Content ".\Scripts\1-Recreate.sql"

$connection = New-Object System.Data.SqlClient.SQLConnection("server=.;integrated security=true;");
$connection.Open();

$command = New-Object System.Data.SqlClient.SqlCommand($sql, $connection);
$result = $command.ExecuteNonQuery()

# Create structure
$sql = Get-Content ".\Scripts\2-Structure.sql" -Encoding UTF8 -Raw
$cmds = $sql -split "GO"

foreach ($cmd in $cmds)
{
	$cmd = $cmd.Trim()

	if ($cmd -ne "")
	{
		$command = New-Object System.Data.SqlClient.SqlCommand($cmd, $connection);
		$result = $command.ExecuteNonQuery()
	}
}

# Data
$sql = Get-Content ".\Scripts\3-Data.sql" -Encoding UTF8 -Raw
$cmds = $sql -split "GO"

foreach ($cmd in $cmds)
{
	$cmd = $cmd.Trim()

	if ($cmd -ne "")
	{
		$command = New-Object System.Data.SqlClient.SqlCommand($cmd, $connection);
		$result = $command.ExecuteNonQuery()
	}
}

$connection.Close();