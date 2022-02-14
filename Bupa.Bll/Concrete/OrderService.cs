using Bupa.Bll.Abstract;
using Bupa.Data.Abstract;
using Bupa.Entity.Dtos;
using Bupa.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Bll.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
    

        public void Delete(string id)
        {
            _orderRepository.Delete(id);
        }

        public List<Order> GetAll()
        {
            var order= _orderRepository.GetAllOrders();
            return order;
        }


        public List<OrderViewModel> GetOrderById(int id)
        {
            var order = _orderRepository.GetOrders(id);
            return order;
        }

   

        public List<OrderViewModel> GetWithCustomer()
        {
            var order = _orderRepository.GetAllOrderswithCustomer();
            return order;
        }

        public void CreateOrder(CustomerOrderOrderDetails order)
        {
            _orderRepository.CreateOrder(order);
        }
    }
}
