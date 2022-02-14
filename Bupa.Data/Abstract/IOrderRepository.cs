using Bupa.Entity.Dtos;
using Bupa.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Data.Abstract
{
    public interface IOrderRepository
    {
       
        bool Delete(string id);
    
        bool CreateOrder(CustomerOrderOrderDetails order);
      
        List<Order> GetAllOrders();
        List<OrderViewModel> GetOrders(int customer_id);
        List<OrderViewModel> GetAllOrderswithCustomer();
    }
}
