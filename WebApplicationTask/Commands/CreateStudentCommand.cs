using MediatR;
using WebApplicationTask.Models.Entity;

namespace WebApplicationTask.Commands
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public Student Student { get; set; }

        public CreateStudentCommand(Student student)
        {
            Student = student;
        }
    }
}
