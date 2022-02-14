

using Bupa.Data;
using Bupa.Entity.Base;
using Bupa.Entity.Dtos;
using Bupa.Entity.IBase;
using Bupa.Entity.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Bll.Abstract
{
    public interface ICustomerService
    {
        void Delete(string id);
        List<Customer> GetAll();
        //List<CustomerViewModel> GetAll();
        string Create(Customer entity);
        List<Customer> GetCustomerById(int id);

       // Task<IDataResult<CustomerDto>> GetAllByCategoryAsync(int customerId);
    }
}
