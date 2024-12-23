using School.Data.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class StudentSubject : BaseEntity
    {
        [Key]
        public int StudSubID { get; set; }
        public int StudID { get; set; }
        public int SubID { get; set; }

        [ForeignKey("StudID")]
        [InverseProperty(nameof(Student.StudentSubjects))]
        public virtual Student Student { get; set; } = default!;

        [ForeignKey("SubID")]
        [InverseProperty(nameof(Subject.StudentsSubjects ))]

        public virtual Subject Subject { get; set; } = default!;

    }
}
    