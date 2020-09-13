using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForLesson.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForLesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students;
        public StudentController()
        {
            students = new List<Student>
            {
                new Student {Id = 1, Name = "John", Surname = "Doe", Gpa = 2.5 },
                new Student {Id = 2, Name = "Mark", Surname = "Johnson", Gpa = 3.0},
                new Student {Id = 3, Name = "Nuke", Surname = "Lay", Gpa = 3.1},
                new Student {Id = 4, Name = "Osman", Surname = "Lakshri", Gpa = 2.5},
                new Student {Id =5, Name = "John", Surname = "Kennady", Gpa = 3.33}
            };
        }

        [HttpGet]
        public List<Student> GetStudents()
        {
            return students;
        }

        [HttpGet("getby-id/{id}")]
        public Student GetStudentById(int id)
        {
            return students.Where(student => student.Id == id).FirstOrDefault();
        }

        [HttpGet("getby-name/{name}")]
        public List<Student> GetStudentByName(string name)
        {
            return students.Where(student => student.Name.ToLower() == name.ToLower()).ToList();
        }

        [HttpGet("sortby-gpa/{param}")]
        public List<Student> SortByGpa(string param)
        {
            if (param is "asc")
            {
                return students.OrderBy(student => student.Gpa).ToList();
            }

            return students.OrderByDescending(student => student.Gpa).ToList();
        }
        
    }
}
