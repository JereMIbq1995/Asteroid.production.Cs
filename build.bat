@ECHO OFF

@REM First, if Program.cs exists, copy it to a cache file, then remove it!
echo Removing Program.cs...
copy Program.cs Program.cache
del Program.cs

@REM Remove the csharp project file (if that doesn't exist, it will just give an error and move on)
echo Removing *.csproj...
del *.csproj

@REM Remove the binary and object folders of the project (if these don't exist, it will just give an error and move on)
echo Removing binary and object folders...
rmdir /s /q bin
rmdir /s /q obj

@REM Once the old files are created, create a brand new project using dotnet
echo Old files cleaned! Creating new project...
dotnet new console
dotnet restore

@REM Once the new project is created, add the Raylib_CsLo package
dotnet add package Raylib-cs --version 3.7.0.1

@REM If there's a cache file for Program.cs, copy the content to the Program.cs just created
copy Program.cache Program.cs

@REM Remove the cache file
@REM rm Program.cache