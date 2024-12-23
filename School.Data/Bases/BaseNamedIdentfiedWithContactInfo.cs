using System.ComponentModel.DataAnnotations;

namespace School.Data.Bases
{
    public class BaseNamedIdentfiedWithContactInfo : BaseNamedIdentifiedEntityWithName
    {
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }
    }
}
