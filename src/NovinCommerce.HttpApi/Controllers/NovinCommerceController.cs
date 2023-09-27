using NovinCommerce.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace NovinCommerce.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class NovinCommerceController : AbpControllerBase
{
    protected NovinCommerceController()
    {
        LocalizationResource = typeof(NovinCommerceResource);
    }
}