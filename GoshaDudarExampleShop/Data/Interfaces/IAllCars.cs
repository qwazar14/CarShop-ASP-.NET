using System.Collections.Generic;
using GoshaDudarExampleShop.Data.Models;

namespace GoshaDudarExampleShop.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> GetFavouriteCars { get; set; }
        Car GetCarById(int carId);
    }
}