namespace DO
{
    public record Product(
        int Barcode,
        string ProductName,
        Category Category,
        double Price,
        int QuantityStock)
    {
        public Product()
            : this(0, "bbb", Category.Breads, 0.00, 0)
        {
        }
    }
}