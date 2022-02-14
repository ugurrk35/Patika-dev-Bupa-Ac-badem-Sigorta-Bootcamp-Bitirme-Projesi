using Bupa.Entity.Dtos;
using Bupa.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Data.Abstract
{
    public interface IProductRepository
    {
        bool Delete(string id);
        bool Create(Product product);
        bool Update(Product product);
        List<Product> GetAllProductsEnd();
      
    }
}
