using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Api.Sample.Controllers.Base;
using Api.Sample.Models;
using AttributeRouting;
using AttributeRouting.Web.Http;

namespace Api.Sample.Controllers
{
    [RoutePrefix("v2")]
    //public class MembershipTransactionController : BaseBOApiController<IMembershipBusinessObject>
    public class MembershipTransactionController : BaseApiController
    {
        //public readonly ICoreMembershipRepository _repo;
        //private readonly IUserContextHelper userContextHelper;

        #region "Ctor"

        //public MembershipTransactionController(ICoreMembershipRepository coreMembershipRepository)

        #endregion

        #region "Membershiptransactions"

        #region "GET"

        [GET(
            "group/memberships/{owner?}/{parent?}/{type?}/{offset?}/{limit?}/{order_by?}/{include_hidden=false}/{q?}/{groupCode?}/{groupCodeClimbTree=false}/{policyNumber?}/{flexField01?}/{flexField02?}/{flexField03?}/{flexField04?}/{flexField05?}/{flexField06?}/{flexField07?}/{flexField08?}/{flexField09?}/{flexField10?}",
            SitePrecedence = 1)]
        public IEnumerable<Membership> GetFilteredMemberships(int? owner, int? parent, int? type, int? offset,
            int? limit, string order_by, bool include_hidden = false, string q = null, string groupCode = null,
            bool groupCodeClimbTree = false, string policyNumber = null, string flexField01 = null,
            string flexField02 = null, string flexField03 = null, string flexField04 = null, string flexField05 = null,
            string flexField06 = null, string flexField07 = null, string flexField08 = null, string flexField09 = null,
            string flexField10 = null)
        {
            return new[] {new Membership()};
        }

        #endregion

        #endregion

        #region "ADD MEMBERSHIP BY GROUP"

        /// <summary>
        ///     Adds Membership
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="membership"></param>
        /// <returns></returns>
        [POST("group/{groupId}/memberships")]
        public HttpResponseMessage AddMembershipbyGroupId(string groupId, Membership membership)
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        #endregion
    }
}
       