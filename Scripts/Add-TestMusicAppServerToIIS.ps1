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
    [Parameter(Mandatory=$True)]
    [string]$WebSitePath,

    [Parameter(Mandatory=$False)]
    [string]$WebSiteName,

    [Parameter(Mandatory=$False)]
    [string]$HostName,

    [Parameter(Mandatory=$False)]
    [string]$AppPoolName
)

$ErrorActionPreference = "Stop";

Import-Module WebAdministration

If (!$WebSiteName) {
    $WebSiteName = "TestMusicApp";
}

If (!$HostName) {
    $HostName = "testmusicapp.local";
}

If (!$AppPoolName) {
    $AppPoolName = $WebSiteName;
}

If (Test-Path "IIS:\Sites\$WebSiteName"){
    Write-Host "The IIS web site $WebSiteName already exists";
    exit;
}

If (Test-Path("IIS:\AppPools\" + $AppPoolName)) {
    Write-Host "The App Pool $AppPoolName already exists";
}
Else {
    New-WebAppPool -Name $AppPoolName | Set-ItemProperty -Name "managedRuntimeVersion" -Value "";
    Write-Host "Created App Pool $AppPoolName";
}

New-Website -Name $WebSiteName -PhysicalPath $WebSitePath -ApplicationPool $AppPoolName -HostHeader $HostName;
Write-Host "Created Site $WebSiteName";

$HostsPath = "$Env:WinDir\System32\drivers\etc\hosts";
$HostsContent = Get-Content $HostsPath;

If ($HostsContent -Match "127\.0\.0\.1\s+$HostName") {
    Write-Host "$HostName already in hosts file";
}
Else {
    Add-Content -Path $HostsPath -Value "127.0.0.1`t$HostName";
    Write-Host "Added $HostName to hosts file";
}