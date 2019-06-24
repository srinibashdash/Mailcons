using System;
using System.IO;
using System.Windows.Forms;

namespace CredentialManager
{
    public partial class Form1 : Form
    {
        const string StartAppBatchFile = "showmymail.bat";
        const string InvokeAppBatchFile = "invokeBotProcess.bat";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CredentialUtil.SetCredentials(txtGmailName.Text, txtGmailUser.Text, txtGmailPwd.Text, CredentialManagement.PersistanceType.LocalComputer);
            CredentialUtil.SetCredentials(txtOutlookName.Text, txtOutlookUser.Text, string.Empty, CredentialManagement.PersistanceType.LocalComputer);
            var fileName = "settings.data";
            if (File.Exists(fileName))
                File.Delete(fileName);
            using (StreamWriter file = new StreamWriter(fileName, true))
            {
                file.WriteLine(txtApplicationPath.Text);
                file.WriteLine(txtReportIssueEmail.Text);
            }
            CreateBatchFiles();
            CreateStartMenuLink();
            MessageBox.Show("Credential Updated in Windows Credential and batch files are generated");
            this.Close();
        }

        private void CreateStartMenuLink()
        {
            //create shortcut to file in startup
            IWshRuntimeLibrary.WshShell wsh = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu) + @"\my messages.lnk") as IWshRuntimeLibrary.IWshShortcut;
            shortcut.Arguments = "";
            shortcut.TargetPath = Environment.CurrentDirectory + @"\" + StartAppBatchFile;
            shortcut.WindowStyle = 1;
            shortcut.Description = "my mesaagessdk";
            shortcut.WorkingDirectory = Environment.CurrentDirectory + @"\";
            //shortcut.IconLocation = "specify icon location";
            shortcut.Save();
        }

        private static void CreateBatchFiles()
        {
            var currentPath = AppContext.BaseDirectory;

            try
            {
                var showmymail = "*UiPath\\app-19.4.2\\UiRobot.exe -f *Main.xaml";
                var invokebot = "*UiPath\\app-19.4.2\\UiRobot.exe -f *Openmail.xaml -input \"{ 'source': '%1', 'subject': 'test'}\"";
                showmymail = showmymail.Replace("*", currentPath);
                invokebot = invokebot.Replace("*", currentPath);
                
                //ShowMyMail batch file generation
                string fileShowMyMail = StartAppBatchFile;
                if (File.Exists(fileShowMyMail)) File.Delete(fileShowMyMail);
                using (StreamWriter sw = File.CreateText(fileShowMyMail))
                {
                    sw.WriteLine("@echo off");
                    sw.WriteLine(showmymail);
                }

                //InvokeBotProcess batch file generation
                string fileBotProcess = InvokeAppBatchFile;
                if (File.Exists(fileBotProcess)) File.Delete(fileBotProcess);
                using (StreamWriter sw = File.CreateText(fileBotProcess))
                {
                    sw.WriteLine("@echo off");
                    //sw.WriteLine("set message=%2");
                    //sw.WriteLine("set message=%message:|=%");
                    //sw.WriteLine("set message=%message:'=%");
                    //sw.WriteLine("set message=%message:\" =%");
                    sw.WriteLine(invokebot);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error while creating batch files \n" + Ex.Message, "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var gmail = CredentialUtil.GetCredential(txtGmailName.Text);
            if(!string.IsNullOrEmpty(gmail))
            {
                var gmailDetail = gmail.Split('|');
                txtGmailUser.Text = gmailDetail[0];
                txtGmailPwd.Text = gmailDetail[1];
            }
            var outlook = CredentialUtil.GetCredential(txtOutlookName.Text);
            if (!string.IsNullOrEmpty(outlook))
            {
                var outlookDetail = outlook.Split('|');
                txtOutlookUser.Text = outlookDetail[0];
            }
        }

        private void txtApplicationPath_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtApplicationPath.Text = openFileDialog1.FileName;
        }
    }
}
