using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using static BO.Tools;

namespace BlImplementation
{
    internal class SaleImplementation : ISale
    {
        private readonly DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Sale item)
        {
            try
            {
                return _dal.Sale.Create(item.ConvertBoSaleToDoSale());
            }
            catch (DO.DalIdExistException ex)
            {
                throw new BLCodeExistException(ex.Message, ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _dal.Sale.Delete(id);
            }
            catch (DO.DalIdNotFoundException ex)
            {
                throw new BLIdNotExistException(ex.Message, ex);
            }
        }

        public BO.Sale? Read(int id)
        {
            try
            {
                return _dal.Sale.Read(id).ConvertDoSaleToBoSale();
            }
            catch (DO.DalIdNotFoundException ex)
            {
                throw new BLIdNotExistException(ex.Message, ex);
            }
        }

        public BO.Sale? Read(Func<BO.Sale, bool> filter)
        {
            try
            {
                DO.Sale doSale = _dal.Sale.Read(s => filter(s.ConvertDoSaleToBoSale()));
                return doSale.ConvertDoSaleToBoSale();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while reading sale by filter", ex);
            }
        }

        public List<BO.Sale> ReadAll(Func<BO.Sale, bool>? filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return _dal.Sale.ReadAll()
                        .Select(s => s.ConvertDoSaleToBoSale())
                        .ToList();
                }

                return _dal.Sale.ReadAll(s => filter(s.ConvertDoSaleToBoSale()))
                    .Select(s => s.ConvertDoSaleToBoSale())
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while reading all sales", ex);
            }
        }

        public void Update(BO.Sale item)
        {
            try
            {
                _dal.Sale.Update(item.ConvertBoSaleToDoSale());
            }
            catch (DO.DalIdNotFoundException ex)
            {
                throw new BLIdNotExistException(ex.Message, ex);
            }
        }
    }
}
