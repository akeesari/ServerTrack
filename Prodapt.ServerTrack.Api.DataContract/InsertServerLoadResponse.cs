using System;
using System.ComponentModel.DataAnnotations;

namespace Prodapt.ServerTrack.Api.DataContract
{
    public class InsertServerLoadResponse : BaseResponse
    {
        public string ServerName { get; set; }

        public decimal? CpuLoad { get; set; }

        public decimal? RamLoad { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
