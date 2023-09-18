using NovinCommerce.Localization;
using Volo.Abp.AspNetCore.Components;

namespace NovinCommerce.Blazor;

public abstract class NovinCommerceComponentBase : AbpComponentBase
{
    protected NovinCommerceComponentBase()
    {
        LocalizationResource = typeof(NovinCommerceResource);
    }
}
