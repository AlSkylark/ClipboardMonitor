using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace ClipboardMonitor
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : Form
    {
        private const int SW_MAXIMIZE = 3;
        private const int SW_MINIMIZE = 6;

        [DllImport("User32.dll")]
		protected static extern int SetClipboardViewer(int hWndNewViewer);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);


        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private System.Windows.Forms.RichTextBox txtMain;

		IntPtr nextClipboardViewer;
        private NotifyIcon niClipboardMonitor;
        private ToolStripMenuItem toolStripMenuItem1;
        private ContextMenuStrip ctxtForNICON;
        private IContainer components;

        public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
			nextClipboardViewer = (IntPtr)SetClipboardViewer((int) this.Handle);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			ChangeClipboardChain(this.Handle, nextClipboardViewer);
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtMain = new System.Windows.Forms.RichTextBox();
            this.niClipboardMonitor = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxtForNICON = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtForNICON.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMain
            // 
            this.txtMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMain.Location = new System.Drawing.Point(0, 0);
            this.txtMain.Name = "txtMain";
            this.txtMain.ReadOnly = true;
            this.txtMain.Size = new System.Drawing.Size(337, 23);
            this.txtMain.TabIndex = 0;
            this.txtMain.Text = "-CLIPPBOARD-";
            this.txtMain.WordWrap = false;
            // 
            // niClipboardMonitor
            // 
            this.niClipboardMonitor.ContextMenuStrip = this.ctxtForNICON;
            this.niClipboardMonitor.Icon = ((System.Drawing.Icon)(resources.GetObject("niClipboardMonitor.Icon")));
            this.niClipboardMonitor.Text = "Clipboard Monitor";
            this.niClipboardMonitor.DoubleClick += new System.EventHandler(this.niClipboardMonitor_DoubleClick);
            this.niClipboardMonitor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.niClipboardMonitor_MouseClick);
            // 
            // ctxtForNICON
            // 
            this.ctxtForNICON.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.ctxtForNICON.Name = "ctxtForNICON";
            this.ctxtForNICON.Size = new System.Drawing.Size(181, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Close";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(337, 23);
            this.Controls.Add(this.txtMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Clipboard Monitor Example";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ctxtForNICON.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			// defined in winuser.h
			const int WM_DRAWCLIPBOARD = 0x308;
			const int WM_CHANGECBCHAIN = 0x030D;

			switch(m.Msg)
			{
				case WM_DRAWCLIPBOARD:
					GetClipboardData();
					SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
					break;

				case WM_CHANGECBCHAIN:
					if (m.WParam == nextClipboardViewer)
						nextClipboardViewer = m.LParam;
					else
						SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
					break;

				default:
					base.WndProc(ref m);
					break;
			}	
		}

		void GetClipboardData()		
		{
			try
			{
				IDataObject iData = new DataObject();  
				iData = Clipboard.GetDataObject();

                if (iData.GetDataPresent(DataFormats.Text))
                {
                    //txtMain.Text = (string)iData.GetData(DataFormats.Text);
                    string t = (string)iData.GetData(DataFormats.Text);
                    if (t.IndexOf("LLFADB119") == 0)
                    {
                        t = GetURL(t);
                        IntPtr hwnd = FindWindowByCaption(IntPtr.Zero, "Connect to Server - server - Remote Desktop Connection");
                        ShowWindow(hwnd, SW_MINIMIZE);
                        Process.Start(t);
                    }
                }

            }
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                niClipboardMonitor.Visible = true;
            }
        }

        private void niClipboardMonitor_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            niClipboardMonitor.Visible = false;
        }

        private void niClipboardMonitor_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ctxtForNICON.Show();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private string GetURL(string text)
        {
            text = text.Substring(9);
            if (text.IndexOf("www.") >= 0)
            {
                //nothing, text is fine
            }
            else
            {
                text = text.Insert(0, "www.");
            }
            //if (text.IndexOf("http://") >= 0)
            //{
            //    text = text.Replace("http://", "https://");
            //}
            //else if (text.IndexOf("https://")>=0)
            //{
            //    //nothing, text is fine
            //}
            //else
            //{
            //    text = text.Insert(0, "https://");
            //}
            return text;
        }
    }
}
