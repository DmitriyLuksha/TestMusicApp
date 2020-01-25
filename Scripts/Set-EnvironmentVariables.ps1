<#
.DESCRIPTION
    Set environment variables
#>

[CmdletBinding()]
Param (
    [Parameter(Mandatory=$True)]
    [string]$ConnectionStringsTestMusicAppDb,

    [Parameter(Mandatory=$True)]
    [string]$ConnectionStringsTestMusicAppServiceBus,

    [Parameter(Mandatory=$True)]
    [string]$ConnectionStringsTestMusicAppStorage,

    [Parameter(Mandatory=$True)]
    [string]$ConnectionStringsTestMusicAppSignalR,

    [Parameter(Mandatory=$True)]
    [string]$ServiceBusAudioConversionQueueName,

    [Parameter(Mandatory=$True)]
    [string]$ServiceBusYoutubeConversionQueueName,

    [Parameter(Mandatory=$True)]
    [string]$ServiceBusAudioUploadingResultQueueName,

    [Parameter(Mandatory=$True)]
    [string]$StorageAudioFilesContainerName,

    [Parameter(Mandatory=$True)]
    [string]$StorageUnprocessedAudioFilesContainerName,

    [Parameter(Mandatory=$False)]
    [string]$ApplicationInsightsInstrumentationKey
)

$ErrorActionPreference = "Stop";

$EnvironmentVariablesTarget = [EnvironmentVariableTarget]::Machine;

[Environment]::SetEnvironmentVariable("TestMusicApp_ConnectionStrings__TestMusicAppDb", $ConnectionStringsTestMusicAppDb, $EnvironmentVariablesTarget);
[Environment]::SetEnvironmentVariable("TestMusicApp_ConnectionStrings__TestMusicAppServiceBus", $ConnectionStringsTestMusicAppServiceBus, $EnvironmentVariablesTarget);
[Environment]::SetEnvironmentVariable("TestMusicApp_ConnectionStrings__TestMusicAppStorage", $ConnectionStringsTestMusicAppStorage, $EnvironmentVariablesTarget);
[Environment]::SetEnvironmentVariable("TestMusicApp_ConnectionStrings__TestMusicAppSignalR", $ConnectionStringsTestMusicAppSignalR, $EnvironmentVariablesTarget);
[Environment]::SetEnvironmentVariable("TestMusicApp_ServiceBus__AudioConversionQueueName", $ServiceBusAudioConversionQueueName, $EnvironmentVariablesTarget);
[Environment]::SetEnvironmentVariable("TestMusicApp_ServiceBus__YoutubeConversionQueueName", $ServiceBusYoutubeConversionQueueName, $EnvironmentVariablesTarget);
[Environment]::SetEnvironmentVariable("TestMusicApp_ServiceBus__AudioUploadingResultQueueName", $ServiceBusAudioUploadingResultQueueName, $EnvironmentVariablesTarget);
[Environment]::SetEnvironmentVariable("TestMusicApp_Storage__AudioFilesContainerName", $StorageAudioFilesContainerName, $EnvironmentVariablesTarget);
[Environment]::SetEnvironmentVariable("TestMusicApp_Storage__UnprocessedAudioFilesContainerName", $StorageUnprocessedAudioFilesContainerName, $EnvironmentVariablesTarget);

If ($ApplicationInsightsInstrumentationKey) {
    [Environment]::SetEnvironmentVariable("TestMusicApp_ApplicationInsights__InstrumentationKey", $ApplicationInsightsInstrumentationKey, $EnvironmentVariablesTarget);
}