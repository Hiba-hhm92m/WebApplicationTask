using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebApplicationTask.Models.Entity;

namespace WebApplicationTask.Queries
{
    public class GetStudentListQuery : IRequest<List<Student>>
    {
    }
}
