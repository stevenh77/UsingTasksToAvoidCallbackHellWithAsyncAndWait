namespace TaskBasedServices.Models
{
    public class InvestmentBoundaries
    {
        public string BoundaryCurrency { get; set; }
        public decimal? Minimum { get; set; }
        public decimal? Maximum { get; set; }
    }
}