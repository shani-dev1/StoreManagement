using DalApi;

namespace Dal
{
    internal sealed class DalList: IDal
    {
        public Icustomer Customer => new CustomerImplementation();
        public Iproduct Product => new ProductImplementation();
        public ISale Sale=> new SaleImplementation();
        
        private static readonly DalList instance = new DalList();
        public static DalList Instance
        {
            get { return instance; }
        }
        private DalList()
        {
            
        }
    }
}
