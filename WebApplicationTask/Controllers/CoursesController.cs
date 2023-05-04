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
    public class CoursesController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper _mapper;

        public CoursesController(IMediator mediator)
        {
            this.mediator = mediator;
            MapperConfiguration config = autoMapperConfig();
            _mapper = config.CreateMapper();
        }

        private MapperConfiguration autoMapperConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseRequestModel>().ReverseMap();
            });
        }

        [HttpGet]
        public async Task<List<Course>> GetCourseListAsync()
        {
            var courseDetails = await mediator.Send(new GetCourseListQuery());

            return courseDetails;
        }

        [HttpGet]
        public async Task<List<StudentCourse>> GetCourseStudentsListAsync(int courseId)
        {
            var courseDetails = await mediator.Send(new GetCourseStudentsQuery(courseId));

            return courseDetails;
        }

        [HttpPost]
        public async Task<Course> AddCourseAsync(CourseRequestModel courseModel)
        {
            var courseDetail = await mediator.Send(new CreateCourseCommand(_mapper.Map<Course>(courseModel)));
            return courseDetail;
        }

        [HttpPut]
        public async Task<Course> UpdateCourseAsync(CourseRequestModel courseModel)
        {
            var courseDetail = await mediator.Send(new UpdateCourseCommand(_mapper.Map<Course>(courseModel)));
            return courseDetail;
        }
    }
}
