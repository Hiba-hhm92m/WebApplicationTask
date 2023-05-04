using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebApplicationTask.Models.Entity;
using WebApplicationTask.Models.RequestModel;
using WebApplicationTask.Queries;
using WebApplicationTask.Commands;
using AutoMapper;

namespace WebApplicationTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper _mapper;

        public StudentsController(IMediator mediator)
        {
            this.mediator = mediator;
            MapperConfiguration config = autoMapperConfig();
            _mapper = config.CreateMapper();
        }

        private MapperConfiguration autoMapperConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentRequestModel>().ReverseMap();
                cfg.CreateMap<StudentCourse, StudentCourseRequestModel>().ReverseMap();
            });
        }

        [HttpGet]
        public async Task<Student> GetStudentAsync(int studentId)
        {
            var studentDetails = await mediator.Send(new GetStudentQuery(studentId));

            return studentDetails;
        }

        [HttpGet]
        public async Task<List<Student>> GetStudentListAsync()
        {
            var studentDetails = await mediator.Send(new GetStudentListQuery());

            return studentDetails;
        }

        [HttpGet]
        public async Task<List<StudentCourse>> GetStudentCoursesListAsync(int studentId)
        {
            var studentDetails = await mediator.Send(new GetStudentCoursesQuery(studentId));

            return studentDetails;
        }

        [HttpPost]
        public async Task<Student> AddStudentAsync(StudentRequestModel studentModel)
        {
            var studentDetail = await mediator.Send(new CreateStudentCommand(_mapper.Map<Student>(studentModel)));
            return studentDetail;
        }

        [HttpPost]
        public async Task<StudentCourse> RegisterStudentToCourseAsync(StudentCourseRequestModel studentCourseModel)
        {
            var studentCourseDetail = await mediator.Send(new StudentCourseCommand(_mapper.Map<StudentCourse>(studentCourseModel)));
            return studentCourseDetail;
        }

        [HttpPut]
        public async Task<Student> UpdateStudentAsync(StudentRequestModel studentModel)
        {
            var studentDetail = await mediator.Send(new UpdateStudentCommand(_mapper.Map<Student>(studentModel)));
            return studentDetail;
        }

    }
}
