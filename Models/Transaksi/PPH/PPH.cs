using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Transaksi.PPH
{
    [Table("tTrn_PPHHdr")]
    public class PPH : BaseModelTransaksi
    {
        [Key]
        public long PPHID { get; set; }
        public Guid PPHHdrGuid { get; set; }
        public string PPHNo { get; set; }
        public string SupplierPPHRef { get; set; }
        public DateTime TransDate { get; set; }
        public string SupplierID { get; set; }
        public bool PriceInd { get; set; }
        public string Remark { get; set; }
        public string FileAttachment { get; set; }
        public string SupplierIDOld { get; set; }
        public string PeriodePPHOnline { get; set; }
    }
}