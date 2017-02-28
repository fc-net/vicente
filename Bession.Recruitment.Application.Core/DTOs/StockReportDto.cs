namespace Bession.Recruitment.Application.Core.DTOs
{
    public class StockReportDto
    {
        public int TotalQuantity { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public decimal AverageStock { get; set; }
        public string Message { get; set; }
    }
}
