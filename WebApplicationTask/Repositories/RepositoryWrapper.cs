using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTask.Data;
using WebApplicationTask.Repositories.Implementations;
using WebApplicationTask.Repositories.Interfaces;

namespace WebApplicationTask.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DbContextClass _repoContext;
        private IStudentRepository _student;
        private ICourseRepository _course;
        private IStudentCourseRepository _studentCourse;

        public RepositoryWrapper(DbContextClass repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IStudentRepository Student
        {
            get
            {
                if (_student == null)
                {
                    _student = new StudentRepository(_repoContext);
                }
                return _student;
            }
        }

        public ICourseRepository Course
        {
            get
            {
                if (_course == null)
                {
                    _course = new CourseRepository(_repoContext);
                }
                return _course;
            }
        }
        public IStudentCourseRepository StudentCourse
        {
            get
            {
                if (_studentCourse == null)
                {
                    _studentCourse = new StudentCourseRepository(_repoContext);
                }
                return _studentCourse;
            }
        }
    }
}
