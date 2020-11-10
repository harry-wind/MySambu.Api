namespace MySambu.Api.Models.Transaksi.PPB
{
    public class PPBBuyPPH : BaseModelTransaksi
    {
        public string PPBDtlBuyPPHGuid { get; set; }
        public string PPBGUID { get; set; }
        public string ItemID { get; set; }
        public string ItemSpecID { get; set; }
        public short BuyDNo { get; set; }
        public string PPHHdrGuid { get; set; }
        public bool ShowInd { get; set; }
    }
}