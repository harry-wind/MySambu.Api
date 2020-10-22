
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_MainProductCategory")]
    public class MainProductCategory : BaseModel
    {
        [Key]
        public int MainProductCategoryID { get; set; }
        public string MainProductCategoryName { get; set; }
    }
}