namespace DalApi
{
    public interface IDal
    {
        Icustomer Customer { get; }
        Iproduct Product { get; }
        ISale Sale { get; }
    }
}
