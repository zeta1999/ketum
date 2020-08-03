using Volo.Abp.Settings;

namespace ketum.Settings
{
    public class ketumSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ketumSettings.MySetting1));
        }
    }
}
