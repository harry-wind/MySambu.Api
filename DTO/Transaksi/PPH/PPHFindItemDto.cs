namespace MySambu.Api.DTO.Transaksi.PPH
{
    public class PPHFindItemDto
    {
        public string ItemSpecID { get; set; }
        public string Deskripsi { get; set; }
        public string ItemID { get; set; }
        public string ItemName { get; set; } 
        public string ItemDesc { get; set; }
        public byte DecimalInQnty { get; set; }
        public string ItemOldID { get; set; }
        public short SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public short CategoryID { get; set; }
        public string CategoryName { get; set; }
        public short UOM { get; set; } 
        public string UOMName { get; set; }        
        public string SupplierID { get; set; }        
    }

    public class PPHFindItemParam
    {
        public string ItemName { get; set; } 
        public short? Category { get; set; } 
        public short? SubCategoryID { get; set; } 
    }
}