using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using SangAdv.Common.StringExtensions;
using System.Collections.Generic;
using System.Linq;

namespace FPMyobAssistant
{
    public partial class frmChooseParent : XtraForm
    {
        #region Constructor

        internal frmChooseParent(Dictionary<string, string> parentList, string description)
        {
            InitializeComponent();
            lblSelectedAccount.Text = description;
            LoadParentList(parentList);
        }

        #endregion Constructor

        #region Properties

        internal string ParentAccountId { get; private set; } = string.Empty;

        #endregion Properties

        #region Private Methods

        private void LoadParentList(Dictionary<string, string> parentList)
        {
            icbParentAccount.Properties.Items.Clear();

            icbParentAccount.Properties.Items.Add(new ImageComboBoxItem($"0-0000 > Root", "0".AddLeadingZeros(10), 0));

            foreach (var item in parentList.OrderBy(x => x.Key))
            {
                icbParentAccount.Properties.Items.Add(new ImageComboBoxItem($"{item.Key.RemoveLeadingZeros()} > {item.Value}", item.Key, 0));
            }
            icbParentAccount.SelectedIndex = 0;
        }

        private void icbParentAccount_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ParentAccountId = icbParentAccount.EditValue.ToString();
        }

        #endregion Private Methods
    }
}