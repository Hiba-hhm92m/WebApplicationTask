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
    public class GetStudentHandler : IRequestHandler<GetStudentQuery, Student>
    {
        private readonly IRepositoryWrapper _repository;
        public GetStudentHandler(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<Student> Handle(GetStudentQuery query, CancellationToken cancellationToken)
        {
            return _repository.Student.SearchFor(s => s.Id == query.StudentId, "StudentCourses,StudentCourses.Course").FirstOrDefault();
        }
    }
}
