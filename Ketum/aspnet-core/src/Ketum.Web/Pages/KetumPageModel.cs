using Ketum.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Ketum.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class KetumPageModel : AbpPageModel
    {
        protected KetumPageModel()
        {
            LocalizationResourceType = typeof(KetumResource);
        }
    }
}