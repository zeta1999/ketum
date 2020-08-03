using ketum.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ketum.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ketumPageModel : AbpPageModel
    {
        protected ketumPageModel()
        {
            LocalizationResourceType = typeof(ketumResource);
        }
    }
}