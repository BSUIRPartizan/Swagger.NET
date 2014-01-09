using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using AttributeRouting.Web.Http;

namespace Api.Sample.Controllers.Base
{
    public abstract class BaseRepositoryApiController<TRepository, TContract, TContractId, T, TId> : BaseApiController

    {
        [GET("")]
        public virtual IEnumerable<TContract> Get()
        {
            return new List<TContract>();
        }

        [POST("")]
        public virtual HttpResponseMessage Post(TContract obj)
        {
            return Request.CreateResponse(HttpStatusCode.Created, obj);
        }

        [PUT("{id}")]
        public virtual void Put(TContractId id, TContract obj)
        {
        }
    }
}