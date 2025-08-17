using DalApi;
using DO;
using System.Reflection;
using Tools;

namespace Dal
{
    internal class ProductImplementation : Iproduct
    {
        public int Create(Product item)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"insert product in id:{item.Barcode}"
            );

            Product product = item with { Barcode = DataSource.Config.GetCodeProduct };
            DataSource.products.Add(product);
            return product.Barcode;
        }

        public Product? Read(int barcode)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"read product in id: {barcode}"
            );

            Product product = DataSource.products.FirstOrDefault(x => x.Barcode == barcode);
            if (product == null)
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"not found product in id: {barcode}"
                );
                throw new DalIdNotFoundException("this code does not exist");
            }
            else
            {
                return product;
            }
        }

        public Product? Read(Func<Product, bool> filter)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"read product"
            );

            Product p = DataSource.products.FirstOrDefault(x => filter(x));
            if (p == null)
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"not found product"
                );
                throw new DalIdNotFoundException("this product does not exist");
            }
            else
            {
                return p;
            }
        }

        public List<Product> ReadAll(Func<Product, bool>? filter = null)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"read all products"
            );

            if (filter == null)
            {
                return new List<Product>(DataSource.products);
            }
            else
            {
                return DataSource.products.Where(x => filter(x)).ToList();
            }
        }

        public void Update(Product item)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"update product in id:{item.Barcode}"
            );

            Delete(item.Barcode);
            DataSource.products.Add(item);
        }

        public void Delete(int barcode)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"delete product in id:{barcode}"
            );

            Product product = Read(barcode);
            DataSource.products.Remove(product);
        }
    }
}
