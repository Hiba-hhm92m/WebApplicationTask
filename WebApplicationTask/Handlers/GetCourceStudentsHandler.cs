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
    public class GetCourceStudentsHandler : IRequestHandler<GetCourseStudentsQuery, List<StudentCourse>>
    {
        private readonly IRepositoryWrapper _repository;
        public GetCourceStudentsHandler(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<List<StudentCourse>> Handle(GetCourseStudentsQuery query, CancellationToken cancellationToken)
        {
            var c = _repository.Course.SearchFor(c => c.Id == query.CourseId, "StudentCourses,StudentCourses.Student").FirstOrDefault();
            return c.StudentCourses.ToList();
        }
    }
}
