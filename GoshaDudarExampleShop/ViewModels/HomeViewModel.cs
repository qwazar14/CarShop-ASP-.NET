using System.Collections.Generic;
using GoshaDudarExampleShop.Data.Models;

namespace GoshaDudarExampleShop.ViewModels;

public class HomeViewModel
{
    public IEnumerable<Car> FavouriteCars { get; set; }
}