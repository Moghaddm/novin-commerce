using NovinCm.ProductManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace NovinCm.ProductManagement;

public abstract class ProductManagementController : AbpControllerBase
{
    protected ProductManagementController()
    {
        LocalizationResource = typeof(ProductManagementResource);
    }
}
