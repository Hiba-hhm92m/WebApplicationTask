using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebApplicationTask.Models.Entity;

namespace WebApplicationTask.Queries
{
    public class GetStudentCoursesQuery : IRequest<List<StudentCourse>>
    {
        public int StudentId { get; set; }

        public GetStudentCoursesQuery(int studentId)
        {
            StudentId = studentId;
        }
    }
}
