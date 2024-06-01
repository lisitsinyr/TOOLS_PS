set PSDir=D:\PROJECTS\!TOOLS\TOOLS_PS1\PS1
set Format="%1"
set NLevel="%2"

set Format="1"
set NLevel="0"

powershell.exe -executionpolicy RemoteSigned -file TEST_01.ps1 "%PSDir%" %Format% %NLevel%
