using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingSystem.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        public void CreateCustomer(Customer customer)
        {
            var lastCustomerId = Data.Data.Customers[Data.Data.Customers.Count - 1].Id;

            Data.Data.Customers.Add(new Customer
            {
                Id = lastCustomerId + 1,
                Name = customer.Name,
            });
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return Data.Data.Customers;
        }

        public Customer GetCustomer(int id)
        {
            return (from c in Data.Data.Customers
                    where c.Id == id
                    select c).FirstOrDefault();
        }
    }
}
