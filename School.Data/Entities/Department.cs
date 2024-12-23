using School.Data.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class Department : BaseNamedIdentifiedEntityWithName
    {
     
        public int InstructorManager { get; set; }
        [ForeignKey(nameof(InstructorManager))]
        [InverseProperty(nameof(Instructor.DepartmentManager))]
        public Instructor Instructor { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        [InverseProperty(nameof(Instructor.Department))]
        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        [InverseProperty(nameof(DepartmentSubject.Department))]
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; } = new HashSet<DepartmentSubject>();
    }
}
