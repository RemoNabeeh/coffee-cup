using CoffeeCup.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeCup.Services
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int customerId);
    }
}
