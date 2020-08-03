using System;
using System.Collections.Generic;
using System.Text;
using ketum.Localization;
using Volo.Abp.Application.Services;

namespace ketum
{
    /* Inherit your application services from this class.
     */
    public abstract class ketumAppService : ApplicationService
    {
        protected ketumAppService()
        {
            LocalizationResource = typeof(ketumResource);
        }
    }
}
