using Dapper.Contrib.Extensions;

namespace  MySambu.Api.Models
{
    [Table("tUtl_Logs")]
    public class Log
    {
        public long LogID { get; set;}
        public string Level { get; set;}
        public string ClassName { get; set;}
        public string MethodName { get; set;}
        public string Message { get; set;}
        public string NewValue { get; set;}
        public string OldValue { get; set;}
        public string Exception { get; set;}
        public string CreatedBy { get; set;}
    }
}