using System.Data.Entity;
using Prodapt.ServerTrack.Api.EF.Domain;

namespace Prodapt.ServerTrack.Api.EF
{
    public partial class ServerTrackContext : DbContext
    {
        public ServerTrackContext()
            : base("name=ServerTrackContext")
        {
        }

        public virtual DbSet<ServerLoad> ServerLoads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServerLoad>()
                .Property(e => e.ServerName)
                .IsFixedLength();

            modelBuilder.Entity<ServerLoad>()
                .Property(e => e.CpuLoad)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ServerLoad>()
                .Property(e => e.RamLoad)
                .HasPrecision(18, 0);
        }
    }
}
