using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace NovinCommerce.Blazor;

[Dependency(ReplaceServices = true)]
public class NovinCommerceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "NovinCommerce";
}
