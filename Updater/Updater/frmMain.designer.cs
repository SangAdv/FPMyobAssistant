namespace SAUpdateInstaller
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnNotes = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.lblPoweredBy = new System.Windows.Forms.LinkLabel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlNotes = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.VersionNotes = new SangAdv.Updater.Client.SAUpdaterVersionNotes();
            this.pnlInstall = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.upExec = new SangAdv.Updater.Client.SAUpdaterExecute();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlNotes.SuspendLayout();
            this.pnlInstall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNotes
            // 
            this.btnNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.btnNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotes.ForeColor = System.Drawing.Color.White;
            this.btnNotes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNotes.Location = new System.Drawing.Point(605, 15);
            this.btnNotes.Margin = new System.Windows.Forms.Padding(0);
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.Size = new System.Drawing.Size(88, 24);
            this.btnNotes.TabIndex = 70;
            this.btnNotes.Text = "Release notes";
            this.btnNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNotes.UseVisualStyleBackColor = false;
            this.btnNotes.Click += new System.EventHandler(this.btnNotes_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.Label3.Location = new System.Drawing.Point(39, 10);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(66, 13);
            this.Label3.TabIndex = 69;
            this.Label3.Text = "Powered by:";
            // 
            // lblPoweredBy
            // 
            this.lblPoweredBy.AutoSize = true;
            this.lblPoweredBy.Location = new System.Drawing.Point(39, 23);
            this.lblPoweredBy.Name = "lblPoweredBy";
            this.lblPoweredBy.Size = new System.Drawing.Size(148, 13);
            this.lblPoweredBy.TabIndex = 68;
            this.lblPoweredBy.TabStop = true;
            this.lblPoweredBy.Text = "Sanguine Advantage Updater";
            this.lblPoweredBy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPoweredBy_LinkClicked);
            // 
            // PictureBox2
            // 
            this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
            this.PictureBox2.Location = new System.Drawing.Point(11, 10);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(24, 24);
            this.PictureBox2.TabIndex = 67;
            this.PictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.Label3);
            this.panel1.Controls.Add(this.PictureBox2);
            this.panel1.Controls.Add(this.lblPoweredBy);
            this.panel1.Controls.Add(this.btnNotes);
            this.panel1.Location = new System.Drawing.Point(0, 456);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 50);
            this.panel1.TabIndex = 73;
            // 
            // pnlNotes
            // 
            this.pnlNotes.Controls.Add(this.btnClose);
            this.pnlNotes.Controls.Add(this.label2);
            this.pnlNotes.Controls.Add(this.VersionNotes);
            this.pnlNotes.Location = new System.Drawing.Point(0, 0);
            this.pnlNotes.Name = "pnlNotes";
            this.pnlNotes.Size = new System.Drawing.Size(704, 508);
            this.pnlNotes.TabIndex = 74;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(667, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 77;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 76;
            this.label2.Text = "Release Notes";
            // 
            // VersionNotes
            // 
            this.VersionNotes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionNotes.Location = new System.Drawing.Point(13, 46);
            this.VersionNotes.Name = "VersionNotes";
            this.VersionNotes.Padding = new System.Windows.Forms.Padding(5);
            this.VersionNotes.Size = new System.Drawing.Size(678, 452);
            this.VersionNotes.TabIndex = 75;
            // 
            // pnlInstall
            // 
            this.pnlInstall.Controls.Add(this.lblVersion);
            this.pnlInstall.Controls.Add(this.PictureBox1);
            this.pnlInstall.Controls.Add(this.panel1);
            this.pnlInstall.Controls.Add(this.upExec);
            this.pnlInstall.Location = new System.Drawing.Point(0, 0);
            this.pnlInstall.Name = "pnlInstall";
            this.pnlInstall.Size = new System.Drawing.Size(704, 508);
            this.pnlInstall.TabIndex = 75;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(455, 92);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(43, 17);
            this.lblVersion.TabIndex = 75;
            this.lblVersion.Text = "0.1.0.0";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(179, 19);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(314, 70);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox1.TabIndex = 76;
            this.PictureBox1.TabStop = false;
            // 
            // upExec
            // 
            this.upExec.Cursor = System.Windows.Forms.Cursors.Default;
            this.upExec.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upExec.Location = new System.Drawing.Point(1, 123);
            this.upExec.Name = "upExec";
            this.upExec.Size = new System.Drawing.Size(700, 320);
            this.upExec.TabIndex = 72;
            this.upExec.InstallStarted += new SangAdv.Updater.Client.UpdaterEmptyDelegate(this.upExec_InstallStarted);
            this.upExec.InstallCompleted += new SangAdv.Updater.Client.UpdaterBooleanDelegate(this.upExec_InstallCompleted);
            this.upExec.CloseInstaller += new SangAdv.Updater.Client.UpdaterEmptyDelegate(this.upExec_CloseInstaller);
            this.upExec.ChangeControlBoxStatus += new SangAdv.Updater.Client.UpdaterBooleanDelegate(this.upExec_ChangeControlBoxStatus);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(704, 506);
            this.Controls.Add(this.pnlInstall);
            this.Controls.Add(this.pnlNotes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Installer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlNotes.ResumeLayout(false);
            this.pnlNotes.PerformLayout();
            this.pnlInstall.ResumeLayout(false);
            this.pnlInstall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button btnNotes;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.LinkLabel lblPoweredBy;
        internal System.Windows.Forms.PictureBox PictureBox2;
        private SangAdv.Updater.Client.SAUpdaterExecute upExec;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlNotes;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label label2;
        private SangAdv.Updater.Client.SAUpdaterVersionNotes VersionNotes;
        private System.Windows.Forms.Panel pnlInstall;
        internal System.Windows.Forms.Label lblVersion;
        internal System.Windows.Forms.PictureBox PictureBox1;
    }
}