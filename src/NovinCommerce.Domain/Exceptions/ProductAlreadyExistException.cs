using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinCommerce.Exceptions
{
    public class ProductAlreadyExistException : BusinessException
    {
        public ProductAlreadyExistException(string name) : base(NovinCommerceDomainErrorCodes.ProductAlreadyExist)
        { WithData(nameof(name), name); }
    }
}
