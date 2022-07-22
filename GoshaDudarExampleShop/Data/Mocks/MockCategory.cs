using System.Collections.Generic;
using GoshaDudarExampleShop.Data.Interfaces;
using GoshaDudarExampleShop.Data.Models;

namespace GoshaDudarExampleShop.Data.Mocks
{
    public class MockCategory : ICategory
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category
                {
                    CategoryName = "Electric Powered",
                    Desc =
                        "An electric car, battery electric car, or all-electric car, is an automobile that is propelled by one or more electric motors"
                },
                new Category
                {
                    CategoryName = "ICE Powered",
                    Desc =
                        "Most ICEs are used in mobile applications and are the primary power supply for vehicles such as cars"
                }
            };
    }
}