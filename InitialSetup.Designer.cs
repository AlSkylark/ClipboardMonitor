namespace ClipboardMonitor
{
    partial class InitialSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialSetup));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.chkDefault = new System.Windows.Forms.CheckBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnOutlook = new System.Windows.Forms.Button();
            this.txtOutlook = new System.Windows.Forms.TextBox();
            this.lblOutlook = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkMailDef = new System.Windows.Forms.CheckBox();
            this.txtMailKey = new System.Windows.Forms.TextBox();
            this.lblMailKey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the Initial Setup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(401, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Link Opener - Clipboard Monitor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Set .RDP File Path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Set Link Keyword:";
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.SystemColors.Control;
            this.txtPath.Enabled = false;
            this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(48, 114);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(365, 22);
            this.txtPath.TabIndex = 4;
            // 
            // txtKey
            // 
            this.txtKey.BackColor = System.Drawing.SystemColors.Control;
            this.txtKey.Enabled = false;
            this.txtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Location = new System.Drawing.Point(48, 218);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(137, 22);
            this.txtKey.TabIndex = 5;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(429, 110);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(80, 31);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(277, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "(Recommended)";
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.Checked = true;
            this.chkDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDefault.Location = new System.Drawing.Point(195, 220);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(88, 19);
            this.chkDefault.TabIndex = 8;
            this.chkDefault.Text = "Use default";
            this.chkDefault.UseVisualStyleBackColor = true;
            this.chkDefault.Click += new System.EventHandler(this.chkDefault_Click);
            // 
            // btnDone
            // 
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(233, 301);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(80, 35);
            this.btnDone.TabIndex = 9;
            this.btnDone.Text = "Finish";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnOutlook
            // 
            this.btnOutlook.Location = new System.Drawing.Point(429, 162);
            this.btnOutlook.Name = "btnOutlook";
            this.btnOutlook.Size = new System.Drawing.Size(80, 31);
            this.btnOutlook.TabIndex = 12;
            this.btnOutlook.Text = "Browse";
            this.btnOutlook.UseVisualStyleBackColor = true;
            this.btnOutlook.Click += new System.EventHandler(this.btnOutlook_Click);
            // 
            // txtOutlook
            // 
            this.txtOutlook.BackColor = System.Drawing.SystemColors.Control;
            this.txtOutlook.Enabled = false;
            this.txtOutlook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutlook.Location = new System.Drawing.Point(48, 166);
            this.txtOutlook.Name = "txtOutlook";
            this.txtOutlook.Size = new System.Drawing.Size(365, 22);
            this.txtOutlook.TabIndex = 11;
            // 
            // lblOutlook
            // 
            this.lblOutlook.AutoSize = true;
            this.lblOutlook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutlook.Location = new System.Drawing.Point(14, 142);
            this.lblOutlook.Name = "lblOutlook";
            this.lblOutlook.Size = new System.Drawing.Size(204, 20);
            this.lblOutlook.TabIndex = 10;
            this.lblOutlook.Text = "Set Outlook Template Path:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(277, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "(Recommended)";
            // 
            // chkMailDef
            // 
            this.chkMailDef.AutoSize = true;
            this.chkMailDef.Checked = true;
            this.chkMailDef.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMailDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMailDef.Location = new System.Drawing.Point(195, 272);
            this.chkMailDef.Name = "chkMailDef";
            this.chkMailDef.Size = new System.Drawing.Size(88, 19);
            this.chkMailDef.TabIndex = 16;
            this.chkMailDef.Text = "Use default";
            this.chkMailDef.UseVisualStyleBackColor = true;
            this.chkMailDef.CheckedChanged += new System.EventHandler(this.chkMailDef_CheckedChanged);
            // 
            // txtMailKey
            // 
            this.txtMailKey.BackColor = System.Drawing.SystemColors.Control;
            this.txtMailKey.Enabled = false;
            this.txtMailKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMailKey.Location = new System.Drawing.Point(48, 270);
            this.txtMailKey.Name = "txtMailKey";
            this.txtMailKey.Size = new System.Drawing.Size(137, 22);
            this.txtMailKey.TabIndex = 14;
            // 
            // lblMailKey
            // 
            this.lblMailKey.AutoSize = true;
            this.lblMailKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMailKey.Location = new System.Drawing.Point(13, 245);
            this.lblMailKey.Name = "lblMailKey";
            this.lblMailKey.Size = new System.Drawing.Size(134, 20);
            this.lblMailKey.TabIndex = 13;
            this.lblMailKey.Text = "Set Mail Keyword:";
            // 
            // InitialSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 349);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkMailDef);
            this.Controls.Add(this.txtMailKey);
            this.Controls.Add(this.lblMailKey);
            this.Controls.Add(this.btnOutlook);
            this.Controls.Add(this.txtOutlook);
            this.Controls.Add(this.lblOutlook);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkDefault);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InitialSetup";
            this.Text = "Initial Setup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InitialSetup_FormClosing);
            this.Load += new System.EventHandler(this.InitialSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDefault;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnOutlook;
        private System.Windows.Forms.TextBox txtOutlook;
        private System.Windows.Forms.Label lblOutlook;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkMailDef;
        private System.Windows.Forms.TextBox txtMailKey;
        private System.Windows.Forms.Label lblMailKey;
    }
}