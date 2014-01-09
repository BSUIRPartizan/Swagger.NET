using System.Collections.Generic;
using Api.Sample.Controllers.Base;
using Api.Sample.Models;
using AttributeRouting.Web.Http;

namespace Api.Sample.Controllers
{
    public class MedicationFulfillmentController : BaseApiController
    {
        /// <summary>
        ///     Get All Medications
        /// </summary>
        /// <param name="id"></param>
        /// <param name="recordId"></param>
        /// <returns></returns>
        [GET("records/{recordid}/medicationfulfillment/{id}")]
        public IEnumerable<MedicationFulfillment> Get(int id, int recordId)
        {
            return new List<MedicationFulfillment>(new[] {new MedicationFulfillment()});
        }
    }
}