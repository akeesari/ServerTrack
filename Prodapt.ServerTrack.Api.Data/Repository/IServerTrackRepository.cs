using Prodapt.ServerTrack.Api.EF.Domain;
using Prodapt.ServerTrack.Api.DataContract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodapt.ServerTrack.Api.EF.Repository
{
    public interface IServerTrackRepository
    {
        Task<InsertServerLoadResponse> InsertServerLoad(InsertServerLoadRequest serverDetail);       
        Task<List<ServerLoad>> GetAllServersLoad();
        Task<ServerLoad> GetServerLoadByName(string server);
        Task<List<ServerLoad>> GetServerLoadByNameAndTime(string serverName, double? noOfMins, double? noOfHours);
    }
}