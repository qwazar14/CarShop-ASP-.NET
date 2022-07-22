using System.Collections.Generic;
using GoshaDudarExampleShop.Data.Models;

namespace GoshaDudarExampleShop.Data.Interfaces
{
    public interface ICategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}