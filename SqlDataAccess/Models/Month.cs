using SqlDataAccess.Enums;

namespace SqlDataAccess.Models
{
    public class Month : BaseModel
    {
        public int CityId { get; set; }
        public MonthName Name { get; set; }

        public virtual ICollection<MonthInternalData> MonthInternalDatas { get; set; }
        public virtual ICollection<MonthExternalData> MonthExternalDatas { get; set; }

        public virtual City City { get; set; }
    }
}
