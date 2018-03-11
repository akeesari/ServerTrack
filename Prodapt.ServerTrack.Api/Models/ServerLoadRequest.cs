using System.ComponentModel.DataAnnotations;

namespace Prodapt.ServerTrack.Api.Models
{
    public class ServerLoadRequest
    {
        [Required]
        public string ServerName { get; set; }

        public decimal? CpuLoad { get; set; }

        public decimal? RamLoad { get; set; }
    }
}