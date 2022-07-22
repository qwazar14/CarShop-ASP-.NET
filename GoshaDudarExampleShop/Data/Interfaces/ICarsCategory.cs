using System.Collections.Generic;
using GoshaDudarExampleShop.Data.Models;

namespace GoshaDudarExampleShop.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}