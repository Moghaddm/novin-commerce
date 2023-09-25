using NovinCm.ProductManagement.Localization;
using Volo.Abp.Application.Services;

namespace NovinCm.ProductManagement;

public abstract class ProductManagementAppService : ApplicationService
{
    protected ProductManagementAppService()
    {
        LocalizationResource = typeof(ProductManagementResource);
        ObjectMapperContext = typeof(ProductManagementApplicationModule);
    }
}
