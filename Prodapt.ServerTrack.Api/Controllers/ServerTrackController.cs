using Prodapt.ServerTrack.Api.EF.Repository;
using Prodapt.ServerTrack.Api.DataContract;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Prodapt.ServerTrack.Api.Controllers
{
    [RoutePrefix("ServerTrack")]
    public class ServerTrackController : BaseApiController
    {
      
        public ServerTrackController()
        {
        }
        [HttpGet]
        [Route("GetAllServersLoad")]
        public async Task<IHttpActionResult> GetAllServersLoad()
        {
            var repository = new ServerTrackRepository();
            var response = await repository.GetAllServersLoad();
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetServerLoadByNameAndTime")]
        public async Task<IHttpActionResult> GetServerLoadByNameAndTime(string serverName,double? noOfMins = 0, double? noOfHours = 0)
        {
            var repository = new ServerTrackRepository();

            var response = await repository.GetServerLoadByNameAndTime(serverName,noOfMins ,noOfHours);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("InsertServerLoad")]
        public async Task<HttpResponseMessage> InsertServerLoad([FromBody]InsertServerLoadRequest request)
        {
            try
            {
                var repository = new ServerTrackRepository();

                var response = await repository.InsertServerLoad(request);

                if (response != null )
                {
                    return Request.CreateResponse(HttpStatusCode.Created, response);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
