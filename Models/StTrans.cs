namespace MySambu.Api.Models
{

    public class Status{
        public int Code { get; set; }
        public int PagesCount { get; set; }
        public string Description { get; set; }
    }

    public static class StTrans
    {
        public static Status SetSt(int a, int b, string c){
            Status st = new Status {
                Code = a, PagesCount = b, Description = c
            };
            return st;
        }
    }
}