using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationTask.Commands;
using WebApplicationTask.Models.Entity;
using WebApplicationTask.Repositories;

namespace WebApplicationTask.Handlers
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, Course>
    {
        private readonly IRepositoryWrapper _repository;
        public CreateCourseHandler(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<Course> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
        {
            return _repository.Course.Insert(command.Course);
        }
    }
}
