using System.Collections.Generic;
using System.Linq;
using GoshaDudarExampleShop.Data.Interfaces;
using GoshaDudarExampleShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GoshaDudarExampleShop.Data.Repository
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;

        public IEnumerable<Car> GetAllCars => _applicationDbContext.Car.Include(car => car.Category);

        public IEnumerable<Car> GetFavouriteCars =>
            _applicationDbContext.Car.Where(c => c.IsFavourite).Include(car => car.Category);

        public Car GetCarById(int carId) => _applicationDbContext.Car.FirstOrDefault(car => car.Id==carId);
    }
}