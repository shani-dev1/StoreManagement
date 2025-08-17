namespace BO
{
    public class ProductInOrder
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public double BasePrice { get; set; }
        public int AmountOfOrder { get; set; }
        public List<SaleInProduct> SalesOfProduct { get; set; } = new List<SaleInProduct>();
        public double TotalPrice { get; set; }
    }
}
