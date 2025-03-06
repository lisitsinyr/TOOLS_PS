Param ([string]$Server,[string]$From,[string]$To,[string]$Body,[string]$Subject,[string]$Attachment)

function send_message ([string]$private:Server,[string]$private:From,[string[]]$private:To,`
[string]$private:Body,[string]$private:Subject,$private:Attachment){
#-------------------------------------
# отправка сообщения через SMTP сервер
# $Server     - SMTP сервер
# $From       - адрес отправителя
# $To         - получатели
# $Body       - тело сообщения
# $Subject    - тема сообщения
# $Attachment - вложения
#-------------------------------------
   $private:a = ""
   #Создаем объекты SmtpClient и MailMessage
   $SmtpClient = New-Object System.Net.Mail.SmtpClient
   $Message = New-Object System.Net.Mail.MailMessage
   #устанавливаем свойства этих объектов
   $SmtpClient.Host = $Server
   $Message.Body = $Body
   $Message.Subject = $Subject
   $Message.From = $From
   #создаем и добавляем вложения
   if ($Attachment.length -gt 0){
      [System.IO.FileInfo[]]$private:Attach = $Attachment
      $Attach | ForEach-Object {
         $a = New-Object System.Net.Mail.Attachment($_.fullname)
         $Message.Attachments.Add($a)
      }  
   }
   #добавляем получателей
   $To | ForEach-Object {$Message.To.Add($_)}
   #отправляем сообщение
   $SmtpClient.Send($Message)
   #удаляем объекты
   $Message.Dispose()
}

send_message $Server $From $To $Body $Subject $Attachment
