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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public void Create(Product product)
        {
           _productRepository.Create(product);
        
        }

        public void Delete(string id)
        {
            _productRepository.Delete(id);
        }

        public List<Product> GetAll()
        {
            var customer = _productRepository.GetAllProductsEnd();

            return customer;
        }

        public void Update(Product product)
        {
            _productRepository.Create(product);
        }
    }
}
