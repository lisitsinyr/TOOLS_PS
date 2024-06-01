#=======================================================================================
# TEST_01.ps1
#=======================================================================================

#------------------------------------------
# ���������� PowerShell 
#------------------------------------------

#------------------------------------------
# ���������� LU 
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
    " '����', '���', '���' | Function_FullFormat -Param2 '������'"
    '============================================================'
        Write-Host "���� Begin"
        Write-Host "     ������ �������� (����� pipeline):" $Param1
        Write-Host "     ������ �������� (�������� �������):" $Param2
    }

    process {
        Write-Host "���� Process"
        Write-Host "     ������ �������� (����� pipeline):" $Param1
        Write-Host "     ������ �������� (�������� �������):" $Param2
    }

    end
    {
        Write-Host "���� End"
        Write-Host "     ������ �������� (����� pipeline):" $Param1
        Write-Host "     ������ �������� (�������� �������):" $Param2
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
        write-host "�������� 1 ������� 3"
    } else {
        write-host "�������� 1 ������ 4"
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
