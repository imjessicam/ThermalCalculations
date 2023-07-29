
namespace SqlDataAccess.Models
{
    public class MonthInternalData : BaseModel
    {
        public int MonthId { get; set; }
        public int InternalDataId { get; set; }

        public virtual Month Month { get; set; }
        public virtual InternalData InternalData { get; set; }
    }
}
