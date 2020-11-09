using System;

namespace MySambu.Api.DTO.Transaksi.PPH
{
    public class PPHParameterDto
    {
        public DateTime TransDate1 { get; set; }
        public DateTime TransDate2 { get; set; }
        public string PPHNo { get; set; }
        public string SupplierID { get; set; }
        public string ItemName { get; set; }
    }
}