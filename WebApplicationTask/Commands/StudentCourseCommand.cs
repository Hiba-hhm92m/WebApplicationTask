using MediatR;
using WebApplicationTask.Models.Entity;

namespace WebApplicationTask.Commands
{
    public class StudentCourseCommand : IRequest<StudentCourse>
    {
        public StudentCourse StudentCourse { get; set; }

        public StudentCourseCommand(StudentCourse studentCourse)
        {
            StudentCourse = studentCourse;
        }
    }
}
