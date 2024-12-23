using School.Data.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    [Table("InstructorSubject")]
    public class InstructorSubject : BaseEntity
    {
        public int SubjectIs { get; set; }
        public int InstructorId { get; set; }
        [InverseProperty(nameof(Instructor.InstructorSubjects))]
        public Instructor Instructor { get; set; } = default!;

        public Subject Subject { get; set; } = default!;

    }
}
