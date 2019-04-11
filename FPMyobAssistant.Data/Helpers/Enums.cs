namespace FPMyobAssistant
{
    public enum MAReportType : int
    {
        ProfitLoss = 1,
        BalanceSheet = 2
    }

    public struct MAUpdateItem
    {
        public const string CustomerData = "CustomerData";
        public const string PLBudget = "PLBudget";
        public const string BSBudget = "BSBudget";
        public const string Accounts = "Accounts";
        public const string ReportStructure = "ReportStructure";
        public const string ImportExclusions = "ImportExclusions";
        public const string Settings = "Settings";
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