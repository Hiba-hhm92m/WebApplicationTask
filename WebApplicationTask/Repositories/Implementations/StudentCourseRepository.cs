using WebApplicationTask.Data;
using WebApplicationTask.Models.Entity;
using WebApplicationTask.Repositories.Interfaces;

namespace WebApplicationTask.Repositories.Implementations
{
    public class StudentCourseRepository : RepositoryBase<StudentCourse>, IStudentCourseRepository
    {
        public StudentCourseRepository(DbContextClass _DbContext) : base(_DbContext)
        {

        }
    }
}
