using System.Collections.Generic;
using GoshaDudarExampleShop.Data.Models;

namespace GoshaDudarExampleShop.Data.Interfaces
{
    public interface ICar
    {
        IEnumerable<Car> GetAllCars { get; }
        IEnumerable<Car> GetFavouriteCars { get; }
        Car GetCarById(int carId);
    }
}