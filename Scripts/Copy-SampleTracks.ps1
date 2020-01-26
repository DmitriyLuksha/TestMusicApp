<#
.DESCRIPTION
    Copy sample tracks into your container
.PARAMETER SampleTracksStorageAccountName
    Account name of the storage with sample tracks
.PARAMETER SampleTracksStorageAccountKey
    Account key of the storage with sample tracks
.PARAMETER SampleTracksStorageContainerName
    Name of the container with sample tracks
.PARAMETER DestinationStorageAccountName
    Account name of the storage where tracks will be copied. Default is SampleTracksStorageAccountName
.PARAMETER DestinationStorageAccountKey
    Account key of the storage where tracks will be copied. Default is SampleTracksStorageAccountKey
.PARAMETER DestinationStorageContainerName
    Name of the container where tracks will be copied
#>

[CmdletBinding()]
Param (
    [Parameter(Mandatory=$True)]
    [string]$SampleTracksStorageAccountName,

    [Parameter(Mandatory=$True)]
    [string]$SampleTracksStorageAccountKey,

    [Parameter(Mandatory=$True)]
    [string]$SampleTracksStorageContainerName,

    [Parameter(Mandatory=$False)]
    [string]$DestinationStorageAccountName,

    [Parameter(Mandatory=$False)]
    [string]$DestinationStorageAccountKey,

    [Parameter(Mandatory=$True)]
    [string]$DestinationStorageContainerName
)

If (!$DestinationStorageAccountName) {
    $DestinationStorageAccountName = $SampleTracksStorageAccountName;
}

If (!$DestinationStorageAccountKey) {
    $DestinationStorageAccountKey = $SampleTracksStorageAccountKey;
}

$ErrorActionPreference = "Stop";

$SourceStorageContext = New-AzureStorageContext -StorageAccountName $SampleTracksStorageAccountName -StorageAccountKey $SampleTracksStorageAccountKey;
$DestinationStorageContext = New-AzureStorageContext -StorageAccountName $DestinationStorageAccountName -StorageAccountKey $DestinationStorageAccountKey;

Get-AzureStorageBlob -Container $SampleTracksStorageContainerName -Context $SourceStorageContext |
    Start-AzureStorageBlobCopy -DestContainer $DestinationStorageContainerName -DestContext $DestinationStorageContext