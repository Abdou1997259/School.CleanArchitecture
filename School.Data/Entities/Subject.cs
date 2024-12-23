using School.Data.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class Subject : BaseNamedIdentifiedEntityWithName
    {
 

        public DateTime Period { get; set; }
        [InverseProperty(nameof(StudentSubject.Subject))]
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; } = new HashSet<StudentSubject>();
        [InverseProperty(nameof(InstructorSubject.Subject))]
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; } = new HashSet<InstructorSubject>();
        [InverseProperty(nameof(DepartmentSubject.Subject))]
        public virtual ICollection<DepartmentSubject> DepartmentsSubjects { get; set; } = new HashSet<DepartmentSubject>();

    }
}
