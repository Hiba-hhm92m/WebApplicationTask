using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationTask.Commands;
using WebApplicationTask.Models.Entity;
using WebApplicationTask.Repositories;

namespace WebApplicationTask.Handlers
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, Course>
    {
        private readonly IRepositoryWrapper _repository;
        public UpdateCourseHandler(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<Course> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
        {
            return _repository.Course.UpdateEntity(command.Course);
        }
    }
}
