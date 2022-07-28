using System;
using System.Collections.Generic;
using System.Linq;
using GoshaDudarExampleShop.Data.Interfaces;
using GoshaDudarExampleShop.Data.Models;
using GoshaDudarExampleShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GoshaDudarExampleShop.Controllers
{
    [Route("Cars/List")]
    public class CarController : Controller
    {
        // // GET
        // public IActionResult Index()
        // {
        //     return View();
        // }
        private readonly ICar _cars;
        private readonly ICategory _categories;

        public CarController(ICar cars, ICategory categories)
        {
            _cars = cars;
            _categories = categories;
        }

        [Route("")]
        [Route("{category}")]
        public ViewResult List(string category)
        {
            string _category = string.Empty;
            IEnumerable<Car> cars = null;
            var currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                cars = _cars.GetAllCars.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _cars.GetAllCars.Where(i => i.Category.CategoryName.Equals("Электромобиль"))
                        .OrderBy(i => i.Id);
                }
                else if (string.Equals("petrol", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _cars.GetAllCars.Where(i => i.Category.CategoryName.Equals("ДВС автомобиль"))
                        .OrderBy(i => i.Id);
                }

                currentCategory = _category;
            }

            var carObj = new CarListViewModel
            {
                AllCars = cars,
                currentCategory = currentCategory
            };
            return View(carObj);
        }
    }
}