using Api.Sample.Controllers.Base;
using Api.Sample.Models;
using AttributeRouting;

namespace Api.Sample.Controllers{
    [RoutePrefix("api/messagefolders")]
    public class MessageFoldersController : CrudRepositoryApiController<object, MessageFolder, string, CoreMessageFolder, int>
    {
    }
}