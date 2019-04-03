namespace FPMyobAssistant
{
    internal class MAReportOptions
    {
        public bool IncludePLYtd { get; set; }
        public string PeriodHeading { get; set; } = string.Empty;
        public string YTDPeriodHeading { get; set; } = string.Empty;
        public bool ShowSpaces { get; set; }
        public bool IncludeBSheetBudget { get; set; }
        public bool IncludeBSheetLastYear { get; set; }
    }
}