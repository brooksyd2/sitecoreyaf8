@SET FrameworkDir=C:\Windows\Microsoft.NET\Framework\v4.0.30319
@SET FrameworkVersion=v4.0.30319
@SET FrameworkSDKDir=
@SET PATH=%FrameworkDir%;%FrameworkSDKDir%;%PATH%
@SET LANGDIR=EN
@SET CONFIGURATION=Release

.nuget\nuget.exe restore YetAnotherForum.NET.sln
msbuild.exe YetAnotherForum.NET.sln /p:Configuration=%CONFIGURATION% /p:Platform="Any CPU" /t:rebuild /p:WarningLevel=0 /flp1:logfile=errors.txt;errorsonly %1 %2 %3 %4 %5 %6 %7 %8 %9