using System.Web.Http;
using AttributeRouting.Web.Http;

namespace Api.Sample.Controllers.Base
{
    public abstract class CrudRepositoryApiController<TRepository, TContract, TContractId, T, TId> :
        BaseRepositoryApiController<TRepository, TContract, TContractId, T, TId>
        where T : new()
    {
        [GET("{id}")]
        public virtual T Get(TId id)
        {
            return new T();
        }

        [DELETE("{id}")]
        public virtual void Delete(TId id)
        {
        }
    }
}