using System;
using System.ComponentModel.DataAnnotations;

namespace Prodapt.ServerTrack.Api.EF.Domain
{
    public partial class ServerLoad
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string ServerName { get; set; }

        public decimal? CpuLoad { get; set; }

        public decimal? RamLoad { get; set; }

        public DateTime DateCreated { get; set; }
    }
}