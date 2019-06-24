﻿$curDir = Split-Path -Parent $MyInvocation.MyCommand.Definition;
Import-Module "$curDir\MG.SharePoint.psd1";

$loginParams = @{
	TenantName = "yevrag35.com"
	PromptBehavior = "Auto"
	PassThru = $true
}

$web = Connect-SPOnline @loginParams
$list = Get-SPList "Code Library";
$li = $list | Get-SPListItem -AndCondition @{ file = "command.txt" };
$li.File;