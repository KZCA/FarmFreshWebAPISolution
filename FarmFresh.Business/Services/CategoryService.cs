using FarmFresh.DataAccess;
using FarmFresh.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Business.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetCategoryBySlug(string slug);
        Task<bool> CreateCategory(Category model); 
        Task<bool> UpdateCategory(Category model);
        Task<bool> DeleteCategory(int id);
    }

    public class CategoryService : ICategoryService
    {
        public IUnitOfWork _uow;

        public CategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            var categories = await _uow.CategoryRepo.GetAll();
            return categories;
        }

        public async Task<Category> GetCategoryBySlug(string slug)
        {
            if (!string.IsNullOrEmpty(slug))
            {
                var category =  _uow.CategoryRepo.Query(c=>c.Slug == slug);
                if (category != null)
                {
                    return category;
                }
            }
            return null;
        }
        public async Task<bool> CreateCategory(Category model)
        {
            if (model != null)
            {
                await _uow.CategoryRepo.Add(model);                

                if (_uow.Save() > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public async Task<bool> DeleteCategory(int id)
        {
            if (id > 0)
            {
                var obj = await _uow.CategoryRepo.GetById(id);
                if (obj != null)
                {
                    _uow.CategoryRepo.Delete(obj);
                    //var result = _uow.Save();

                    if (_uow.Save() > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        public async Task<bool> UpdateCategory(Category model)
        {
            if (model != null)
            {
                var obj = await _uow.CategoryRepo.GetById(model.Id);
                if (obj != null)
                {
                    obj.Name = model.Name; 
                    _uow.CategoryRepo.Update(obj);

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
