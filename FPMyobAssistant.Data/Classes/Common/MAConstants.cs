namespace FPMyobAssistant
{
    public class MAConstants
    {
        public static class ReportStorageType
        {
            public static string GrossSales => MAHelpers.SetMAId(1, 2, 0);
            public static string Reptos => MAHelpers.SetMAId(1, 3, 11);
            public static string GrossMargin => MAHelpers.SetMAId(2, 3, 0);
            public static string OperatingCosts => MAHelpers.SetMAId(2, 4, 0);
            public static string TotalCurrentAssets => MAHelpers.SetMAId(4, 1, 0);
            public static string TotalAssets => MAHelpers.SetMAId(4, 3, 0);
            public static string TotalLiabilities => MAHelpers.SetMAId(4, 4, 0);
            public static string OperatingProfit => MAHelpers.SetMAId(2, 6, 0);
        }
    }

    #region Tablenames

    public struct MACTableNames
    {
        public const string UserData = "UserData";
        public const string UpdateData = "UpdateData";
        public const string ReportData = "ReportData";
        public const string AccountData = "AccountData";
        public const string BudgetData = "BudgetData";
        public const string CustomerData = "CustomerData";
        public const string ExclusionData = "ExclusionData";
        public const string SettingData = "SettingData";
    }

    #endregion Tablenames

    #region Partitionnames

    public struct MACPartitionNames
    {
        public const string User = "User";
        public const string Item = "Item";
        public const string ReportStructure = "ReportStructure";
        public const string ReportType = "ReportType";
        public const string MYOBId = "MYOBId";
    }

    #endregion Partitionnames
}