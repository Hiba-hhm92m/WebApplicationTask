using WebApplicationTask.Data;
using WebApplicationTask.Models.Entity;
using WebApplicationTask.Repositories.Interfaces;

namespace WebApplicationTask.Repositories.Implementations
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(DbContextClass _DbContext) : base(_DbContext)
        {

        }
    }
}
