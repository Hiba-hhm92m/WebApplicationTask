using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTask.Data;
using WebApplicationTask.Models.Entity;
using WebApplicationTask.Repositories.Interfaces;

namespace WebApplicationTask.Repositories.Implementations
{
    public class StudentRepository : RepositoryBase<Student>,IStudentRepository
    {
        public StudentRepository(DbContextClass _DbContext) : base(_DbContext)
        {

        }
    }
}
