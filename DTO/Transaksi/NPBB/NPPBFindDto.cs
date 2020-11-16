using System;

namespace MySambu.Api.DTO.Transaksi.NPBB
{
    public class NPPBFindDto
    {
        public string NPBBNo { get; set; }
        public Nullable<DateTime> TanggalAwal { get; set; }
        public Nullable<DateTime> TanggalAkhir { get; set; }
        public string PPBNo { get; set; }
        public string Supplier { get; set; }
        public int Dept { get; set; }
        public int Status { get; set; }
        public string Item { get; set; }
    }
}