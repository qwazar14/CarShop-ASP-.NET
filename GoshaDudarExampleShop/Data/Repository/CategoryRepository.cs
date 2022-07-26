using System.Collections.Generic;
using GoshaDudarExampleShop.Data.Interfaces;
using GoshaDudarExampleShop.Data.Models;

namespace GoshaDudarExampleShop.Data.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationDbContent _applicationDbContent;

        public CategoryRepository(ApplicationDbContent applicationDbContent) => _applicationDbContent = applicationDbContent;
        public IEnumerable<Category> AllCategories => _applicationDbContent.Category;
    }
}