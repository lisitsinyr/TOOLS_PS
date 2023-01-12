#=======================================================================================
# ListDir.ps1
# powershell.exe -executionpolicy RemoteSigned -file ListDir.ps1 "-PSDir='%PSDir%'" -Format=%Format% -NLevel=%NLevel%"
#=======================================================================================

#------------------------------------------
# БИБЛИОТЕКИ PowerShell
#------------------------------------------

#------------------------------------------
#Разбор аргументов
#------------------------------------------
#parser = argparse.ArgumentParser(description='Параметры')
#parser.add_argument('-PSDir', type=str, nargs='?', default='', dest='PSDir', help='Библиотека')
#parser.add_argument('-Format', type=int, nargs='?', default=-1, dest='Format', help='Номер шаблона')
#parser.add_argument('-NLevel', type=int, nargs='?', default=-1, dest='NLevel', help='Уровень')
#args = parser.parse_args()
#print('-PSDir  = '+args.PSDir)
#print('-Format =',args.Format)
#print('-NLevel =',args.NLevel)
##------------------------------------------
#PSDir = 'D:\\PROJECTS\\!TOOLS\\TOOLS_PY\\PY'
#if args.PSDir != "":
#    PSDir = args.PSDir
##endif
#sys.path.append(PSDir)
##------------------------------------------
#Format = 0
#if args.Format != -1:
#    Format = args.Format
##endif
##------------------------------------------
#NLevel = 1
#if args.NLevel != -1:
#    NLevel = args.NLevel
##endif
#------------------------------------------

#------------------------------------------
# БИБЛИОТЕКА LU
#------------------------------------------
#import LUConst
#import LUStrings
#import LUSupport
#------------------------------------------

#------------------------------------------
#CONST
#------------------------------------------
$Level = 0
$Mask = '*.*'
$Log = ""
#------------------------------------------
$DirName = ""
$Shablon = ""
$Shablon0 = "call arjd.bat {0}"          # $DirName
$Shablon1 = "{0} {1} {2} {3}"         # $FullDirName $FileName $FileTime $FileSize
$Shablon2 = "{0}={1}||{2}|{3}|!!|{4}" # $FileName=$FullFileName||$FullFileDir|$FullFileName|!!|$FileDir
#------------------------------------------

#---------------------------------------------------------------------------
$UTF8win1251 = 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,  #0 -  15
16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31,  #16 -  31
32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47,  #32 -  47
48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63,  #48 -  63
#---------------------------------------------------------------------------
64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79,  #64 -  79
80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95,  #80 -  95
96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111,  #96 - 111
112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127,  #112 - 127
#---------------------------------------------------------------------------
240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255,  #128 - 143
192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207,  #144 - 159
208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223,  #160 - 175
224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239,  #176 - 191
#---------------------------------------------------------------------------
192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207,  #192 - 207
208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223,  #208 - 223
224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239,  #224 - 239
240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255  #240 - 255

#---------------------------------------------------------------------------

#---------------------------------------------------------------------------
$DOSwin1251 = 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,  #0 -  15
16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31,  #16 -  31
32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47,  #32 -  47
48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63,  #48 -  63
#---------------------------------------------------------------------------
64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79,  #64 -  79
80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95,  #80 -  95
96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111,  #96 - 111
112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127,  #112 - 127
#---------------------------------------------------------------------------
192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207,  #128 - 143
208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223,  #144 - 159
224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239,  #160 - 175
240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255,  #176 - 191
#---------------------------------------------------------------------------
192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207,  #192 - 207
208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223,  #208 - 223
224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239,  #224 - 239
240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255  #240 - 255

#---------------------------------------------------------------------------

#---------------------------------------------------------------------------
$winDOS1251 = 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,  #0 -  15
16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31,  #16 -  31
32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47,  #32 -  47
48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63,  #48 -  63
#---------------------------------------------------------------------------
64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79,  #64 -  79
80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95,  #80 -  95
96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111,  #96 - 111
112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127,  #112 - 127
#---------------------------------------------------------------------------
192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207,  #128 - 143
208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223,  #144 - 159
224, 225, 226, 227, 228, 229, 230, 231, 240, 233, 234, 235, 236, 237, 238, 239,  #160 - 175
240, 241, 242, 243, 244, 245, 246, 247, 241, 249, 250, 251, 252, 253, 254, 255,  #176 - 191
#---------------------------------------------------------------------------
128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143,  #192 - 207
144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159,  #208 - 223
160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175,  #224 - 239
224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239  #240 - 255

#---------------------------------------------------------------------------

#----------------------------------------------------------------------------
# UTF8toWin
#----------------------------------------------------------------------------
function UTF8toWin ($s)
{#beginfunction
    $LResult = ""
    $i = 1
    while ($i -lt $s.Length+1)
    {
        $с = $s[$i]
        if (([int]$c -eq 208) -or ([int]$c -eq 209))
        {
            $i = $i + 1
            $c = $s[$i]
        }#endif
        $LResult = $LResult + "" + [char]$UTF8win1251[[int]$c]
        $i = $i + 1
    }#endwhile
    $LGet_UTF8toWin = $LResult
    return $LGet_UTF8toWin
}#endfunction

#----------------------------------------------------------------------------
# DOStoWin
#----------------------------------------------------------------------------
function DOStoWin ($s)
{#beginfunction
    $LResult = ""
    $i = 1
    while ($i -lt $s.Length+1)
    {
        $c = $s[$i]
        $LResult = $LResult + "" + [char]$DOSwin1251[[int]$c]
        $i = $i + 1
    }#endwhile
    $LGet_DOStoWin = $LResult
    return $LGet_DOStoWin
}#endfunction

