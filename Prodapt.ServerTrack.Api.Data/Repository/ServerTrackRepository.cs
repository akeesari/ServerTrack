using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Prodapt.ServerTrack.Api.EF.Domain;
using Prodapt.ServerTrack.Api.DataContract;

namespace Prodapt.ServerTrack.Api.EF.Repository
{
    public class ServerTrackRepository : IServerTrackRepository
    {
        public async Task<InsertServerLoadResponse> InsertServerLoad(InsertServerLoadRequest request)
        {
            var serverLoad = MapServerLoadRequestToDomain(request);

            using (var ctx = new ServerTrackContext())
            {
                ctx.Entry(serverLoad).State = EntityState.Added;
                var status = await ctx.SaveChangesAsync();

                return MapDomainToServerLoadResponse(serverLoad); //return newly inserted server
            }
        }
       
        public async Task<List<ServerLoad>> GetAllServersLoad()
        {
            using (var ctx = new ServerTrackContext())
            {
                return await ctx.ServerLoads.ToListAsync();
            }

        }
        public async Task<ServerLoad> GetServerLoadByName(string serverName)
        {
            using (var ctx = new ServerTrackContext())
            {
                var server = await ctx.ServerLoads.Where(t => t.ServerName.Equals(serverName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
                if (server.Any())
                {
                    return server.Single();
                }
                return null;
            }
        }

        public async Task<List<ServerLoad>> GetServerLoadByNameAndTime(string serverName, double? noOfMins, double? noOfHours)
        {
            using (var ctx = new ServerTrackContext())
            {
                var serverLoad =  await ctx.ServerLoads.Where(t => t.ServerName.Equals(serverName, StringComparison.CurrentCultureIgnoreCase)).ToListAsync();
                if(noOfMins.HasValue && noOfMins > 0)
                {
                    var subtractMins = DateTime.Now.AddMinutes( (double) -noOfMins);
                 return serverLoad.Where(s => s.DateCreated > subtractMins).ToList();
                }
                else if (noOfHours.HasValue && noOfHours > 0)
                {
                    var subtractHours = DateTime.Now.AddHours((double) -noOfHours);
                    return serverLoad.Where(s => s.DateCreated > subtractHours).ToList();
                }
                
                return serverLoad;
            }
        }
        #region Mappers
        private ServerLoad MapServerLoadRequestToDomain(InsertServerLoadRequest request)
        {
            var serverLoad = new ServerLoad
            {
                ServerName = request.ServerName,
                CpuLoad = request.CpuLoad,
                RamLoad = request.RamLoad,
                DateCreated = DateTime.Now
            };
            return serverLoad;
        }
        private InsertServerLoadResponse MapDomainToServerLoadResponse(ServerLoad serverLoad)
        {
            var response = new InsertServerLoadResponse
            {
                ServerName = serverLoad.ServerName,
                CpuLoad = serverLoad.CpuLoad,
                RamLoad = serverLoad.RamLoad,
                DateCreated = serverLoad.DateCreated
            };
            return response;
        }
        #endregion

    }
}
