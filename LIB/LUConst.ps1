#-------------------------------------------------------------------------------
# LUConst.ps1
#-------------------------------------------------------------------------------
#------------------------------------------
# БИБЛИОТЕКИ PowerShell
#------------------------------------------

#-------------------------------------------------------------------------------
#APP_Drive_FSGU       = "G:"
#APP_Drive_FSGU_PRGGU = "L:"
#APP_Drive_S73FS01    = "K:"
#APP_Drive_S73FS02    = "L:"
#APP_Drive_S73FS03    = "W:"
#APP_Drive_S73FS04    = "M:"
APP_Drive_Local = "D:"

#-------------------------------------------------------------------------------
#
#-------------------------------------------------------------------------------
#DomainDSP            = "DSP73"
#SAEDProgram          = "C:\SAED\ArcMail.exe"
#WinSAEDProgram       = "C:\WinSaed\WinSaed.exe"
#PasportUOSProgram    = "C:\Pasport_cl\spclient.exe"

#------------------------------------------------------
#Файловые сервера
#------------------------------------------------------
#FileServer01   = "S73FS01"
#FileServer02   = "S73FS02"
#FileServer03   = "S73FS03"
#FileServer04   = "S73FS04"
#FileServer11   = "S73FS11"

#-------------------------------------------------------------------------------
#
#-------------------------------------------------------------------------------
#LogPath_S73FS01 = "\\S73FS04\log"
LogPath = "D:\\PROJECTS\\ЯЗЫКИ\\Python\\!!LOG"

#-------------------------------------------------------------------------------
#
#-------------------------------------------------------------------------------
#If @inwin=2
#  Userid = @WUserID
#else
#  Userid = @UserID
#endif
Userid = os.getlogin()

#-------------------------------------------------------------------------------
#
#-------------------------------------------------------------------------------
#OS = split(@ProductType)[1]
#CSD = val(right(@csd,1))
#ADMIN       = i_n_group('@wksta\'+sidtoname('S-1-5-32-544'))-1+@INWIN

#-------------------------------------------------------------------------------
#General Reestr Keys
#-------------------------------------------------------------------------------
#HKLMSCCS    = "HKLM\SYSTEM\CurrentControlSet"
#HKCUSMWCV   = "HKCU\Software\Microsoft\Windows\CurrentVersion"
#HKLMSMWCV   = "HKLM\Software\Microsoft\Windows\CurrentVersion"
#HKLMSMWNTCV = "HKLM\Software\Microsoft\Windows NT\CurrentVersion"
#HKCUSMWNTCV = "HKCU\Software\Microsoft\Windows NT\CurrentVersion"

#-------------------------------------------------------------------------------
#Users Folders
#-------------------------------------------------------------------------------
#[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders]
#"AppData"="C:\\Documents and Settings\\luis.GU\\Application Data"
#"Cookies"="C:\\Documents and Settings\\luis.GU\\Cookies"
#"Desktop"="C:\\Documents and Settings\\luis.GU\\Desktop"
#"Favorites"="C:\\Documents and Settings\\luis.GU\\Favorites"
#"NetHood"="C:\\Documents and Settings\\luis.GU\\NetHood"
#"Personal"="C:\\Documents and Settings\\luis.GU\\My Documents"
#"PrintHood"="C:\\Documents and Settings\\luis.GU\\PrintHood"
#"Recent"="C:\\Documents and Settings\\luis.GU\\Recent"
#"SendTo"="C:\\Documents and Settings\\luis.GU\\SendTo"
#"Start Menu"="C:\\Documents and Settings\\luis.GU\\Start Menu"
#"Templates"="C:\\Documents and Settings\\luis.GU\\Templates"
#"Programs"="C:\\Documents and Settings\\luis.GU\\Start Menu\\Programs"
#"Startup"="C:\\Documents and Settings\\luis.GU\\Start Menu\\Programs\\Startup"
#"Local Settings"="C:\\Documents and Settings\\luis.GU\\Local Settings"
#"Local AppData"="C:\\Documents and Settings\\luis.GU\\Local Settings\\Application Data"
#"Cache"="C:\\Documents and Settings\\luis.GU\\Local Settings\\Temporary Internet Files"
#"History"="C:\\Documents and Settings\\luis.GU\\Local Settings\\History"
#"My Pictures"="C:\\Documents and Settings\\luis.GU\\My Documents\\My Pictures"
#"Fonts"="C:\\WINDOWS\\Fonts"
#"My Music"="C:\\Documents and Settings\\luis.GU\\My Documents\\My Music"
#"Administrative Tools"="C:\\Documents and Settings\\luis.GU\\Start Menu\\Programs\\Administrative Tools"
#"CD Burning"="C:\\Documents and Settings\\luis.GU\\Local Settings\\Application Data\\Microsoft\\CD Burning"
#"My Video"="C:\\Documents and Settings\\luis.GU\\My Documents\\My Videos"
#--------------------------------------------------------------------------------
#Desktop     = readvalue(HKCUSMWCV+"\Explorer\Shell Folders",'Desktop')
#StartMenu   = readvalue(HKCUSMWCV+"\Explorer\Shell Folders",'Start Menu')
#Favorites   = readvalue(HKCUSMWCV+"\Explorer\Shell Folders",'Favorites')
#Programs    = readvalue(HKCUSMWCV+"\Explorer\Shell Folders",'Programs')
#Startup     = readvalue(HKCUSMWCV+"\Explorer\Shell Folders",'Startup')
#MyDocuments = readvalue(HKCUSMWCV+"\Explorer\Shell Folders",'Personal')

