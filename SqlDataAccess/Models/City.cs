
namespace SqlDataAccess.Models
{
    public class City : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<Month> Months { get; set; }
    }
}
