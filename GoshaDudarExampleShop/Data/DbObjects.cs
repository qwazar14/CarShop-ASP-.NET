using System.Collections.Generic;
using System.Linq;
using GoshaDudarExampleShop.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GoshaDudarExampleShop.Data;

public static class DbObjects
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Category.Any())
        {
            context.Category.AddRange(Categories.Select(c => c.Value));
        }

        if (!context.Car.Any())
        {
            context.AddRange(
                new Car
                {
                    Name = "Tesla Model X",
                    ShortDesc = "Tesla Model X 2015",
                    LongDesc = "THIS IS TESLA!",
                    ImgPath = "/img/tesla-model-x.png",
                    Price = 50000,
                    IsFavourite = true,
                    Available = true,
                    Category = Categories["Электромобиль"]
                },
                new Car
                {
                    Name = "BMW X5",
                    ShortDesc = "BMW X5 2015",
                    LongDesc = "THIS IS BMW!",
                    ImgPath = "/img/bmw-x5.png",
                    Price = 40000,
                    IsFavourite = true,
                    Available = true,
                    Category = Categories["ДВС автомобиль"]
                },
                new Car
                {
                    Name = "Ford Fiesta",
                    ShortDesc = "Ford Fiesta 2015",
                    LongDesc = "THIS IS FORD!",
                    ImgPath = "/img/ford-fiesta.png",
                    Price = 30000,
                    IsFavourite = false,
                    Available = false,
                    Category = Categories["ДВС автомобиль"]
                },
                new Car
                {
                    Name = "Lada Vesta",
                    ShortDesc = "Lada Vesta 2015",
                    LongDesc = "THIS IS LADA!",
                    ImgPath = "/img/lada-vesta.png",
                    Price = 20000,
                    IsFavourite = false,
                    Available = false,
                    Category = Categories["ДВС автомобиль"]
                },
                new Car
                {
                    Name = "Mercedes-Benz S-Class",
                    ShortDesc = "Mercedes-Benz S-Class 2015",
                    LongDesc = "THIS IS MERCEDES!",
                    ImgPath = "/img/mercedes-s.png",
                    Price = 75000,
                    IsFavourite = true,
                    Available = true,
                    Category = Categories["ДВС автомобиль"]
                },
                new Car
                {
                    Name = "Toyota Camry Hybrid",
                    ShortDesc = "Toyota Camry Hybrid 2015",
                    LongDesc = "THIS IS TOYOTA!",
                    ImgPath = "/img/camry.png",
                    Price = 60000,
                    IsFavourite = true,
                    Available = true,
                    Category = Categories["Электромобиль"]
                },
                new Car
                {
                    Name = "Tesla Cybertruck",
                    ShortDesc = "Tesla Cybertruck 2015",
                    LongDesc = "THIS IS TESLA!",
                    ImgPath = "/img/cybertruck.png",
                    Price = 50000,
                    IsFavourite = true,
                    Available = true,
                    Category = Categories["Электромобиль"]
                }
            );
        }

        context.SaveChanges();
    }

    private static Dictionary<string, Category> categories;
    private static Dictionary<string, Car> cars;

    private static Dictionary<string, Category> Categories
    {
        get
        {
            if (categories != null) return categories;
            var list = new Category[]
            {
                new Category
                {
                    CategoryName = "Электромобиль",
                    Desc =
                        "An electric car, battery electric car, or all-electric car, is an automobile that is propelled by one or more electric motors"
                },
                new Category
                {
                    CategoryName = "ДВС автомобиль",
                    Desc =
                        "Most ICEs are used in mobile applications and are the primary power supply for vehicles such as cars"
                }
            };
            categories = new Dictionary<string, Category>();
            foreach (var element in list)
            {
                categories.Add(element.CategoryName, element);
            }

            return categories;
        }
    }
}