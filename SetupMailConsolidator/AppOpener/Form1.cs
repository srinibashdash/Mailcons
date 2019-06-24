using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppOpener
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string action, source, subject;
            var fileName = "mail.data";
            using (StreamReader file = new StreamReader(fileName))
            {
                action = file.ReadLine();
                source = file.ReadLine();
                subject = file.ReadLine();
            }
            lblAction.Text = action;
            lblSource.Text = source;
            lblSubject.Text = subject;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
