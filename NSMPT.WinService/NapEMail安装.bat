@echo.���Եȣ���������......
@echo off
@sc create NapEmail binPath= "%~dp0%NSMPT.WinService.exe"
@net start NapEmail 
@sc config NapEmail  start= AUTO
@sc description NapEmail ����NapEmail����
@echo off
@echo.������ϣ�
@pause
