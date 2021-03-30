using Zadanie3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        List<Student> students = new List<Student>();

        public StudentController()
        {
            var studentStrings = System.IO.File.ReadAllLines(@"Data/Data.csv");
            foreach (var studentString in studentStrings)
            {
                var student = studentString.Split(',');
                students.Add(new Student
                {
                    FirstName = student[0],
                    LastName = student[1],
                    IndexNumber = student[2],
                    DateOFBirth = student[3],
                    Studies = student[4],
                    Form = student[5],
                    Email = student[6],
                    FatherName = student[7],
                    MotherName = student[8]
                }); ;
            }
        }
        [HttpGet("{indexNumber}")]
        public IActionResult GetStudent(string indexNumber)
        {
            var res = students.Where(st => st.IndexNumber == indexNumber).FirstOrDefault();
            return Ok(res.ToString());
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            string res = "";
            students.ForEach(st => res += st.ToString());
            return Ok(res);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            students.Add(student);
            return Ok(student);
        }

        [HttpPut("{indexNumber}")]
        public IActionResult UpdateStudent(string indexNumber)
        {
            return Ok("Student was updated");
        }

        [HttpDelete("{indexNumber}")]
        public IActionResult DeleteStudent(string indexNumber)
        {
            return Ok("Student was deleted");
        }

    }
}