$version = (get-item .\src\bin\ProtonVPN.exe).VersionInfo | % {("{0}.{1}.{2}" -f $_.FileMajorPart,$_.FileMinorPart,$_.FileBuildPart)}
$projectDir = $env:CI_PROJECT_DIR
$installerPath = $projectDir + "\Setup\Installers\ProtonVPN_v" + $version + ".exe"

Write-Output ("Write event with installer path: " + $installerPath)

Write-EventLog -LogName "Application" -Source "ProtonVPNService" -EventID 2 -EntryType Information -Message $installerPath -Category 0