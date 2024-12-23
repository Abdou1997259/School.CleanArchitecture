using School.Data.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class DepartmentSubject : BaseEntity
    {
        [Key]
        public int DeptSubID { get; set; }
        public int DID { get; set; }

        public int SubID { get; set; }

        [ForeignKey("DID")]
        [InverseProperty(nameof(Department.DepartmentSubjects))]
        public virtual Department Department { get; set; } = default!;

        [ForeignKey("SubID")]
        [InverseProperty(nameof(Subject.DepartmentsSubjects))]
        public virtual Subject Subject { get; set; } = default!;
    }
}
