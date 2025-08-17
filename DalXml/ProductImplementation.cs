using DalApi;
using DalXml;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Tools;

namespace Dal
{
    internal class ProductImplementation : Iproduct
    {
        private const string filePath = @"..\xml\products.xml";
        private const string PRODUCT = "Product";
        private const string PRODUCTID = "barcode";
        private const string PRODUCTNAME = "productName";
        private const string CATEGORY = "category";
        private const string PRICE = "price";
        private const string QUANTITYONSTOCK = "quantityInStock";

        public int Create(Product item)
        {
            try
            {
                int nextId = Config.CodeProduct;

                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"Insert product with id: {nextId}");

                XElement productXml = XElement.Load(filePath);
                XElement arrayOfProduct = productXml;

                if (arrayOfProduct == null)
                    throw new Exception("Root element 'ArrayOfProduct' not found in XML.");

                if (productXml.Descendants(PRODUCTID).Any(p => int.Parse(p.Value) == nextId))
                    throw new DalIdExistException($"Product with id {nextId} already exists.");

                arrayOfProduct.Add(new XElement(PRODUCT,
                    new XElement(PRODUCTID, nextId),
                    new XElement(PRODUCTNAME, item.ProductName),
                    new XElement(PRICE, item.Price),
                    new XElement(QUANTITYONSTOCK, item.QuantityStock),
                    new XElement(CATEGORY, item.Category.ToString())
                ));

                productXml.Save(filePath);

                return item.Barcode;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"Exception: {ex.Message}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"Delete product with id: {id}");

                XElement productXml = XElement.Load(filePath);
                var productElem = productXml.Descendants(PRODUCTID).FirstOrDefault(p => int.Parse(p.Value) == id)?.Parent;

                if (productElem == null)
                    throw new DalIdNotFoundException($"Product with id {id} not found.");

                productElem.Remove();
                productXml.Save(filePath);
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"Exception: {ex.Message}");
                throw;
            }
        }

        public Product? Read(int barcode)
        {
            try
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"Read product with id: {barcode}");

                XElement productXml = XElement.Load(filePath);
                var xml = productXml.Descendants(PRODUCTID).FirstOrDefault(p => int.Parse(p.Value) == barcode)?.Parent;

                if (xml == null)
                    throw new DalIdNotFoundException($"Product with id {barcode} not found.");

                return new Product(
                    int.Parse(xml.Element(PRODUCTID).Value),
                    xml.Element(PRODUCTNAME).Value,
                    (Category)Enum.Parse(typeof(Category), xml.Element(CATEGORY).Value),
                    double.Parse(xml.Element(PRICE).Value),
                    int.Parse(xml.Element(QUANTITYONSTOCK).Value)
                );
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"Exception: {ex.Message}");
                throw;
            }
        }

        public Product? Read(Func<Product, bool> filter)
        {
            try
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    "Read product with filter");

                XElement productXml = XElement.Load(filePath);
                var products = productXml.Descendants(PRODUCT)
                    .Select(p => new Product(
                        int.Parse(p.Element(PRODUCTID).Value),
                        p.Element(PRODUCTNAME).Value,
                        (Category)Enum.Parse(typeof(Category), p.Element(CATEGORY).Value),
                        double.Parse(p.Element(PRICE).Value),
                        int.Parse(p.Element(QUANTITYONSTOCK).Value)
                    ));

                return products.FirstOrDefault(filter);
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"Exception: {ex.Message}");
                throw;
            }
        }

        public List<Product> ReadAll(Func<Product, bool>? filter = null)
        {
            try
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    "Read all products");

                XElement productXml = XElement.Load(filePath);
                var products = productXml.Descendants(PRODUCT)
                    .Select(p => new Product(
                        int.Parse(p.Element(PRODUCTID).Value),
                        p.Element(PRODUCTNAME).Value,
                        (Category)Enum.Parse(typeof(Category), p.Element(CATEGORY).Value),
                        double.Parse(p.Element(PRICE).Value),
                        int.Parse(p.Element(QUANTITYONSTOCK).Value)
                    )).ToList();

                return filter != null ? products.Where(filter).ToList() : products;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"Exception: {ex.Message}");
                throw;
            }
        }

        public void Update(Product item)
        {
            try
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"Update product with id: {item.Barcode}");

                XElement productXml = XElement.Load(filePath);
                var s = productXml.Descendants(PRODUCTID).FirstOrDefault(id => int.Parse(id.Value) == item.Barcode)?.Parent;

                if (s == null)
                    throw new DalIdNotFoundException($"Product with id {item.Barcode} not found.");

                s.Element(PRICE).SetValue(item.Price);
                s.Element(PRODUCTNAME).SetValue(item.ProductName);
                s.Element(QUANTITYONSTOCK).SetValue(item.QuantityStock);
                s.Element(CATEGORY).SetValue(item.Category.ToString());

                productXml.Save(filePath);
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"Exception: {ex.Message}");
                throw;
            }
        }
    }
}