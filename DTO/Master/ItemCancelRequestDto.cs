namespace MySambu.Api.DTO.Master
{
    public class ItemCancelRequestDto
    {
        public int NewItemID { get; set; }
        public string CancelRemark { get; set; }
        public string UpdatedBy { get; set; }
    }
}