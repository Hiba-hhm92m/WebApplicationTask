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
    public class GetStudentListHandler : IRequestHandler<GetStudentListQuery, List<Student>>
    {
        private readonly IRepositoryWrapper _repository;
        public GetStudentListHandler(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<List<Student>> Handle(GetStudentListQuery query, CancellationToken cancellationToken)
        {
            return _repository.Student.SearchFor().ToList();
        }
    }
}
