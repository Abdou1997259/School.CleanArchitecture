using School.Data.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class Instructor : BaseNamedIdentfiedWithContactInfo
    {

        public string Postion { get; set; } = string.Empty; 
        public int SupervisorId { get; set; }
        public decimal Salary { get; set; }
        public int DID { get; set; }

        [InverseProperty(nameof(Department.Instructors))]
        public Department Department { get; set; } = default!;
        [InverseProperty(nameof(Department.Instructor))]
        public Department DepartmentManager { get; set; } = default!;

        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty(nameof(Instructors))]

        public Instructor Supervisor { get; set; } = default!;
        [InverseProperty(nameof(Supervisor))]
        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        [InverseProperty(nameof(InstructorSubject.Instructor))]
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; } = new HashSet<InstructorSubject>();

    }
}
