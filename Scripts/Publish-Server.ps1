$ErrorActionPreference = "Stop";

$SolutionPath = [System.IO.Path]::GetFullPath("$PSScriptRoot\..\TestMusicAppServer.sln");
$OutputFolder = [System.IO.Path]::GetFullPath("$PSScriptRoot\..\..\PublishedServer");

dotnet publish $SolutionPath -o $OutputFolder;