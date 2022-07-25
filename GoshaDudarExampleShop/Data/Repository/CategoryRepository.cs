using System.Collections.Generic;
using GoshaDudarExampleShop.Data.Interfaces;
using GoshaDudarExampleShop.Data.Models;

namespace GoshaDudarExampleShop.Data.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;
        public IEnumerable<Category> AllCategories => _applicationDbContext.Category;
    }
}