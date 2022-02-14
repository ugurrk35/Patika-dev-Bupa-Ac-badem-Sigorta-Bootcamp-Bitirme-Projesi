using Bupa.Entity.Dtos;
using Bupa.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Bll.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
     
        void Create(Product entity);
        void Delete(string id);
        void Update(Product entity);
    }
}
