using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    internal class MABaseControls
    {
        #region Variables

        private LabelControl lblTitle;
        private LabelControl lblMessage;

        #endregion Variables

        #region Constructor

        internal MABaseControls(XtraUserControl control)
        {
            lblTitle = new LabelControl();
            lblMessage = new LabelControl();
            //
            // lblTitle
            //
            lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Location = new System.Drawing.Point(30, 3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(60, 25);
            lblTitle.TabIndex = 21;
            lblTitle.Text = "lblTitle";
            //
            // lblMessage
            //
            lblMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblMessage.Appearance.Options.UseFont = true;
            lblMessage.Location = new System.Drawing.Point(30, control.Height - 30);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new System.Drawing.Size(63, 16);
            lblMessage.TabIndex = 22;
            lblMessage.Text = "lblMessage";
            //Add
            lblTitle.Text = string.Empty;
            lblMessage.Text = string.Empty;
            control.Controls.Add(lblMessage);
            control.Controls.Add(lblTitle);
        }

        #endregion Constructor

        #region Methods

        internal void SetTitle(string title)
        {
            lblTitle.Text = title;
        }

        internal void SetMessage(string message)
        {
            lblMessage.Text = message;
            Application.DoEvents();
        }

        #endregion Methods
    }
}