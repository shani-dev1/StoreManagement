namespace DO;

public record Sale(
    int BarcodeSale,
    int ProductId,
    int RequiredItems,
    int TotalPrice,
    bool IsCustomersClub,
    DateTime BeginingSale,
    DateTime EndSale)
{
    public Sale():this(111,222,56,0,false,DateTime.Now,DateTime.Now)
    {
        
    }
}
