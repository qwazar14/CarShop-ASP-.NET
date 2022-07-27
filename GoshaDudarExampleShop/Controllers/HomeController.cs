using System.Linq;
using GoshaDudarExampleShop.Data.Interfaces;
using GoshaDudarExampleShop.Data.Models;
using GoshaDudarExampleShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GoshaDudarExampleShop.Controllers;

public class HomeController : Controller
{
    private readonly ICar _carRepository;

    public HomeController(ICar carRepository)
    {
        _carRepository = carRepository;
    }

    public ViewResult Index()
    {
        var homeViewModel = new HomeViewModel
        {
            FavouriteCars = _carRepository.GetFavouriteCars,
        };
        return View(homeViewModel);
    } 
}