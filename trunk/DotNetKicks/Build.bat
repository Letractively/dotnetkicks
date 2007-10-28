@echo off

ECHO 1: Build and run all tests and analysis
ECHO 2: Build Only
ECHO 3: Build and run tests
ECHO 4: Build and run FxCop analysis

set buildtype=BuildAll
set /p choice=Choose a build type: 

if %choice% EQU 2 set buildtype=Build
if %choice% EQU 3 set buildtype=Tests
if %choice% EQU 4 set buildtype=FxCop

:build 
echo Building target %buildtype%
%windir%\Microsoft.NET\Framework\v2.0.50727\MSBuild DotNetKicks.msbuild /t:%buildtype%
echo Built target %buildtype%
pause