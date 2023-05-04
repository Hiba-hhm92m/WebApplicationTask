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
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IRepositoryWrapper _repository;
        public CreateStudentHandler(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<Student> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            return _repository.Student.Insert(command.Student);
        }
    }
}
