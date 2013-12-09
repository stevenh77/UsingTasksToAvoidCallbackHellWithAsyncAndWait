using System;

namespace TaskBasedServices.DTOs
{
    public class TradingDate
    {
        public DateTime TradeDate { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public DateTime? MaturityDate { get; set; }

        public int? Duration { get; set; }
    }
}