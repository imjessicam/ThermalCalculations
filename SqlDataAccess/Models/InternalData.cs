
namespace SqlDataAccess.Models
{
    public class InternalData : BaseData
    {
        public virtual ICollection<MonthInternalData> MonthInternalDatas { get; set; }


    }
}
