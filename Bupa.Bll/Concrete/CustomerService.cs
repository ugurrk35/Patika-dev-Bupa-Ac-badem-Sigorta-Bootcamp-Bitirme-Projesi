
using Bupa.Bll.Abstract;

using Bupa.Data;
using Bupa.Data.Abstract;
using Bupa.Entity.Base;
using Bupa.Entity.Dtos;
using Bupa.Entity.IBase;
using Bupa.Entity.Models;
using Bupa.Entity.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Bll.Concrete
{
    public class CustomerService :ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
       
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
     
        }

        public void Delete(string id)
        {
            _customerRepository.Delete(id);
        }
        public string Create(Customer entity)
        {
          var aa = _customerRepository.Create(entity);
            return aa;           
    
        }

        public List<Customer> GetAll()
        {
            var customer = _customerRepository.GetAllCustomer();

            return customer;
        }

        public List<Customer> GetCustomerById(int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            return customer;
        }
        /// <summary>
        /// yetiştiremedim yarıda kesmek zorunda kaldım
        /// </summary>

        //public async Task<IDataResult<CustomerDto>> GetAllByCategoryAsync(int customerId)
        //{
        //    var customer = Task.Run(() => {
        //        _customerRepository.GetCustomer(customerId);

        //    });

        //    if (customer != null)
        //    {
        //        return new DataResult<CustomerDto>(ResultStatus.Success, new CustomerDto
        //        {
        //            Customer = customer,
        //            ResultStatus = ResultStatus.Success
        //        });
        //    }
        //    return new DataResult<CustomerDto>(ResultStatus.Error, Messages.Customer.NotFound(isPlural: false), null);
        //}






        //public List<CustomerViewModel> GetAll()
        //{
        //    var customer = _customerRepository.GetAllCustomer();

        //    return customer;
        //}
    }
}
