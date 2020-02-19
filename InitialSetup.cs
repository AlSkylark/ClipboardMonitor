using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardMonitor
{
    public partial class InitialSetup : Form
    {
        public InitialSetup()
        {
            InitializeComponent();
        }

        private void InitialSetup_Load(object sender, EventArgs e)
        {
            txtKey.Text = CMSettings.Default.Keyword;
            txtMailKey.Text = CMSettings.Default.MailKeyword;
        }

        private void chkDefault_Click(object sender, EventArgs e)
        {
            if (chkDefault.Checked == true)
            {
                txtKey.BackColor = SystemColors.Control;
                txtKey.Enabled = false;
            }
            else
            {
                txtKey.BackColor = SystemColors.Window;
                txtKey.Enabled = true;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            CMSettings.Default.Keyword = txtKey.Text;
            CMSettings.Default.RDPLocation = txtPath.Text;
            CMSettings.Default.MailKeyword = txtMailKey.Text;
            CMSettings.Default.TemplateLocation = txtOutlook.Text;
            CMSettings.Default.InitialSetup = true;

            CMSettings.Default.Save();
            Application.Restart();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog chooseFile = new SaveFileDialog();
            chooseFile.Title = "Select RDP Location";
            chooseFile.Filter = "RDP Files (*.rdp)|*.rdp";
            chooseFile.OverwritePrompt = false;
            if (chooseFile.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = chooseFile.FileName;
            }
        }

        private void btnOutlook_Click(object sender, EventArgs e)
        {
            SaveFileDialog chooseFile = new SaveFileDialog();
            chooseFile.Title = "Select Template Location";
            chooseFile.Filter = "Outlook Template Files (*.oft)|*.oft";
            chooseFile.InitialDirectory = @"C:\Users\%USERNAME%\AppData\Roaming\Microsoft\Templates";
            chooseFile.OverwritePrompt = false;
            if (chooseFile.ShowDialog() == DialogResult.OK)
            {
                txtOutlook.Text = chooseFile.FileName;
            }
        }

        private void chkMailDef_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMailDef.Checked == true)
            {
                txtMailKey.BackColor = SystemColors.Control;
                txtMailKey.Enabled = false;
            }
            else
            {
                txtMailKey.BackColor = SystemColors.Window;
                txtMailKey.Enabled = true;
            }
        }
    }
}
