using System;
using System.Collections.Generic;
using MySambu.Api.Models;
using MySambu.Api.Models.Transaksi.PPH;
using Newtonsoft.Json;

namespace MySambu.Api.DTO.Transaksi.PPH
{
    public class PPHDto : BaseModelTransaksi
    {
        public long PPHID { get; set; }        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid PPHHdrGuid { get; set; }
        public string PPHNo { get; set; }
        public string SupplierPPHRef { get; set; }
        public DateTime TransDate { get; set; }
        public string SupplierID { get; set; }
        public bool PriceInd { get; set; }
        public string Remark { get; set; }
        public string FileAttachment { get; set; }
        public string SupplierIDOld { get; set; }
        public string  PeriodePPHonline { get; set; }
        public IList<PPHDetail> PPHDetails { get; set; }
    }
}