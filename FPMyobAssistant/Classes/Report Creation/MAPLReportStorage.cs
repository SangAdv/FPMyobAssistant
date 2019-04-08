using System.Data;

namespace FPMyobAssistant
{
    internal class MAPLReportStorage
    {
        #region Properties

        public DataTable ReportData { get; private set; } = new DataTable();

        #endregion Properties

        #region Constructor

        public MAPLReportStorage()
        {
            ReportData.Columns.Add(new DataColumn("Description", typeof(string)));
            ReportData.Columns.Add(new DataColumn("RowType", typeof(int)));
            ReportData.Columns.Add(new DataColumn("Actual", typeof(float)));
            ReportData.Columns.Add(new DataColumn("Budget", typeof(float)));
            ReportData.Columns.Add(new DataColumn("$ Var", typeof(float)));
            ReportData.Columns.Add(new DataColumn("% Var", typeof(float)));
            ReportData.Columns.Add(new DataColumn("Growth %", typeof(float)));
        }

        #endregion Constructor

        #region Methods

        internal void AddDataRow(string description, MARowType rowType, float actualValue, float budgetValue, float previousActualValue)
        {
            var dataRow = ReportData.NewRow();

            dataRow["Description"] = description;
            dataRow["RowType"] = (int)rowType;

            dataRow["Actual"] = actualValue;
            dataRow["Budget"] = budgetValue;

            dataRow["$ Var"] = actualValue - budgetValue;
            dataRow["% Var"] = budgetValue == 0 ? 0 : actualValue / budgetValue;

            dataRow["Growth %"] = previousActualValue == 0 ? 0 : (actualValue - previousActualValue) / previousActualValue;

            ReportData.Rows.Add(dataRow);
        }

        internal void AddDataRow(string description, MARowType rowType, MAPLStorageItem value)
        {
            AddDataRow(description, rowType, value.ActualValue, value.BudgetValue, value.PreviousActualValue);
        }

        internal void AddEmptyRow()
        {
            AddDataRow("", MARowType.Empty, 0, 0, 0);
        }

        #endregion Methods
    }
}