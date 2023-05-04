using MediatR;
using WebApplicationTask.Models.Entity;

namespace WebApplicationTask.Commands
{
    public class UpdateStudentCommand : IRequest<Student>
    {
        public Student Student { get; set; }

        public UpdateStudentCommand(Student student)
        {
            Student = student;
        }
    }
}
