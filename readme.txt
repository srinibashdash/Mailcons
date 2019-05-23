##### readme
Mail Consolidator is POC focusing on reducing the unproductive time going for digital distraction.
Mails is one of the digital distraction which is essential part of our life but checking mails leads to distraction.
Mail Consolidator after configuration can recollect your unread mails and present in conslidated categorized single view.

##### how to configure
There is a CredentialManager.exe file which will do 
1. mail credential setup in window credential 
2. generate some batch files to make it run
3. create my message.lnk in common start menu folder to make this application voice initiated by Cortana

##### components of application
CsvReader.exe : Viewer of consolidated data
CredentialManager.exe : Application configuration utility
RPA application which 
	Poplulate the mail data in background from different mail sources 
	Invoke relavent application

##### how to start application
Manually by clicking on showmymail.bat
OR
You can start the application by voice invocation using Cortana so no need to go to folder. For this your Cortana should be working with voice
hi cortana - to initiate cortana
play my message - this will initiate bot with our application

