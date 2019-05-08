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