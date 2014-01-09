using System;
using System.Collections.Generic;
using System.Web.Http;
using Api.Collector.Tests.Controllers.Base;
using Api.Collector.Tests.Models;

namespace Api.Collector.Tests.Controllers
{
    public class MarketplaceAppsControllerTest : BaseBOApiV2Controller<IMarketplaceAppsBO, MarketplaceApp>
    {
        //[GET("/v1/group/{wlg}/marketplace/apps/{category}/{searchTerm}", IsAbsoluteUrl = true)]
        [AllowAnonymous]
        public ApiResponseWrapper<IEnumerable<MarketplaceAppShortResult>> GetForOrgUnit(
            Guid wlg, string category, string searchTerm, [FromUri] RequestParametersTest pagingParameter)
        {
            throw new NotImplementedException();
        }
    }
}