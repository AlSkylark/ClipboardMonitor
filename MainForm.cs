using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Deployment.Application;
using Outlook = Microsoft.Office.Interop.Outlook;
using Word = Microsoft.Office.Interop.Word;

namespace ClipboardMonitor
{
	/// <summary>
	/// This code opens an instance of RDP if one isn't already running, adds an event handle to the rdp process and starts a clipboard monitor in search for a keyword that will 
    /// "tell" it to open the link. Keyword can be changed...
	/// </summary>
	public class MainForm : Form
    {
        private const int SW_MAXIMIZE = 3;
        private ToolStripMenuItem setKeywordToolStripMenuItem;
        private ToolStripMenuItem txtVersion;
        private ToolStripMenuItem setMailKeywordToolStripMenuItem;
        private ToolStripMenuItem setTemplatePathToolStripMenuItem;
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

        private RichTextBox txtMain;

		IntPtr nextClipboardViewer;
        private NotifyIcon niClipboardMonitor;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem setRDPFileToolStripMenuItem;
        private ContextMenuStrip ctxtForNICON;
        private IContainer components;
        private Process[] pname;
        private Process rdp;
        private string keyword, mkeyword;

        public MainForm()
		{

            InitializeComponent();

            //we check if the keyword was set, if it was we assign it to a variable (for ease of use)
            if (CMSettings.Default.Keyword.Length != 0 && CMSettings.Default.MailKeyword.Length != 0)
            {
                keyword = CMSettings.Default.Keyword;
                mkeyword = CMSettings.Default.MailKeyword;

            } else
            {
                MessageBox.Show("No link or mail Keyword set!");
                Close();
            }

            //we find the main rdp process, named mstsc in the process list because windows lol
            pname = Process.GetProcessesByName("mstsc");

            //if we couldn't get the process we initialize it with the path in the settings (so we open rdp) 
            if (pname.Length == 0)
            {
                if (CMSettings.Default.RDPLocation.Length != 0) Process.Start(CMSettings.Default.RDPLocation);
                else { MessageBox.Show("No RDP Location set!"); Close(); }  //OPEN rdp

                pname = Process.GetProcessesByName("mstsc"); //find it again and assign it to rdp p variable
                rdp = pname[0];
            }
            else
            {
                rdp = pname[0];
            }

            //we attach the exit event to our observed process
            //if it finishes we close the link opener too
            rdp.EnableRaisingEvents = true;
            rdp.Exited += new EventHandler(rdp_Exited);
            this.WindowState = FormWindowState.Minimized;
			nextClipboardViewer = (IntPtr)SetClipboardViewer((int) this.Handle);
            
        }

