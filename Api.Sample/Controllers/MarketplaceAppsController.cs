using System;
using System.Collections.Generic;
using System.Web.Http;
using Api.Sample.Controllers.Base;
using Api.Sample.Models;
using AttributeRouting;
using AttributeRouting.Web.Http;

namespace Api.Sample.Controllers
{
    [RoutePrefix("v1/marketplace/apps")]
    public class MarketplaceAppsController : BaseApiController
    {
        [GET("{category}")]
        [AllowAnonymous]
        public ApiResponseWrapper<IEnumerable<MarketplaceAppShortResult>> Get(string category, [FromUri] RequestParameters pagingParameter)
        {
            return Get(category, null, pagingParameter);
        }

        [GET("{category}/{searchTerm}")]
        [AllowAnonymous]
        public ApiResponseWrapper<IEnumerable<MarketplaceAppShortResult>> Get(string category, string searchTerm, [FromUri] RequestParameters pagingParameter)
        {
            return new ApiResponseWrapper<IEnumerable<MarketplaceAppShortResult>>();
        }

        [POST("")]
        public int Post()
        {
            return -1;
        }

        [GET("/v1/group/{wlg}/marketplace/apps/{category}", IsAbsoluteUrl = true)]
        [AllowAnonymous]
        public ApiResponseWrapper<IEnumerable<MarketplaceAppShortResult>> GetForOrgUnit(
            Guid wlg, string category, [FromUri] RequestParameters pagingParameter)
        {
            return GetForOrgUnit(wlg, category, null, pagingParameter);
        }

        [GET("/v1/group/{wlg}/marketplace/apps/{category}/{searchTerm}", IsAbsoluteUrl = true)]
        [AllowAnonymous]
        public ApiResponseWrapper<IEnumerable<MarketplaceAppShortResult>> GetForOrgUnit(
            Guid wlg, string category, string searchTerm, [FromUri] RequestParameters pagingParameter)
        {
            
            return new ApiResponseWrapper<IEnumerable<MarketplaceAppShortResult>>();
        }


        [GET("/v2/group/{wlg}/marketplaceApps", IsAbsoluteUrl = true)]
        [AllowAnonymous]
        public ApiResponseWrapper<IEnumerable<MarketplaceAppShortResult>> GetWithAlgorithms(
            Guid wlg, [FromUri] MarketplaceAppsRequestParameters requestParameters)
        {
            return new ApiResponseWrapper<IEnumerable<MarketplaceAppShortResult>>();
        }
    }
}
