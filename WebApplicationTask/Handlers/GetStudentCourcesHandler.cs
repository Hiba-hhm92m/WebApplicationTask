using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationTask.Models.Entity;
using WebApplicationTask.Queries;
using WebApplicationTask.Repositories;
using WebApplicationTask.Repositories.Interfaces;

namespace WebApplicationTask.Handlers
{
    public class GetStudentCourcesHandler : IRequestHandler<GetStudentCoursesQuery, List<StudentCourse>>
    {
        private readonly IRepositoryWrapper _repository;
        public GetStudentCourcesHandler(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<List<StudentCourse>> Handle(GetStudentCoursesQuery query, CancellationToken cancellationToken)
        {
            var s = _repository.Student.SearchFor(s => s.Id== query.StudentId, "StudentCourses,StudentCourses.Course").FirstOrDefault();
            return s.StudentCourses.ToList();
        }
    }
}
