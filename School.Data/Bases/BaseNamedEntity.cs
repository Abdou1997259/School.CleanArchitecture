using System.ComponentModel.DataAnnotations;

namespace School.Data.Bases
{
    public class BaseNamedEntity : BaseEntity
    {
        [StringLength(500)]
        public string NameAr { get; set; } = null!;
        [StringLength(500)]
        public string NameEn { get; set; } = null!;
        public string GetName()
        {
            if (Thread.CurrentThread.Name == "en")
            {
                return NameEn;
            }
            return NameAr;
        }

    }
}
