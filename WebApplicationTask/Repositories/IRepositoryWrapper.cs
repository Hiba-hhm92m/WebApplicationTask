using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTask.Repositories.Interfaces;

namespace WebApplicationTask.Repositories
{
    public interface IRepositoryWrapper
    {
        IStudentRepository Student { get; }
        ICourseRepository Course { get; }
        IStudentCourseRepository StudentCourse { get; }
    }
}
