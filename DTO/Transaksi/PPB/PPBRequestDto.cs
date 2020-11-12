using System.Collections.Generic;
using MySambu.Api.Models.Transaksi.PPB;

namespace MySambu.Api.DTO.Transaksi.PPB
{
    public class PPBRequestDto : PPBHdr
    {
        public List<PPBRequets> PPBRequestDtl { get; set; }
    }
}