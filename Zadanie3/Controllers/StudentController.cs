using Zadanie3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet("{indexNumber}")]
        public async Task<IActionResult> GetStudents(String indexNumber)
        {
           
            return Ok(" ");
        }

        //HttpPatch 
        [HttpGet]
        public async Task<IActionResult> GetStudentsAsync()
        {
            String dane = await System.IO.File.ReadAllTextAsync(@".\Data\Data.csv");

            return Ok(dane);

        }
        //HttpPost
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.indexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }
        //HttpPut
        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            return Ok("Aktualizacja dokonczona");
        }
        //HttpDelete
        [HttpDelete]
        public IActionResult DeleteStudent(Student student)
        {
            return Ok("Usuwanie dokonczone");
        }

        //https://localhost:44339/api/students/?indexNumber=s1234


    }
}