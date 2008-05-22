@echo off

echo 1: Build Only (default)
echo 2: Build and run tests
echo 3: Build and run FxCop analysis
echo 4: Build and run all tests and analysis
echo.

set target=Build
set choice=1
set /p choice=Choose a build target or press enter to run the default target: 

if %choice% EQU 2 set target=Tests
if %choice% EQU 3 set target=FxCop
if %choice% EQU 4 set target=BuildAll

:build 
echo.
echo Building target: %target%
echo.
%windir%\Microsoft.NET\Framework\v2.0.50727\MSBuild DotNetKicks.msbuild /t:%target%
echo.
echo Built target: %target%
echo.
pause