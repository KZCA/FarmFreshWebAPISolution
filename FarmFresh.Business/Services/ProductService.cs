using FarmFresh.Business.Helper;
using FarmFresh.DataAccess;
using FarmFresh.DataAccess.Data;
using FarmFresh.DataAccess.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Business.Services
{
    public interface IProductService
    {
        Task<PaginatedData<Product>> PaginatedProducts(int pageIndex, int pageSize);
        Task<bool> CreateProduct(Product obj);

        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> GetProductById(int id);
        Task<PaginatedData<Product>> GetProductByCategoryId(int categoryid, int pageIndex, int pageSize);
        Task<PaginatedData<Product>> GetAllByIncude(int pageIndex, int pageSize);

        Task<Product> GetProductBySlug(string slug);

        Task<bool> UpdateProduct(Product obj);

        Task<bool> DeleteProduct(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly ApplicationDBContext _dBContext;
        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<PaginatedData<Product>> PaginatedProducts(int pageIndex, int pageSize)
        {
            var products = await _uow.ProductRepo.GetAll();
            return PaginatedData<Product>.CreateList(products.OrderByDescending(p=>p.Id).ToList(), pageIndex, pageSize);
        }

        public async Task<bool> CreateProduct(Product model)
        {
            if (model != null)
            {
                await _uow.ProductRepo.Add(model);

                var result = _uow.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            if (id > 0)
            {
                var model = await _uow.ProductRepo.GetById(id);
                if (model != null)
                {
                    _uow.ProductRepo.Delete(model);
                    var result = _uow.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var lst = await _uow.ProductRepo.GetAll();
            return lst;
        }

        public async Task<Product> GetProductById(int productId)
        {
            if (productId > 0)
            {
                var obj = await _uow.ProductRepo.GetById(productId);
                if (obj != null)
                {
                    return obj;
                }
            }
            return null;
        }

        public async Task<Product> GetProductBySlug(string slug)
        {
            if (!string.IsNullOrEmpty(slug))
            {
                var obj = _uow.ProductRepo.Query(x=>x.Slug == slug);
                if (obj != null)
                {
                    return obj;
                }
            }
            return null;
        }

        public async Task<PaginatedData<Product>> GetProductByCategoryId(int categoryid, int pageIndex, int pageSize)
		{
			if (categoryid > 0)
			{
				var obj = await _uow.ProductRepo.GetAll(p=>p.CategoryId == categoryid);
				if (obj != null)
				{                    
					return PaginatedData<Product>.CreateList(obj.OrderByDescending(p => p.Id).ToList(), pageIndex, pageSize);
				}
			}
			return null;
		}

        public async Task<PaginatedData<Product>> GetAllByIncude(int pageIndex, int pageSize)
        {
            var obj = _uow.ProductRepo.GetAllByInclude();
            if (obj != null)
            {
                return PaginatedData<Product>.CreateList(obj.OrderByDescending(p => p.Id).ToList(), pageIndex, pageSize);
            }
            return null;
        }

        public async Task<bool> UpdateProduct(Product model)
        {
            if (model != null)
            {
                var product = await _uow.ProductRepo.GetById(model.Id);
                if (product != null)
                {
                    product.Name = model.Name;
                    product.Description = model.Description;
                    product.Category = model.Category;
                    product.Image = model.Image;

                    _uow.ProductRepo.Update(product);

                    var result = _uow.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
