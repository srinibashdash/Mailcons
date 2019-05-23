using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CsvReader
{
    public partial class Form1 : Form
    {
        DateTime startTime;
        public Form1()
        {
            InitializeComponent();
        }

        int runningIds = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //Populate data from CSV file
                var dt = ReadCsvFile();

                //Populate all datarow collection for categorization
                var bankRows = dt.Select("Sender like '%bank%'").ToList().ToArray();
                var dueDateRows = dt.Select("Subject like '%expiry%' or Subject like '%due%' or Subject like '%appointment%'");
                var urgentRows = dt.Select("Subject like '%urgent%'");
                var highImportance = dt.Select("Importance = '2'");
                var remainRows = dt.Select().ToList();
                RemoveRows(remainRows, bankRows);
                RemoveRows(remainRows, dueDateRows);
                RemoveRows(remainRows, urgentRows);
                RemoveRows(remainRows, highImportance);

                // start off by adding a base treeview node
                TreeNode mainNode = new TreeNode();
                mainNode.Name = "mainNode";
                mainNode.Text = "Consolidated Mails";
                treeView1.Nodes.Add(mainNode);

                //Add new root nodes
                AddCategoryNodes(bankRows, mainNode, "Bank Mails");
                AddCategoryNodes(dueDateRows, mainNode, "Take care of these");
                AddCategoryNodes(urgentRows, mainNode, "Urgent Mails");
                AddCategoryNodes(highImportance, mainNode, "High Importance Mails");
                AddCategoryNodes(remainRows.ToArray(), mainNode, "Remaining Unread Mails", true);
                treeView1.ExpandAll();

                treeView1.Width = treeView1.Width + 1;
                startTime = DateTime.Now;
                Text = Text + " Started From " + startTime.ToString("dd-MMM-yyyy hh:mm:ss");
                timer1.Tick += Timer1_Tick;
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during start of view \n" + ex.Message);
                Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var timeSpan = DateTime.Now - startTime;
            lblRunningFrom.Text = "Open from " + timeSpan.Minutes + " min " + timeSpan.Seconds % 60 + " sec";
        }

        private void AddCategoryNodes(DataRow[] bankRows, TreeNode mainNode, string title, bool makeSourceCategory = false)
        {
            TreeNode nod = new TreeNode(title);
            mainNode.Nodes.Add(nod);

            if(makeSourceCategory)
            {
                var AllMailSource = bankRows.AsEnumerable()
             .Select(r => r.Field<string>("Source")) // select only wellbore string value
             .Distinct() // take only unique items
             .ToList();

                foreach (var item in AllMailSource)
                {
                    var rows = bankRows.Where(r => r.Field<string>("Source") == item);
                    TreeNode sourceNode = new TreeNode(item);
                    nod.Nodes.Add(sourceNode);
                    foreach (var row in rows)
                        CreateNewNodeFromRow(row, sourceNode);
                }
            }
            else
                foreach (var row in bankRows)
                    CreateNewNodeFromRow(row, nod);

            
        }

        private void CreateNewNodeFromRow(DataRow row, TreeNode treeNode)
        {
            TreeNode node = new TreeNode();
            node.Name = runningIds++.ToString();
            node.Text = string.Concat(row.ItemArray[0].ToString(), " ", row.ItemArray[1], " Sent by [", row.ItemArray[3], "] On ", row.ItemArray[4]);
            node.Tag = string.Concat(row.ItemArray[0].ToString(), ",", row.ItemArray[1].ToString(), ",", row.ItemArray[2].ToString(), ",", row.ItemArray[3].ToString(), ",", row.ItemArray[4].ToString(), ",");
            treeNode.Nodes.Add(node);
        }

        private static void RemoveRows(List<DataRow> allRows, DataRow[] bankRows)
        {
            foreach (var row in bankRows)
            {
                try
                {
                    var index = allRows.IndexOf(row);
                    if(index >= 0)
                        allRows.RemoveAt(index);
                }
                catch (Exception)
                {
                }
            }
        }

        public DataTable ReadCsvFile()
        {

            DataTable dtCsv = new DataTable();
            string Fulltext;
            var FileSaveWithPath = "data.csv";
            using (StreamReader sr = new StreamReader(FileSaveWithPath))
            {
                while (!sr.EndOfStream)
                {
                    Fulltext = sr.ReadToEnd().ToString(); //read full file text  
                    string[] rows = Fulltext.Split('\n'); //split full file text into rows  
                    for (int i = 0; i < rows.Count() - 1; i++)
                    {
                        string[] rowValues = rows[i].Split(','); //split each row with comma to get individual values  
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < rowValues.Count(); j++)
                                {
                                    dtCsv.Columns.Add(rowValues[j]); //add headers  
                                }
                            }
                            else
                            {
                                DataRow dr = dtCsv.NewRow();
                                for (int k = 0; k < rowValues.Count(); k++)
                                {
                                    try
                                    {
                                        dr[k] = rowValues[k].ToString();
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                                dtCsv.Rows.Add(dr); //add other rows  
                            }
                        }
                    }
                }
            }
            return dtCsv;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Tag != null)
            {
                var data = e.Node.Tag.ToString().Split(',');
                txtSource.Text = data[0];
                txtSubject.Text = data[1];
                txtSender.Text = data[3];
                txtReceivedOn.Text = data[4];
            }
        }

        private void treeView1_Resize(object sender, EventArgs e)
        {
            try
            {
                treeView1.Font = new System.Drawing.Font(treeView1.Font.FontFamily.Name, treeView1.Size.Width / 70);
                groupBox1.Font = new System.Drawing.Font(treeView1.Font.FontFamily.Name, treeView1.Size.Width / 70);
                //groupBox1.Width = treeView1.Size.Width / 5;
            }
            catch (Exception)
            {

            }
            
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSource.Text)) return;
            var arg = txtSource.Text + " \"" + txtSubject.Text + "\"";

            using (Process myProcess = new Process())
            {
                //myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "invokeBotProcess.bat";
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                myProcess.StartInfo.Arguments = arg;
                myProcess.Start();

            }
        }
    }
}
