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

        public void setText(string newText)
        {
            label1.Text = newText;
        }

        public void setInput(string newInput)
        {
            txtKey.Text = newInput;
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            txtKey.Text = CMSettings.Default.Keyword;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (label1.Text.IndexOf("Link") != 0) CMSettings.Default.Keyword = txtKey.Text;
            else CMSettings.Default.MailKeyword = txtKey.Text;

            CMSettings.Default.Save();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
