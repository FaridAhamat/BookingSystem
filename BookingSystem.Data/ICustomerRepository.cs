using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Data
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);

        IEnumerable<Customer> GetAllCustomers();

        void CreateCustomer(Customer customer);
    }
}
