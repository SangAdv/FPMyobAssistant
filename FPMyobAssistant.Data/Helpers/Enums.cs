namespace FPMyobAssistant
{
    public enum MAReportType : int
    {
        ProfitLoss = 1,
        BalanceSheet = 2
    }

    public struct MAUpdateItem
    {
        public const string AccountData = "AccountData";
        public const string BSBudget = "BSBudget";
        public const string CustomerData = "CustomerData";
        public const string DistributorProductAccount = "DistributorProductAccount";
        public const string ExclusionData = "ExclusionData";
        public const string PLBudget = "PLBudget";
        public const string ReportStructure = "ReportStructure";
        public const string Settings = "Settings";
        public const string UpdateData = "UpdateData";
        public const string UserData = "UserData";
    }

    public struct MAUpdateItemVariant
    {
        public const string DHL = "DHL";
        public const string BalanceSheet = "BalanceSheet";
        public const string ProfitLoss = "ProfitLoss";
        public const string All = "";
    }

    public enum MAStatus : int
    {
        Active = 1,
        Cancelled = 2
    }

    public enum MADistributors : int
    {
        API = 1,
        Sigma = 2,
        Symbion = 3,
        CH2 = 4
    }
}