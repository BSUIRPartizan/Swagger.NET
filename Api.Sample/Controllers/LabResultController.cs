using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Api.Sample.Controllers.Base;
using Api.Sample.Models;
using AttributeRouting;
using AttributeRouting.Web.Http;

namespace Api.Sample.Controllers
{
    [RoutePrefix("records/{recordId}/labs")]
    public class LabResultController : BaseApiController
    {
        #region GET

        /// <summary>
        ///     Get LabResult as per recordId, test name and test date
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [GET("records/{recordId}/lab/{Id}", IsAbsoluteUrl = true)]
        public LabResult GetLabResultsDetailsByID(int Id)
        {
            return new LabResult();
        }

        /// <summary>
        ///     Get All LabResults
        ///     Modified By     :   Siva Gangu
        ///     Modified Date   :   8/14/2013
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        [GET("{testName}")]
        public IEnumerable<LabResult> GetLabResults(int recordId, string testName)
        {
            return new List<LabResult>();
        }

        /// <summary>
        ///     Get Labresults with record ID and Status
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [GET("latest/{status}")]
        public IEnumerable<LabResult> GetLatestLabResults(int recordId, string status)
        {
            return new List<LabResult>();
        }

        #endregion

        /// <summary>
        ///     Get Labresults with all offset,limit,include_hidden,status and date range parameters
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="between"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="include_hidden"></param>
        /// <param name="status"></param>
        /// <param name="order_by"></param>
        /// <returns></returns>
        [GET("{between?}/{offset?}/{limit?}/{include_hidden?}/{status?}/{order_by?}")]
        public IEnumerable<LabResult> GetLabResults(
            int recordId,
            string between,
            string offset,
            string limit,
            bool include_hidden,
            string status,
            string order_by)
        {
            return new[]
            {
                new LabResult()
            };
        }

        #region POST

        /// <summary>
        ///     Add LabResult
        /// </summary>
        /// <param name="LabResult"></param>
        /// <returns></returns>
        [POST("")]
        public HttpResponseMessage Add(LabResult LabResult)
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        #endregion

        #region PUT

        /// <summary>
        ///     Update LabResult
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="id"></param>
        /// <param name="labResult"></param>
        [PUT("{id}")]
        public void Put(int recordId, string id, LabResult labResult)
        {
        }

        #endregion

        #region DELETE

        /// <summary>
        ///     Delete LabResult
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="id"></param>
        [DELETE("{id}")]
        public void Delete(int recordId, int id)
        {
        }

        #endregion
    }
}
