namespace FPMyobAssistant
{
    internal enum MAFileType : int
    {
        CSV = 1,
        TXT = 2,
        XLSX = 3
    }

    internal enum MAStartupVariable : int
    {
        CurrentVersion = 1,
        RememberUser = 2,
        User = 3
    }

    internal enum MARowType : int
    {
        Normal = 1,
        SubTotal = 2,
        Total = 3,
        GrandTotal = 4,
        Empty = 5
    }

    internal enum MATrueFalse : int
    {
        True = 1,
        False = 0
    }

    internal enum MAReportIndex : int
    {
        SalesDetail = 0,
        SalesDetailBP = 1,
        PBT = 2,
        CostBreakDown = 3,
        CostBreakDownBP = 4,
        BalanceSheet = 5,
        CashFlow = 6
    }

    internal enum MAReportId : int
    {
        SalesDetail = 1,
        PBT = 2,
        CostBreakDown = 3,
        BalanceSheet = 4,
        CashFlow = 5,
        SalesDetailBP = 6,
        CostBreakDownBP = 7
    }
}