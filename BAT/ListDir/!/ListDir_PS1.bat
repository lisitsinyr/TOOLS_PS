@echo on

rem -------------------------------------------------------------------
:A_PSDir
if "%PSDir%" == "" goto A_PSDir_2
goto A_Format
:A_PSDir_2
echo ���祭�� ��६����� �।� PSDir �� ��⠭������
if "%COMPUTERNAME%" == "%USERDOMAIN%" goto Local
:Network
set PSDir=\\S73FS01\APPInfo\tools
goto A_Format
:Local
set PSDir=D:\PROJECTS\�����\Python\TOOLS\PY
goto A_Format

rem -------------------------------------------------------------------
:A_Format
if "%1" == "" goto A_Format_2
set Format="%1"
goto A_NLevel
:A_Format_2
set Format=0

rem -------------------------------------------------------------------
:A_NLevel
if "%2" == "" goto A_NLevel_2
set NLevel="%2"
goto Stop
:A_NLevel_2
set NLevel=1

rem -------------------------------------------------------------------
:Stop
echo ���祭�� ��६����� �।� PSDir=%PSDir%
echo ���祭�� ��६����� �।� Format=%Format%
echo ���祭�� ��६����� �।� NLevel=%NLevel%
rem -------------------------------------------------------------------

rem pwsh.exe.exe ListDir.ps1 "-PSDir='%PSDir%'" -Format=%Format% -NLevel=%NLevel%
powershell.exe -executionpolicy RemoteSigned -file ListDir.ps1 "-PSDir='%PSDir%'" -Format=%Format% -NLevel=%NLevel%
