using Volo.Abp.Settings;

namespace NovinCommerce.Settings;

public class NovinCommerceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(NovinCommerceSettings.MySetting1));
    }
}
