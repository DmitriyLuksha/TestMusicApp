[CmdletBinding()]
Param (
    [Parameter(Mandatory=$True)]
    [string]$DatabaseConnectionString,

    [Parameter(Mandatory=$True)]
    [string]$ServiceBusConnectionString,

    [Parameter(Mandatory=$True)]
    [string]$SignalRConnectionString,

    [Parameter(Mandatory=$True)]
    [string]$StorageConnectionString,

    [Parameter(Mandatory=$True)]
    [string]$AudioConversionQueueName,

    [Parameter(Mandatory=$True)]
    [string]$YoutubeConversionQueueName,

    [Parameter(Mandatory=$True)]
    [string]$AudioUploadingResultQueueName,

    [Parameter(Mandatory=$True)]
    [string]$AudioFilesContainerName,

    [Parameter(Mandatory=$True)]
    [string]$UnprocessedAudioFilesContainerName,

    [Parameter(Mandatory=$False)]
    [string]$ApplicationInsightsInstrumentationKey
)

$ErrorActionPreference = "Stop";

Function Set-PlaceholderValue($Content, $Placeholder, $Value) {
    return $Content.Replace("*$Placeholder*", $Value);
}

$FinalConfigName = "appsettings.Development.json";

$ConfigsFolder = "$PSScriptRoot\..\TestMusicAppServer.Api";
$ConfigTemplatePath = "$ConfigsFolder\appsettings.Template.json";
$ConfigPath = [System.IO.Path]::GetFullPath("$ConfigsFolder\$FinalConfigName");

$ConfigContent = Get-Content -Path $ConfigTemplatePath;

$ConfigContent = Set-PlaceholderValue -Content $ConfigContent -Placeholder "ConnectionStrings.TestMusicAppDb" -Value $DatabaseConnectionString;
$ConfigContent = Set-PlaceholderValue -Content $ConfigContent -Placeholder "ConnectionStrings.TestMusicAppServiceBus" -Value $ServiceBusConnectionString;
$ConfigContent = Set-PlaceholderValue -Content $ConfigContent -Placeholder "ConnectionStrings.TestMusicAppStorage" -Value $StorageConnectionString;
$ConfigContent = Set-PlaceholderValue -Content $ConfigContent -Placeholder "ConnectionStrings.TestMusicAppSignalR" -Value $SignalRConnectionString;
$ConfigContent = Set-PlaceholderValue -Content $ConfigContent -Placeholder "ServiceBus.AudioConversionQueueName" -Value $AudioConversionQueueName;
$ConfigContent = Set-PlaceholderValue -Content $ConfigContent -Placeholder "ServiceBus.YoutubeConversionQueueName" -Value $YoutubeConversionQueueName;
$ConfigContent = Set-PlaceholderValue -Content $ConfigContent -Placeholder "ServiceBus.AudioUploadingResultQueueName" -Value $AudioUploadingResultQueueName;
$ConfigContent = Set-PlaceholderValue -Content $ConfigContent -Placeholder "Storage.AudioFilesContainerName" -Value $AudioFilesContainerName;
$ConfigContent = Set-PlaceholderValue -Content $ConfigContent -Placeholder "Storage.UnprocessedAudioFilesContainerName" -Value $UnprocessedAudioFilesContainerName;
$ConfigContent = Set-PlaceholderValue -Content $ConfigContent -Placeholder "ApplicationInsights.InstrumentationKey" -Value $ApplicationInsightsInstrumentationKey;

If (!(Test-Path -Path $ConfigPath)) {
    Write-Host "Creating file $ConfigPath";
    New-Item -Path $ConfigPath | Out-Null;
}

Write-Host "Updating content of $ConfigPath";
Set-Content -Path $ConfigPath -Value $ConfigContent | Out-Null;