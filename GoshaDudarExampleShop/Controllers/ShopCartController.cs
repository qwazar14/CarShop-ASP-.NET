using System;
using System.Linq;
using GoshaDudarExampleShop.Data.Interfaces;
using GoshaDudarExampleShop.Data.Models;
using GoshaDudarExampleShop.Data.Repository;
using GoshaDudarExampleShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GoshaDudarExampleShop.Controllers;

public class ShopCartController : Controller
{
    private readonly ICar _carRepository;
    private readonly ShopCart _shopCart;

    public ShopCartController(ICar carRepository, ShopCart shopCart)
    {
        _carRepository = carRepository;
        _shopCart = shopCart;
    }
    
    public ViewResult Index()
    {
        var items = _shopCart.GetShopItems();
        _shopCart.ListShopItems = items;
        
        var obj = new ShopCartViewModel
        {
            ShopCart = _shopCart
        };
        
        return View(obj);
    }
    
    public RedirectToActionResult AddToCart(int id)
    {
        var item = _carRepository.GetAllCars.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            _shopCart.AddToCart(item);
        }
        return RedirectToAction("Index");
    }
}