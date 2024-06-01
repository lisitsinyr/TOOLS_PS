#=======================================================================================
# TEST_01.ps1
#=======================================================================================

#------------------------------------------
# БИБЛИОТЕКИ PowerShell 
#------------------------------------------

#------------------------------------------
# БИБЛИОТЕКА LU 
#------------------------------------------
#------------------------------------------

#------------------------------------------
# Function_FullFormat
#------------------------------------------
function Function_FullFormat
{#beginfunction
    param(
        [Parameter(ValueFromPipeline)]
        [string[]]
        $Param1,

        [string]$Param2
    )

    begin
    {
    '============================================================'
    ' Function_FullFormat'
    " 'один', 'два', 'три' | Function_FullFormat -Param2 'четыре'"
    '============================================================'
        Write-Host "Блок Begin"
        Write-Host "     Первый параметр (через pipeline):" $Param1
        Write-Host "     Второй параметр (аргумент функции):" $Param2
    }

    process {
        Write-Host "Блок Process"
        Write-Host "     Первый параметр (через pipeline):" $Param1
        Write-Host "     Второй параметр (аргумент функции):" $Param2
    }

    end
    {
        Write-Host "Блок End"
        Write-Host "     Первый параметр (через pipeline):" $Param1
        Write-Host "     Второй параметр (аргумент функции):" $Param2
    }
}#endfunction

function hello ($name1, $name2) {
#beginfunction
    '==========================================='
    ' hello'
    '==========================================='
    'name1='+$name1
    'name2='+$name2
    if ($name1.length -gt 3) {
        write-host "Параметр 1 длиннее 3"
    } else {
        write-host "Параметр 1 короче 4"
    }
}#endfunction

function ListDir1 ($ASourcePath, $AMask)
{
#beginfunction
    '==========================================='
    ' ListDir1                                  '
    '==========================================='
    'ASourcePath='+$ASourcePath
    'AMask='+$AMask
}#endfunction

function ListDir2
{
#beginfunction
    param(
        [string]$ASourcePath,
        [string]$AMask
    )
    '==========================================='
    ' ListDir2                                  '
    '==========================================='
    'ASourcePath='+$ASourcePath
    'AMask='+$AMask
}#endfunction

#beginmodule
#endmodule
