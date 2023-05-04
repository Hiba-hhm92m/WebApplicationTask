using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationTask.Commands;
using WebApplicationTask.Models.Entity;
using WebApplicationTask.Repositories;
using WebApplicationTask.Repositories.Interfaces;

namespace WebApplicationTask.Handlers
{
    public class CreateStudentCourseHandler : IRequestHandler<StudentCourseCommand, StudentCourse>
    {
        private readonly IRepositoryWrapper _repository;
        public CreateStudentCourseHandler(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<StudentCourse> Handle(StudentCourseCommand command, CancellationToken cancellationToken)
        {
            return _repository.StudentCourse.Insert(command.StudentCourse);
        }
    }
}
