using System.Web.Http;

namespace Prodapt.ServerTrack.Api.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        // in case if you are calling from .net web app this will be used for unit test cases.
        //private readonly IServerTrackRepository _ServerTrackRepository;

        //public BaseApiController(IServerTrackRepository serverTrackRepository)
        //{
        //    _ServerTrackRepository = serverTrackRepository;
        //}

    }
}