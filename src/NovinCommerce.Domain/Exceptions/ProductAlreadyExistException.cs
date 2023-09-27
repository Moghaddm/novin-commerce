using Volo.Abp;

namespace NovinCommerce.Exceptions;

public class ProductAlreadyExistException : BusinessException
{
    public ProductAlreadyExistException(string name) : base(NovinCommerceDomainErrorCodes.ProductAlreadyExist)
    {
        WithData(nameof(name), name);
    }
}