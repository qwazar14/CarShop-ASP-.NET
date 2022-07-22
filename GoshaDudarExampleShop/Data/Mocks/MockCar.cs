using System.Collections.Generic;
using System.Linq;
using GoshaDudarExampleShop.Data.Interfaces;
using GoshaDudarExampleShop.Data.Models;

namespace GoshaDudarExampleShop.Data.Mocks
{
    public class MockCar : ICar
    {
        private readonly ICategory _category = new MockCategory();
        
        public IEnumerable<Car> GetAllCars =>
            new List<Car>
            {
                new Car
                {
                    Name = "Tesla Model X",
                    ShortDesc = "Tesla Model X 2015",
                    LongDesc = "THIS IS TESLA!",
                    ImgPath = "/img/tesla-model-x.png",
                    Price = 50000,
                    IsFavourite = true,
                    Available = true,
                    Category = _category.AllCategories.First()
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
                    Category = _category.AllCategories.Last()
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
                    Category = _category.AllCategories.Last()
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
                    Category = _category.AllCategories.Last()
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
                    Category = _category.AllCategories.Last()
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
                    Category = _category.AllCategories.First()
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
                    Category = _category.AllCategories.First()
                }
                    
                    
                    
            };


        public IEnumerable<Car> GetFavouriteCars { get; set; }
        public Car GetCarById(int carId)
        {
            throw new System.NotImplementedException();
        }
    }
}