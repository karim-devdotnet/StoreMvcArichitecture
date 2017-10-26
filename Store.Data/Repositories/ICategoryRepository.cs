using Store.Data.Infrastructure;
using Store.Model;

namespace Store.Data.Repositories
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Category GetCategoryByName(string categoryName);
    }
}