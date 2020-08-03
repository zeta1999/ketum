using ketum.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ketum.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ketumController : AbpController
    {
        protected ketumController()
        {
            LocalizationResource = typeof(ketumResource);
        }
    }
}