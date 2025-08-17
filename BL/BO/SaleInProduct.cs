namespace BO
{
    public class SaleInProduct
    {
        public int SaleId { get; init; }
        public int CountForSale { get; set; }
        public double Price { get; set; }
        public bool IsSaleForAllCustomers { get; set; }
    }
}
