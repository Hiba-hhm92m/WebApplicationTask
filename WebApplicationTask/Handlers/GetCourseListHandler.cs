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
    public class GetCourseListHandler : IRequestHandler<GetCourseListQuery, List<Course>>
    {
        private readonly IRepositoryWrapper _repository;
        public GetCourseListHandler(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<List<Course>> Handle(GetCourseListQuery query, CancellationToken cancellationToken)
        {
            return _repository.Course.SearchFor().ToList();
        }
    }
}
