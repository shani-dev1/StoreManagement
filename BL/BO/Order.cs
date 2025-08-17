namespace BO
{
    public class Order
    {
        public bool IsFevorite { get; set; }
        public List<ProductInOrder> ProductsInOrder { get; set; }=new List<ProductInOrder>();
        public double TotalPrice { get; set; }
    }
}
