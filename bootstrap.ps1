param([switch]$Force)

function writeHelpOutput() {
  Write-Host "Build successfully bootstrapped!" -ForegroundColor Green
  Write-Host

  Write-Host "==================================================" -ForegroundColor white
  Write-Host "====Examples on running your build using cake=====" -ForegroundColor white
  Write-Host "==================================================" -ForegroundColor white
  Write-Host
  Write-Host "==================================================="
  Write-Host "| Running with no params will run the build using |"
  Write-Host "| the default 'Build' target from the build.cake  |"
  Write-Host "| script. It also defaults the version to 1.0.0   |"
  Write-Host "| and uses the configuration of Release. It will  |"
  Write-Host "| attempt to find your .sln file. The .sln has to |"
  Write-Host "| be in the same dir as the build scripts. Also,  |"
  Write-Host "| there can only be a single .sln in that folder. |"
  Write-Host "==================================================="
  Write-Host "Example: .\build.ps1" -ForegroundColor White
  Write-Host "==================================================="
  Write-Host "| Running with all parameters specified           |"
  Write-Host "==================================================="
  Write-Host "Example: .\build.ps1 -Script .\build.cake -Target Package -Configuration Debug -AppVer 0.0.1 -SolutionPath .\MySln.sln" -ForegroundColor White
  Write-Host "==================================================="
}

$PSScriptRoot = split-path -parent $MyInvocation.MyCommand.Definition;
$BUILD_CAKE_URL = "https://raw.githubusercontent.com/market6/MK6.Tools.CakeBuild/master/Bootstrapper/build.cake"
$BUILD_PS1_URL = "https://raw.githubusercontent.com/market6/MK6.Tools.CakeBuild/master/Bootstrapper/build.ps1"

Write-Host "Downloading build files..." -ForegroundColor White
$cakeFilePath = Join-Path $PSScriptRoot "build.cake"
$buildPs1Path = Join-Path $PSScriptRoot "build.ps1"
if(($Force.IsPresent -ne $True) -and ((Test-Path $cakeFilePath) -or (Test-Path $buildPs1Path))) {
  Write-Warning "Skipping copying of build.cake/.ps1 since they already exist. Use -Force to overwrite them."
}
else {
  Invoke-WebRequest -Uri $BUILD_CAKE_URL -OutFile $cakeFilePath
  Invoke-WebRequest -Uri $BUILD_PS1_URL -OutFile $buildPs1Path
  writeHelpOutput
}
