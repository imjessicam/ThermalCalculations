

namespace SqlDataAccess.Models
{
    public class ExternalData : BaseData
    {
        public virtual ICollection<MonthExternalData> MonthExternalDatas { get; set; }

    }
}