        /// <summary>
        /// Clean up any resources being used. Overriden to change the clipboard.
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
            this.txtVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.setKeywordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setRDPFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setMailKeywordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTemplatePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.txtMain.Text = "You can close the application or minimize it to keep it running.";
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
            this.txtVersion,
            this.setKeywordToolStripMenuItem,
            this.setRDPFileToolStripMenuItem,
            this.setMailKeywordToolStripMenuItem,
            this.setTemplatePathToolStripMenuItem,
            this.toolStripMenuItem1});
            this.ctxtForNICON.Name = "ctxtForNICON";
            this.ctxtForNICON.Size = new System.Drawing.Size(181, 158);
            // 
            // txtVersion
            // 
            this.txtVersion.Enabled = false;
            this.txtVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(180, 22);
            this.txtVersion.Text = "Ver. 1.1.0.7";
            // 
            // setKeywordToolStripMenuItem
            // 
            this.setKeywordToolStripMenuItem.Name = "setKeywordToolStripMenuItem";
            this.setKeywordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setKeywordToolStripMenuItem.Text = "Set Keyword";
            this.setKeywordToolStripMenuItem.Click += new System.EventHandler(this.setKeywordToolStripMenuItem_Click);
            // 
            // setRDPFileToolStripMenuItem
            // 
            this.setRDPFileToolStripMenuItem.Name = "setRDPFileToolStripMenuItem";
            this.setRDPFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setRDPFileToolStripMenuItem.Text = "Set RDP File";
            this.setRDPFileToolStripMenuItem.Click += new System.EventHandler(this.setRDPFileToolStripMenuItem_Click);
            // 
            // setMailKeywordToolStripMenuItem
            // 
            this.setMailKeywordToolStripMenuItem.Name = "setMailKeywordToolStripMenuItem";
            this.setMailKeywordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setMailKeywordToolStripMenuItem.Text = "Set Mail Keyword";
            this.setMailKeywordToolStripMenuItem.Click += new System.EventHandler(this.setMailKeywordToolStripMenuItem_Click);
            // 
            // setTemplatePathToolStripMenuItem
            // 
            this.setTemplatePathToolStripMenuItem.Name = "setTemplatePathToolStripMenuItem";
            this.setTemplatePathToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setTemplatePathToolStripMenuItem.Text = "Set Template Path";
            this.setTemplatePathToolStripMenuItem.Click += new System.EventHandler(this.setTemplatePathToolStripMenuItem_Click);
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
            this.Text = "Link Opener";
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
            //Simple check of the settings to see if the application needs upgrading (still WIP) 
            //and check if the application hasn't been run before
            if (CMSettings.Default.UpgradeRequired == true)
            {
                CMSettings.Default.Upgrade();
                CMSettings.Default.UpgradeRequired = false;
                CMSettings.Default.Save();
            }
            if (CMSettings.Default.InitialSetup == false)
            {
                Application.Run(new InitialSetup());
            }
            else
            {
                Application.Run(new MainForm());
            }
			
		}

		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			// defined in winuser.h
			const int WM_DRAWCLIPBOARD = 0x308;
			const int WM_CHANGECBCHAIN = 0x030D;

            //In a nutshell, this runs everytime the clipboard is updated
            //then executes the "GetClipboardData" method to check the data in the clipboard

            switch (m.Msg)
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
                    //Enable if need to see text...
                    //txtMain.Text = (string)iData.GetData(DataFormats.Text); 
                    

                    string t = (string)iData.GetData(DataFormats.Text);
                    if (t.IndexOf(keyword) == 0)
                    {
                        //we get the clean url
                        t = GetURL(t);
                        
                        IntPtr hwnd = FindWindowByCaption(IntPtr.Zero, rdp.MainWindowTitle);
                        
                        ShowWindow(hwnd, SW_MINIMIZE);
                        Process.Start(t);
                    } 
                    else if (t.IndexOf(mkeyword) == 0)
                    {
                        //we process that string into an object
                        MailInfo mInfo = new MailInfo(t);

                        IntPtr hwnd = FindWindowByCaption(IntPtr.Zero, rdp.MainWindowTitle);

                        //minimize rdp
                        ShowWindow(hwnd, SW_MINIMIZE);

                        //OUTLOOK PROCESS HERE! 
                        //we load the template path
                        string template = CMSettings.Default.TemplateLocation;

                        //here we create an Outlook App instance to create a new mailitem from template
                        Outlook.Application oApp = new Outlook.Application();
                        Outlook.MailItem nMail = oApp.CreateItemFromTemplate(template) as Outlook.MailItem;
                        //Outlook.MailItem nMail = oApp.CreateItemFromTemplate(@"C:\Users\Alex Castro\AppData\Roaming\Microsoft\Templates\Ticket Request.oft") as Outlook.MailItem;

                        nMail.To = mInfo.Email;

                        //after assigning the email to the "To" bit, we open 
                        //a word document to edit the body. Why a word doc? 
                        //Because we lose the template formatting otherwise!
                        Word.Document doc = new Word.Document();
                        doc = nMail.GetInspector.WordEditor as Word.Document;
                        Word.Range fRng = doc.Range();

                        while (fRng.Find.Execute(FindText: "…,"))
                        {
                            fRng.Text = $"{mInfo.Name},";
                            fRng.Collapse(0);
                        }
                        while (fRng.Find.Execute(FindText: "* … *"))
                        {
                            fRng.Text = $"* {mInfo.ID} *";
                            fRng.Collapse(0);
                        }

                        nMail.Display();
                    }
                }

            }
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

        /// <summary>
        /// A simple struct to hold the values of the Mail Link String
        /// </summary>
        private struct MailInfo
        {
            public string Name;
            public string ID;
            public string Email;

            /// <summary>
            /// Processes the clipboard data into each Mail item. By breaking down the string through its indexes.
            /// </summary>
            /// <param name="clipData"></param>
            public MailInfo (string clipData)
            {
                int inxID, inxEM;

                clipData = clipData.Substring(9);
                
                inxID = clipData.IndexOf(CMSettings.Default.IndexID);
                inxEM = clipData.IndexOf(CMSettings.Default.IndexEM);

                Name = clipData.Substring(0, inxID);
                ID = clipData.Substring(inxID + 4, inxEM - (inxID + 4));
                Email = clipData.Substring(inxEM + 4);
                
            }
        }


        /// <summary>
        /// This method returns a cleaned URL string.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string GetURL(string text)
        {
            text = text.Substring(9);
            if (text.IndexOf("www.") >= 0)
            {
                //nothing, text is fine
            }
            else
            {
                if (text.IndexOf("http://") >= 0 || text.IndexOf("https://") >= 0)
                {
                    string which;
                    if (text.IndexOf("http://") >= 0) { which = "http://"; } else { which = "https://"; }
                    int index = text.IndexOf(which);
                    text = text.Insert(index + which.Length, "www.");
                }
                else
                {
                    text = text.Insert(0, "www.");
                }
            }
            return text;
        }

        //EVENTS
        private void rdp_Exited(object sender, EventArgs e)
        {
            //Invokes the Close method of the main app. Because this rdp is apparently outside of the UI thread we gotta use a delegate...
            this.Invoke(new CloseDelegate(Close));
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                niClipboardMonitor.Visible = true;
            }
        }
        public delegate void CloseDelegate(); //Simple delegate to send the Close method...

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

        private void setRDPFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog chooseFile = new SaveFileDialog();
            chooseFile.Title = "Select RDP Location";
            chooseFile.Filter = "RDP Files (*.rdp)|*.rdp";
            chooseFile.OverwritePrompt = false;
            if (chooseFile.ShowDialog() == DialogResult.OK)
            {
                CMSettings.Default.RDPLocation = chooseFile.FileName;
                CMSettings.Default.Save();
            }
        }

        private void setMailKeywordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputForm input = new InputForm();
            input.Show();
            input.setText("Set Mail Keyword:");
            input.setInput(CMSettings.Default.MailKeyword);
        }

        private void setTemplatePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog chooseFile = new SaveFileDialog();
            chooseFile.Title = "Select Template Location";
            chooseFile.Filter = "Outlook Template Files (*.oft)|*.oft";
            chooseFile.InitialDirectory = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Microsoft\Templates";
            chooseFile.OverwritePrompt = false;
            if (chooseFile.ShowDialog() == DialogResult.OK)
            {
                CMSettings.Default.TemplateLocation = chooseFile.FileName;
                CMSettings.Default.Save();
            }
        }

        private void setKeywordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputForm input = new InputForm();
            input.Show();
        }
    }
}
