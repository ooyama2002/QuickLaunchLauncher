set path=%path%;C:\Windows\Microsoft.NET\Framework\v4.0.30319
set OutputPath=%~dp0\exe
msbuild %~dp0QuickLaunchLauncher.sln   /t:Clean;Build /p:Configuration=Release;TargetFrameworkVersion="v4.0";OutputPath="%OutputPath%"
del %OutputPath%\*pdb
pause

rem dot net version 4.5
rem msbuild %~dp0QuickLaunchLauncher.sln   /t:Clean;Build /p:Configuration=Release;Platform="Any CPU";TargetFrameworkVersion="v4.5";OutputPath="%OutputPath%"
