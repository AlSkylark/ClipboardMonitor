using System;
using System.Windows.Forms;

namespace ClipboardMonitor
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            txtKey.Text = CMSettings.Default.Keyword;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            CMSettings.Default.Keyword = txtKey.Text;
            CMSettings.Default.Save();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
