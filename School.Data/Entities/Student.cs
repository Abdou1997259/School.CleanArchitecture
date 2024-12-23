using School.Data.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class Student : BaseNamedIdentifiedEntityWithName
    {




        public int? DID { get; set; }
        [ForeignKey(nameof(DID))]
        [InverseProperty("Students")]
        public virtual Department Department { get; set; } = default!;
        [InverseProperty(nameof(StudentSubject.Student))]
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new HashSet<StudentSubject>();



    }
}
