using System.Data;

namespace FPMyobAssistant
{
    internal class MABSReportStorage
    {
        #region Properties

        public DataTable ReportData { get; private set; } = new DataTable();

        #endregion Properties

        #region Constructor

        public MABSReportStorage()
        {
            ReportData.Columns.Add(new DataColumn("Description", typeof(string)));
            ReportData.Columns.Add(new DataColumn("RowType", typeof(int)));
            ReportData.Columns.Add(new DataColumn("Actual", typeof(float)));
            ReportData.Columns.Add(new DataColumn("Prev Actual", typeof(float)));
            ReportData.Columns.Add(new DataColumn("Budget", typeof(float)));
        }

        #endregion Constructor

        #region Methods

        internal void AddDataRow(string description, MARowType rowType, float actualValue, float previousActualValue, float budgetValue)
        {
            var dataRow = ReportData.NewRow();

            dataRow["Description"] = description;
            dataRow["RowType"] = (int)rowType;
            dataRow["Actual"] = actualValue;
            dataRow["Prev Actual"] = previousActualValue;
            dataRow["Budget"] = budgetValue;

            ReportData.Rows.Add(dataRow);
        }

        internal void AddDataRow(string description, MARowType rowType, MABSStorageItem value)
        {
            AddDataRow(description, rowType, value.ActualValue, value.PreviousActualValue, value.BudgetValue);
        }

        internal void AddEmptyRow()
        {
            AddDataRow("", MARowType.Empty, 0, 0, 0);
        }

        #endregion Methods
    }
}