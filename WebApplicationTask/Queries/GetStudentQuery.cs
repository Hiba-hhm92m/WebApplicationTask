using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebApplicationTask.Models.Entity;

namespace WebApplicationTask.Queries
{
    public class GetStudentQuery : IRequest<Student>
    {
        public int StudentId { get; set; }

        public GetStudentQuery(int studentId)
        {
            StudentId = studentId;
        }
    }
}
