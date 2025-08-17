using DalApi;
using DO;
using System.Reflection;
using Tools;

namespace Dal
{
    internal class SaleImplementation : ISale
    {
        public int Create(Sale item)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"insert sale in id:{item.BarcodeSale}"
            );

            Sale sale = item with { BarcodeSale = DataSource.Config.GetCodeSale };
            DataSource.sales.Add(sale);
            return sale.BarcodeSale;
        }

        public Sale? Read(int barcodesale)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"read sale in id: {barcodesale}"
            );

            Sale sale = DataSource.sales.FirstOrDefault(x => x.BarcodeSale == barcodesale);
            if (sale == null)
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"not found sale in id: {barcodesale}"
                );
                throw new DalIdNotFoundException("this code does not exist");
            }
            else
            {
                return sale;
            }
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"read sale"
            );

            Sale s = DataSource.sales.FirstOrDefault(x => filter(x));
            if (s == null)
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"not found sale"
                );
                throw new DalIdNotFoundException("this sale does not exist");
            }
            else
            {
                return s;
            }
        }

        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"read all sales"
            );

            if (filter == null)
            {
                return new List<Sale>(DataSource.sales);
            }
            else
            {
                return DataSource.sales.Where(x => filter(x)).ToList();
            }
        }

        public void Update(Sale item)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"update sale in id:{item.BarcodeSale}"
            );

            Delete(item.BarcodeSale);
            DataSource.sales.Add(item);
        }

        public void Delete(int barcodesale)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"delete sale in id:{barcodesale}"
            );

            Sale sale = Read(barcodesale);
            DataSource.sales.Remove(sale);
        }
    }
}