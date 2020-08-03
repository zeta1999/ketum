using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace ketum.Web
{
    [Dependency(ReplaceServices = true)]
    public class ketumBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ketum";
    }
}
