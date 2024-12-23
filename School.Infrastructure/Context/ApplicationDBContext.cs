using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using School.Data.Bases;
using School.Data.Entities;
using System.Security.Claims;

namespace School.Infrastructure.Context
{
    public class ApplicationDBContext : DbContext
    {
        private readonly HttpContext _httpContext;
        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options,
            HttpContextAccessor httpContextAccessor
            
            ) : base(options)
        {
            _httpContext = httpContextAccessor.HttpContext;
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

            var userId = _httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ;
         
            var entries = ChangeTracker.Entries<BaseEntity>().Where(e =>
            e.State == EntityState.Deleted
            || e.State == EntityState.Modified
            || e.State == EntityState.Added);
            var timeNow = DateTime.Now;

              foreach(var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = timeNow;
                    entry.Entity.CreatedBy = userId;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedBy = userId;
                    entry.Entity.UpdatedAt=timeNow;
                }
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedAt = timeNow;
                    entry.Entity.DeletedBy = userId;

                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}
