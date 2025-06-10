@echo off
setlocal
set file=%1
if "%file%"=="" (
  echo Usage: PrenommerLauncher.bat filename
  exit /b 1
)
echo Starting Prenommer with file: %file%
powershell -Command "Start-Process 'C:\Prenommer\Prenommer\Prenommer\bin\Debug\Prenommer.exe' -ArgumentList '%file%' -Verb RunAs"
endlocal