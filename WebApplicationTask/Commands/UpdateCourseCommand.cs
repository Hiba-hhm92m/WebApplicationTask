using MediatR;
using WebApplicationTask.Models.Entity;

namespace WebApplicationTask.Commands
{
    public class UpdateCourseCommand : IRequest<Course>
    {
        public Course Course { get; set; }

        public UpdateCourseCommand(Course course)
        {
            Course = course;
        }
    }
}
