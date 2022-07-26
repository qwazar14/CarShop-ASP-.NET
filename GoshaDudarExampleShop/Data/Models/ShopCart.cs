using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GoshaDudarExampleShop.Data.Models;

public class ShopCart
{
    private readonly ApplicationDbContent _applicationDbContent;

    public ShopCart(ApplicationDbContent applicationDbContent) => _applicationDbContent = applicationDbContent;

    public string ShopCartId { get; set; }
    public List<ShopCartItem> ListShopItems { get; set; }

    public static ShopCart GetCart(IServiceProvider services)
    {
        var session = services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
        var context = services.GetService<ApplicationDbContent>();
        var shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

        session.SetString("CartId", shopCartId);

        return new ShopCart(context) { ShopCartId = shopCartId };
    }

    public void AddToCart(Car car)
    {
        _applicationDbContent.ShopCartItem.Add(new ShopCartItem
        {
            Car = car,
            ShopCartId = ShopCartId,
            Price = car.Price
        });

        _applicationDbContent.SaveChanges();
    }

    public List<ShopCartItem> GetShopItems()
    {
        return _applicationDbContent.ShopCartItem
            .Where(c => c.ShopCartId == ShopCartId)
            .Include(s => s.Car).ToList();
    }
}