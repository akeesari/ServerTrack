using System.ComponentModel.DataAnnotations;

namespace Prodapt.ServerTrack.Api.DataContract
{
    public class InsertServerLoadRequest : BaseRequest
    {
        [Required]
        public string ServerName { get; set; }

        public decimal? CpuLoad { get; set; }

        public decimal? RamLoad { get; set; }
    }
}
