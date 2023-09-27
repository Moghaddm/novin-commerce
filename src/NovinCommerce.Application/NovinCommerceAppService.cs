using NovinCommerce.Localization;
using Volo.Abp.Application.Services;

namespace NovinCommerce;

/* Inherit your application services from this class.
 */
public abstract class NovinCommerceAppService : ApplicationService
{
    protected NovinCommerceAppService()
    {
        LocalizationResource = typeof(NovinCommerceResource);
    }
}