#----------------------------------------------------------------------------
# WinToDOS
#----------------------------------------------------------------------------
function WinToDOS ($s)
{#beginfunction
    $LResult = ""
    $i = 1
    while ($i -lt $s.Length+1)
    {
        $c = $s[$i]
        $LResult = $LResult + "" + [char]$winDOS1251[[int]$c]
        $i = $i + 1
    }#endwhile
    $LGet_WinToDOS = $LResult
    return $LGet_WinToDOS
}#endfunction

#----------------------------------------------------------------------------
# GetFileName
#----------------------------------------------------------------------------
function GetFileName ($Afilespec)
{#beginfunction
    $LGet_GetFileName = $Afilespec
    #bash = instrRev ($Afilespec, "\\")
    #if bash or instrRev ($Afilespec,".")
    #  $LGet_GetFileName = substr ($Afilespec,bash+1)
    #}#endif
}#endfunction

#-------------------------------------------------------------------------------
# WorkFile (AFile_path)
#-------------------------------------------------------------------------------
function WorkFile ($AFile_path)
{#beginfunction
    #global $Shablon
    #FullDirName: str = ""
    #FileName: str = ""
    #FileTime: int = 0
    #FileSize: int = 0
    #FullFileName: str = ""
    #FullFileDir: str  = ""
    #FileDir: str = ""
    $LFileNameSource = $AFile_path
    $LFullFileName = $LFileNameSource
#  LFullFileDir = ASourcePath
#  LFileDir = GetFileName(ASourcePath)
#  LFileSizeSource = GetFileSize(LFileNameSource)
#  LFileSize = LFileSizeSource
#  LFileTimeSource = GetFileTime(LFileNameSource)
#-------------------------------------------------------------------------
    #file modification
    #$LFileTimeSource = os.path.getmtime(LFileNameSource)
    #convert timestamp into DateTime object
    #$LFileTimeSource = datetime.datetime.fromtimestamp(LFileTimeSource)
    #file creation
    #$LFileTimeSource = os.path.getctime(LFileNameSource)
    #convert creation timestamp into DateTime object
    #$LFileTimeSource = datetime.datetime.fromtimestamp(LFileTimeSource)
#-------------------------------------------------------------------------
    if ($Shablon -eq $Shablon1)
    {
        $Lmessage = $Shablon
        #message = Shablon.format(DirName=os.path.basename(ASourcePath))
        print ('Shablon1='+$Lmessage)
    }#endif

    if ($Shablon -eq $Shablon2)
    {
        $Lmessage = $Shablon
        #message = Shablon.format(DirName=os.path.basename(ASourcePath))
        print ('Shablon2='+$message)
    }#endif
}#endfunction

#-------------------------------------------------------------------------------
# ListFile (ASourcePath, AMask)
#-------------------------------------------------------------------------------
function ListFile ($ASourcePath, $AMask)
{#beginfunction
    $LFiles = Get-ChildItem ($ASourcePath)
    foreach ($LFile in $LFiles)
    {
        if ((-not $ASourcePath.PSIsContainer))
        {
            #Это файл
            #$LSourcePath = Join-Path ($ASourcePath, $LFile.Name)
            $LSourcePath = $ASourcePath+$LFile.Name
            #$Lstats = os.stat ($LSourcePath)
            WorkFile ($LSourcePath)
        }#endif
    }#foreach
}#endfunction

#-------------------------------------------------------------------------------
# ListDir (ASourcePath, AMask)
#-------------------------------------------------------------------------------
function ListDir ($ASourcePath, $AMask)
{#beginfunction
    $Level = $Level + 1
    #------------------------------------------------------------
    # Dir
    #------------------------------------------------------------
    #LDirName = GetFileName(ASourcePath)
    $LDirName = $ASourcePath
    $LFullDirName = $ASourcePath
    if ($Level -gt $NLevel)
    {
        if (($Format -ne 1) -and ($Format -ne 2))
        {
            #$Shablon -f $LDirName
        }#endif
    }#endif

    $LFiles = Get-ChildItem ($ASourcePath)
    foreach ($LFile in $LFiles) {
        $LSourcePath = $ASourcePath.Path+"\"+$LFile.Name
        $LSourcePath = $LFile.FullName
        if ($LFile.PSIsContainer)
        {
            #'Это каталог'
            #$LFile.Name
            #$LFile.FullName
            ListFile ($LSourcePath, $AMask)
            if (($Format -ne 1) -and ($Format -ne 2))
            {
                $LDirName = $LFile.Name
                $Shablon -f $LDirName
            }#endif
            if ($NLevel -ige $Level)
            {
                ListDir ($LFile.FullName)
            }#endif
        }#endif
    }#foreach

    $Level = $Level - 1
}#endfunction

#beginmodule
#------------------------------------------
    #print ($LUConst.Userid)

    $Dir = Get-Location
    $Dir = $Dir.Path

    switch ($Format) {
        1 {
            $Log = 'sfile.ini'
            if ($NLevel -lt 0)
            {
                $NLevel = 0
            }#endif
            $Shablon = $Shablon1
        }
        2 {
            $Log = 'sfile.ini'
            if ($NLevel -lt 0)
            {
                $NLevel = 0
            }#endif
            $Shablon = $Shablon2
        }
        default {
            $Log = 'sdir.bat'
            if ($NLevel -eq $null)
            {
                $NLevel = 1
            }#endif
            $Shablon = $Shablon0
        }
    }#endswitch

    'PSDir   = '+$PSDir
    'Format  = ',$Format
    'NLevel  = ',$NLevel
    'Mask    = '+$Mask
    'Dir     = '+$Dir
    'Log     = '+$Log
    'Shablon = '+$Shablon

    ListDir -ASourcePath $Dir -AMask $Mask

#endmodule
