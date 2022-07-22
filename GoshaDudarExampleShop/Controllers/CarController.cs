using GoshaDudarExampleShop.Data.Interfaces;
using GoshaDudarExampleShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GoshaDudarExampleShop.Controllers
{
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

        public ViewResult List()
        {
            ViewBag.Title = "Car List";
            var obj = new CarListViewModel
            {
                AllCars = _cars.GetAllCars,
                currentCategory = "Cars"
            };
            return View(obj);
        }
    }
}