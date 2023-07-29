
namespace SqlDataAccess.Models
{
    public class MonthExternalData : BaseModel
    {
        public int MonthId { get; set; }
        public int ExternalDataId { get; set; }

        public virtual Month Month { get; set; }
        public virtual ExternalData ExternalData { get; set; }
    }
}
