using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Entity.IBase
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; } // new DataResult<Customer>(ResultStatus.Success,customer);
                               // new DataResult<IList<Customer>>(ResultStatus.Success, customerList);
    }
}
