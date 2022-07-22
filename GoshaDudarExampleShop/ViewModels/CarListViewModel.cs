using System.Collections.Generic;
using GoshaDudarExampleShop.Data.Models;

namespace GoshaDudarExampleShop.ViewModels
{
    public class CarListViewModel
    {
        public IEnumerable<Car> AllCars { get; set; }

        public string currentCategory { get; set; } 
    }
}