using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebApplicationTask.Models.Entity;

namespace WebApplicationTask.Queries
{
    public class GetCourseStudentsQuery : IRequest<List<StudentCourse>>
    {
        public int CourseId { get; set; }

        public GetCourseStudentsQuery(int courseId)
        {
            CourseId = courseId;
        }
    }
}
