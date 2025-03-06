Param ([string]$Server,[string]$From,[string]$To,[string]$Body,[string]$Subject,[string]$Attachment)

function send_message ([string]$private:Server,[string]$private:From,[string[]]$private:To,`
[string]$private:Body,[string]$private:Subject,$private:Attachment){
#-------------------------------------
# �������� ��������� ����� SMTP ������
# $Server     - SMTP ������
# $From       - ����� �����������
# $To         - ����������
# $Body       - ���� ���������
# $Subject    - ���� ���������
# $Attachment - ��������
#-------------------------------------
   $private:a = ""
   #������� ������� SmtpClient � MailMessage
   $SmtpClient = New-Object System.Net.Mail.SmtpClient
   $Message = New-Object System.Net.Mail.MailMessage
   #������������� �������� ���� ��������
   $SmtpClient.Host = $Server
   $Message.Body = $Body
   $Message.Subject = $Subject
   $Message.From = $From
   #������� � ��������� ��������
   if ($Attachment.length -gt 0){
      [System.IO.FileInfo[]]$private:Attach = $Attachment
      $Attach | ForEach-Object {
         $a = New-Object System.Net.Mail.Attachment($_.fullname)
         $Message.Attachments.Add($a)
      }  
   }
   #��������� �����������
   $To | ForEach-Object {$Message.To.Add($_)}
   #���������� ���������
   $SmtpClient.Send($Message)
   #������� �������
   $Message.Dispose()
}

send_message $Server $From $To $Body $Subject $Attachment
