  Get-WmiObject -namespace 'root\bmf_StringProvider' -list
cls 

  
   Get-WmiObject -namespace 'root\bmf_StringProvider' -Class BmfString 

cls 

 Get-WmiObject -namespace 'root\bmf_StringProvider' -Class BmfString -filter "String='Anton'"
 
 cls
 
  Get-WmiObject -namespace 'root\bmf_StringProvider' -query "select * from  BmfString where String='vasya alekseev'"

cls
[wmi]"root\bmf_StringProvider:BmfString.String='vasya alekseev'"

cls

Get-WmiObject -namespace 'root\bmf_StringProvider' -Class BmfString | Get-Member

cls



Get-WmiObject -namespace 'root\bmf_StringProvider' -Class BmfFile 
[wmi]"root\bmf_StringProvider:BmfFile.String='c:\setup.log'"

 
    
 
 
 