using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class ProductImplementation : IProduct
    {
        private readonly DalApi.IDal _dal = DalApi.Factory.Get;

        int IProduct.Create(Product item)
        {
            try
            {
                return _dal.Product.Create(item.ConvertBoProductToDoProduct());
            }
            catch (DO.DalIdExistException ex)
            {
                throw new BLCodeExistException(ex.Message, ex);
            }
        }

        void IProduct.Delete(int id)
        {
            try
            {
                _dal.Product.Delete(id);
            }
            catch (DO.DalIdNotFoundException ex)
            {
                throw new BLIdNotExistException(ex.Message, ex);
            }
        }

        Product? IProduct.Read(int id)
        {
            try
            {
                DO.Product doRes = _dal.Product.Read(id);
                return doRes.ConvertDoProductToBoProduct();
            }
            catch (DO.DalIdNotFoundException ex)
            {
                throw new BLIdNotExistException(ex.Message, ex);
            }
        }

        Product? IProduct.Read(Func<Product, bool> filter)
        {
            try
            {
                DO.Product product = _dal.Product.Read(c => filter(c.ConvertDoProductToBoProduct()));
                return product.ConvertDoProductToBoProduct();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while reading product by filter", ex);
            }
        }

        List<Product> IProduct.ReadAll(Func<Product, bool>? filter)
        {
            try
            {
                if (filter == null)
                {
                    return _dal.Product.ReadAll()
                        .Select(p => p.ConvertDoProductToBoProduct())
                        .ToList();
                }

                return _dal.Product.ReadAll(p => filter(p.ConvertDoProductToBoProduct()))
                    .Select(p => p.ConvertDoProductToBoProduct())
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while reading all products", ex);
            }
        }

        void IProduct.Update(Product item)
        {
            try
            {
                _dal.Product.Update(item.ConvertBoProductToDoProduct());
            }
            catch (DO.DalIdNotFoundException ex)
            {
                throw new BLIdNotExistException(ex.Message, ex);
            }
        }
    }
}
