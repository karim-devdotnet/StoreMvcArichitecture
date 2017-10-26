using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _CategorysRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public CategoryService(ICategoryRepository categorysRepository, IUnitOfWork unitOfWork)
        {
            _CategorysRepository = categorysRepository;
            _UnitOfWork = unitOfWork;
        }


        public IEnumerable<Category> GetCategories(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _CategorysRepository.GetAll();
            else
                return _CategorysRepository.GetAll().Where(c => c.Name == name);
        }

        public Category GetCategory(int id)
        {
            var category = _CategorysRepository.GetById(id);
            return category;
        }

        public Category GetCategory(string name)
        {
            var category = _CategorysRepository.GetCategoryByName(name);
            return category;
        }

        public void CreateCategory(Category category)
        {
            _CategorysRepository.Add(category);
        }

        public void SaveCategory()
        {
            _UnitOfWork.Commit();
        }
    }
}
