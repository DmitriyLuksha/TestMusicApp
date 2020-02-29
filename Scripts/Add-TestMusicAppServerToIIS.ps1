<#
.DESCRIPTION
    Add site and its application pool to IIS
.PARAMETER WebSitePath
    Path to the published content of the site
.PARAMETER WebSiteName
    Web Site name. Default: TestMusicApp
.PARAMETER HostName
    Host name. Default: testmusicapp.local
.PARAMETER AppPoolName
    Application pool name. Default is a SiteName
#>

[CmdletBinding()]
Param (
    [Parameter(Mandatory=$False)]
    [string]$WebSiteName = "TestMusicApp",

    [Parameter(Mandatory=$False)]
    [string]$HostName = "testmusicapp.local",

    [Parameter(Mandatory=$False)]
    [string]$AppPoolName
)

$ErrorActionPreference = "Stop";

Import-Module WebAdministration

If (!$AppPoolName) {
    $AppPoolName = $WebSiteName;
}

$WebSitePath = [System.IO.Path]::GetFullPath("$PSScriptRoot\..\..\PublishedServer");

New-Item -ItemType Directory -Path $WebSitePath -Force | Out-Null;

If (Test-Path "IIS:\Sites\$WebSiteName"){
    Write-Host "The IIS web site $WebSiteName already exists";
    Exit;
}

If (Test-Path("IIS:\AppPools\" + $AppPoolName)) {
    Write-Host "The App Pool $AppPoolName already exists";
}
Else {
    Write-Host "Creating App Pool $AppPoolName";
    New-WebAppPool -Name $AppPoolName | Set-ItemProperty -Name "managedRuntimeVersion" -Value "";
}

Write-Host "Creating Site $WebSiteName";
New-Website -Name $WebSiteName -PhysicalPath $WebSitePath -ApplicationPool $AppPoolName -HostHeader $HostName | Out-Null;

$HostsPath = "$Env:WinDir\System32\drivers\etc\hosts";
$HostsContent = Get-Content $HostsPath;

If ($HostsContent -Match "127\.0\.0\.1\s+$HostName") {
    Write-Host "$HostName already in hosts file";
}
Else {
    Write-Host "Adding $HostName to the hosts file";
    Add-Content -Path $HostsPath -Value "127.0.0.1`t$HostName";
}