using System.Collections.Generic;
using System.Linq;
using GoshaDudarExampleShop.Data.Interfaces;
using GoshaDudarExampleShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GoshaDudarExampleShop.Data.Repository
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContent _applicationDbContent;

        public CarRepository(ApplicationDbContent applicationDbContent) => _applicationDbContent = applicationDbContent;

        public IEnumerable<Car> GetAllCars => _applicationDbContent.Car.Include(car => car.Category);

        public IEnumerable<Car> GetFavouriteCars =>
            _applicationDbContent.Car.Where(c => c.IsFavourite).Include(car => car.Category);

        public Car GetCarById(int carId) => _applicationDbContent.Car.FirstOrDefault(car => car.Id==carId);
    }
}