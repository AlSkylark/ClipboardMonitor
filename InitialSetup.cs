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
    }
}
