cls


set BUILD_DIRECTORY=%CD%
cd "../"
set WORKING_DIRECTORY=%CD%
cd "../3rdParty/SubSonic/195/"
set SUBSONIC_DIRECTORY=%cd%

sonic.exe generate /config sonic.exe.config  /out %WORKING_DIRECTORY%\Incremental.Kick\Dal\Subsonic\Generated


cd %BUILD_DIRECTORY%