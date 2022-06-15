using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Betsson_Case.Model
{
    public class CsvModel
    {
        [Key]
        [Name("Order ID")]
        public int OrderID { get; set; }
        [Name("Country")]
        public string? Country { get; set; }
        [Name("Item Type")]
        public string? ItemType { get; set; }
        [Name("Order Date")]
        public DateTime OrderDate { get; set; }
        [Name("Order Priority")]
        public string? OrderPriority { get; set; }
        [Name("Region")]
        public string? Region { get; set; }
        [Name("Sales Channel")]
        public string? SalesChannel { get; set; }
        [Name("Ship Date")]
        public DateTime ShipDate { get; set; }
        [Name("Total Cost")]
        public double TotalCost { get; set; }
        [Name("Total Profit")]
        public double TotalProfit { get; set; }
        [Name("Total Revenue")]
        public double TotalRevenue { get; set; }
        [Name("Unit Cost")]
        public double UnitCost { get; set; }
        [Name("Unit Price")]
        public double UnitPrice { get; set; }
        [Name("Units Sold")]
        public int UnitsSold { get; set; }
    }
}
