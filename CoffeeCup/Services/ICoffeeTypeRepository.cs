using CoffeeCup.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeCup.Services
{
    public interface ICoffeeTypeRepository
    {
        Task<List<CoffeeType>> GetCoffeeTypesAsync();
    }
}
