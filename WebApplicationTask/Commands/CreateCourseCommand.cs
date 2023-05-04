using MediatR;
using WebApplicationTask.Models.Entity;

namespace WebApplicationTask.Commands
{
    public class CreateCourseCommand : IRequest<Course>
    {
        public Course Course { get; set; }

        public CreateCourseCommand(Course course)
        {
            Course = course;
        }
    }
}