#-------------------------------------------------------------------------------
#Common Folders
#-------------------------------------------------------------------------------
#[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders]
#"Common AppData"="C:\\Documents and Settings\\All Users\\Application Data"
#"Common Programs"="C:\\Documents and Settings\\All Users\\Start Menu\\Programs"
#"Common Documents"="C:\\Documents and Settings\\All Users\\Documents"
#"Common Desktop"="C:\\Documents and Settings\\All Users\\Desktop"
#"Common Start Menu"="C:\\Documents and Settings\\All Users\\Start Menu"
#"CommonPictures"="C:\\Documents and Settings\\All Users\\Documents\\My Pictures"
#"CommonMusic"="C:\\Documents and Settings\\All Users\\Documents\\My Music"
#"CommonVideo"=""
#"Common Favorites"="C:\\Documents and Settings\\All Users\\Favorites"
#"Common Startup"="C:\\Documents and Settings\\All Users\\Start Menu\\Programs\\Startup"
#"Common Administrative Tools"="C:\\Documents and Settings\\All Users\\Start Menu\\Programs\\Administrative Tools"
#"Common Templates"="C:\\Documents and Settings\\All Users\\Templates"
#"Personal"="C:\\Documents and Settings\\luis.GU\\My Documents\\"
#--------------------------------------------------------------------------------
#CommonDesktop    = expandenvironmentvars(readvalue(HKLMSMWCV+"\Explorer\User Shell Folders","Common Desktop"))
#CommonStartMenu  = expandenvironmentvars(readvalue(HKLMSMWCV+"\Explorer\User Shell Folders","Common Start Menu"))
#CommonFavorites  = expandenvironmentvars(readvalue(HKLMSMWCV+"\Explorer\User Shell Folders","Common Favorites"))
#CommonPrograms   = expandenvironmentvars(readvalue(HKLMSMWCV+"\Explorer\User Shell Folders","Common Programs"))
#CommonStartup    = expandenvironmentvars(readvalue(HKLMSMWCV+"\Explorer\User Shell Folders","Common Startup"))

#-------------------------------------------------------------------------------
#LDAP
#-------------------------------------------------------------------------------
#DomainLDAP       = "LDAP://"+@domain+"/"+GetObject("LDAP://rootDSE").Get("defaultNamingContext")
#LDAP             = "LDAP://ou=Users,ou=business1, your company rootDSE info", "LDAP://ou=Users,ou=business2, your company rootDSE info"

#-------------------------------------------------------------------------------
#Office
#-------------------------------------------------------------------------------
#Office97   = readvalue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\8.0", "BinDirPath")
#Office2000 = readvalue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\9.0\Common\InstallRoot",  "Path")
#Office2002 = readvalue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\10.0\Common\InstallRoot", "Path")
#Office2003 = readvalue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\11.0\Common\InstallRoot", "Path")
#Office2010 = readvalue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Office\14.0\Common\InstallRoot", "Path")

#-------------------------------------------------------------------------------
#
#-------------------------------------------------------------------------------
#select
#  case (@ProductType = "Windows 95") 
#     W95 = 1
#  case (@ProductType = "Windows 98")
#     W98 = 1
#  case (@ProductType = "Windows NT Workstation")
#     WNT = 1
#  case (@ProductType = "Windows NT Workstation")
#     WNT = 1
#  case (@ProductType = "Windows NT Server")
#     WNT = 1
#  case (@ProductType = "Windows NT Domain Controller")
#     WNT = 1
#  case (@ProductType = "Windows 2000 Professional")
#     W2000 = 1
#  case (@ProductType = "Windows 2000 Server")
#     W2000 = 1
#  case (@ProductType = "Windows 2000 Domain Controller")
#     W2000 = 1
#  case (@ProductType = "Windows XP Home Edition")
#     WXP = 1
#  case (@ProductType = "Windows XP Home Edition Tablet PC")
#     WXP = 1
#  case (@ProductType = "Windows XP Professional")
#     WXP = 1
#  case (@ProductType = "Windows XP Professional Tablet PC")
#     WXP = 1
#  case (@ProductType = "Windows Server 2003")
#     W2003 = 1
#  case (@ProductType = "Windows Server 2003 Domain Controller")
#     W2003 = 1
#  case (@ProductType = "Windows 6.1 / 1")
#     W7 = 1
#  case (@ProductType = "Windows 6.2 / 1")
#     W8 = 1
#endselect
#if W95 or W98 WXX = 1 endif
#if W2000 or WXP or W2003 WXXXX = 1 endif
#-------------------------------------------------------------------------------
