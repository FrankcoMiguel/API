using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IProductService
    {
        bool Add(Product model);
        bool Update(Product model);
        bool Delete(int id);
        IEnumerable<Product> GetAll(Product model);


    }
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _productDbContext;

        public ProductService(ProductDbContext productDbcontext)
        {

            productDbcontext = _productDbContext;

        }

        public bool Add(Product model)
        {

            try
            {
                _productDbContext.Add(model);
                _productDbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                return false;

            }

            return true;
        }


        public bool Update(Product model)
        {

            try
            {

                var originalModel = _productDbContext.Product.Single(x => x.ProductID == model.ProductID);

                originalModel.Name = model.Name;
                originalModel.Cost = model.Cost;
                originalModel.Quantity = model.Quantity;

                _productDbContext.Update(model);
                _productDbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                return false;

            }

            return true;
        }


        public bool Delete(int id)
        {

            try
            {
                _productDbContext.Remove(new Product { ProductID = id}).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _productDbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                return false;

            }

            return true;
        }


        public IEnumerable<Product> GetAll(Product model)
        {

            var result = new List<Product>();

            try
            {

                result = _productDbContext.Product.ToList();

            }
            catch (System.Exception)
            {

            }

            return result
        }




    }
}
