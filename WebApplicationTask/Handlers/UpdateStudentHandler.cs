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
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly IRepositoryWrapper _repository;
        public UpdateStudentHandler(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public async Task<Student> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = command.Student;

            return _repository.Student.UpdateEntity(studentDetails);
        }
    }
}
