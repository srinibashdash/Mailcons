@echo off

set message=%2

set message=%message:|=%
set message=%message:'=%
set message=%message:"=%


C:\Users\Dell\AppData\Local\UiPath\app-19.4.2\UiRobot.exe -f C:\Users\Dell\Desktop\MailConsolidator\Openmail.xaml -input "{'source': '%1', 'subject': '%message%'}"

