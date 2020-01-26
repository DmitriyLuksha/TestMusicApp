<#
.DESCRIPTION
    Fill your database with test data. Note, that existing data will be lost
.PARAMETER TracksStorageAccountName
    Account name of the storage with tracks
.PARAMETER TracksStorageAccountKey
    Account key of the storage with tracks
.PARAMETER TracksStorageContainerName
    Name of the container with sample tracks
.PARAMETER DatabaseConnectionString
    Connection string to your database
#>

[CmdletBinding()]
Param (
    [Parameter(Mandatory=$True)]
    [string]$TracksStorageAccountName,

    [Parameter(Mandatory=$True)]
    [string]$TracksStorageAccountKey,

    [Parameter(Mandatory=$True)]
    [string]$TracksStorageContainerName,

    [Parameter(Mandatory=$True)]
    [string]$DatabaseConnectionString
)

$ErrorActionPreference = "Stop";

Function Clear-Database($SqlConnection) {
    $DisableConstraintsCmd = $SqlConnection.CreateCommand();
    $DisableConstraintsCmd.CommandText = "EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'";
    $DisableConstraintsCmd.ExecuteNonQuery() | Out-Null;

    $CleanDatabaseCmd = $SqlConnection.CreateCommand();
    $CleanDatabaseCmd.CommandText = "EXEC sp_MSForEachTable 'DELETE FROM ?'";
    $CleanDatabaseCmd.ExecuteNonQuery() | Out-Null;

    $EnableConstraintsCmd = $SqlConnection.CreateCommand();
    $EnableConstraintsCmd.CommandText = "EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";
    $EnableConstraintsCmd.ExecuteNonQuery() | Out-Null;
}

Function Add-TestUsers($SqlConnection) {
    $AddTestUsersCmd = $SqlConnection.CreateCommand();
    $AddTestUsersCmd.CommandText = "EXEC AddTestUsers";
    $AddTestUsersCmd.ExecuteNonQuery() | Out-Null;
}

Function Add-TestPlaylists($SqlConnection) {
    $AddTestPlaylistsCmd = $SqlConnection.CreateCommand();
    $AddTestPlaylistsCmd.CommandText = "EXEC AddTestPlaylists";
    $AddTestPlaylistsCmd.ExecuteNonQuery() | Out-Null;
}

Function Add-TestTracks($SqlConnection, $TrackBlobs) {
    $TracksTable = New-Object System.Data.DataTable;
    $TracksTable.Columns.Add("TrackFileName", "System.String") | Out-Null;

    Foreach ($TrackBlob In $TrackBlobs) {
        $Row = $TracksTable.NewRow();
        $Row.TrackFileName = $TrackBlob.Name;
        $TracksTable.Rows.Add($Row);
    }

    $AddTestTracksCmd = $SqlConnection.CreateCommand();
    $AddTestTracksCmd.CommandText = "AddTestTracks";
    $AddTestTracksCmd.CommandType = [System.Data.CommandType]::StoredProcedure;

    $TrackFileNamesParam = New-Object System.Data.SqlClient.SqlParameter;
    $TrackFileNamesParam.ParameterName = "trackFileNames";
    $TrackFileNamesParam.SqlDbType = [System.Data.SqlDbType]::Structured;
    $TrackFileNamesParam.Direction = [System.Data.ParameterDirection]::Input;
    $TrackFileNamesParam.Value = $TracksTable;

    $AddTestTracksCmd.Parameters.Add($TrackFileNamesParam) | Out-Null;

    $AddTestTracksCmd.ExecuteNonQuery() | Out-Null;
}

$StorageContext = New-AzureStorageContext -StorageAccountName $TracksStorageAccountName -StorageAccountKey $TracksStorageAccountKey;
$Blobs = Get-AzureStorageBlob -Context $StorageContext -Container $TracksStorageContainerName;

$SqlConnection = New-Object System.Data.SqlClient.SqlConnection;
$SqlConnection.ConnectionString = $DatabaseConnectionString;
$SqlConnection.Open();

Clear-Database $SqlConnection;
Write-Host "Cleared database";

Add-TestUsers $SqlConnection;
Write-Host "Added test users";

Add-TestPlaylists $SqlConnection;
Write-Host "Added test playlists";

Add-TestTracks $SqlConnection $Blobs;
Write-Host "Added test tracks";

$SqlConnection.Close();