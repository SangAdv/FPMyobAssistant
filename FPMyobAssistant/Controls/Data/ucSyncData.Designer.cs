namespace FPMyobAssistant
{
    partial class ucSyncData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblUploadMessage = new DevExpress.XtraEditors.LabelControl();
            this.btnUpload = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lblDownloadMessage = new DevExpress.XtraEditors.LabelControl();
            this.btnDownload = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblUploadMessage);
            this.groupControl1.Controls.Add(this.btnUpload);
            this.groupControl1.Location = new System.Drawing.Point(40, 89);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(400, 100);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Upload Data";
            // 
            // lblUploadMessage
            // 
            this.lblUploadMessage.Location = new System.Drawing.Point(15, 38);
            this.lblUploadMessage.Name = "lblUploadMessage";
            this.lblUploadMessage.Size = new System.Drawing.Size(63, 13);
            this.lblUploadMessage.TabIndex = 2;
            this.lblUploadMessage.Text = "labelControl1";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(15, 63);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnReset);
            this.groupControl2.Controls.Add(this.lblDownloadMessage);
            this.groupControl2.Controls.Add(this.btnDownload);
            this.groupControl2.Location = new System.Drawing.Point(40, 205);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(400, 100);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Download Data";
            // 
            // lblDownloadMessage
            // 
            this.lblDownloadMessage.Location = new System.Drawing.Point(15, 36);
            this.lblDownloadMessage.Name = "lblDownloadMessage";
            this.lblDownloadMessage.Size = new System.Drawing.Size(63, 13);
            this.lblDownloadMessage.TabIndex = 3;
            this.lblDownloadMessage.Text = "labelControl2";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(15, 63);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(96, 63);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // ucSyncData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "ucSyncData";
            this.Size = new System.Drawing.Size(1018, 607);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl lblUploadMessage;
        private DevExpress.XtraEditors.SimpleButton btnUpload;
        private DevExpress.XtraEditors.LabelControl lblDownloadMessage;
        private DevExpress.XtraEditors.SimpleButton btnDownload;
        private DevExpress.XtraEditors.SimpleButton btnReset;
    }
}
