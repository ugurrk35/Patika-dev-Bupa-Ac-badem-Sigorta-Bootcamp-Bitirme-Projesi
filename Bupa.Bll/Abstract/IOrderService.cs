using Bupa.Entity.Dtos;
using Bupa.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Bll.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();

       
        void CreateOrder(CustomerOrderOrderDetails order);
        void Delete(string id);
 
        List<OrderViewModel> GetOrderById(int id);
        List<OrderViewModel> GetWithCustomer();
    }
}
