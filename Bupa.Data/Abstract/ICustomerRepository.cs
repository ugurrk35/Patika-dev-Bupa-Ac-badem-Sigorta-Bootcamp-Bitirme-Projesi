
using Bupa.Entity.Dtos;
using Bupa.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Data.Abstract
{
    public interface ICustomerRepository
    {
        bool Delete(string id);
        List<Customer> GetAllCustomer();
        //List<CustomerViewModel> GetAllCustomer();
        string Create(Customer customer);
        List<Customer> GetCustomer(int customer_id);

    }
}
