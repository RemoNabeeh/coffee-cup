using CoffeeCup.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CoffeeCup.Services
{
    public class CoffeeTypeRepository : ICoffeeTypeRepository
    {
        readonly ApplicationContext _context = new ApplicationContext();

        public Task<List<CoffeeType>> GetCoffeeTypesAsync()
        {
            return _context.CoffeeTypes.ToListAsync();
        }
    }
}
