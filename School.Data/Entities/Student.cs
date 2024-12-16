using School.Data.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class Student : BaseNamedIdentifiedEntityWithName
    {


        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }

        public int? DID { get; set; }
        [ForeignKey(nameof(DID))]
        [InverseProperty("Students")]
        public virtual Department Department { get; set; } = default!;



    }
}
