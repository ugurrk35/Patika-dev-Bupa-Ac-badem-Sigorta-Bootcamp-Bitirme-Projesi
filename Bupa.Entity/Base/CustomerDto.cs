using Bupa.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Entity.Base
{
    public class CustomerDto: DtoGetBase
    {
        public Customer Customer { get; set; }
    }
}
