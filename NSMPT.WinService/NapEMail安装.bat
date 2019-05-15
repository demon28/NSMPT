@echo.请稍等，服务启动......
@echo off
@sc create NapEmail binPath= "%~dp0%NSMPT.WinService.exe"
@net start NapEmail 
@sc config NapEmail  start= AUTO
@sc description NapEmail 这是NapEmail服务
@echo off
@echo.启动完毕！
@pause
