namespace MySambu.Api.DTO.Transaksi.PPB
{
    public class PPBRequestApproveByDeptDto
    {
        public string PPBDtlRequestGUID { get; set; }
        public decimal QntyReq { get; set; }
        public string DeptRemark { get; set; }
        public short St { get; set; }      
        public string Computer { get; set; }
        public string UserID { get; set; }
    }
}