using Microsoft.AspNetCore.Mvc;
using CorporateTraining.API.Data;
using CorporateTraining.API.Models;
namespace CorporateTraining.API.Controllers;

[ApiController]
[Route("courses")]
public class CoursesController : ControllerBase
{
  [HttpGet]
public IActionResult GetCourses()
{
    var courses = CourseRepository.GetAllCourses();

    return Ok(courses);
}
[HttpGet("{id:int}")]
public IActionResult GetCourse(int id ){
  var course = CourseRepository.GetAllCourses().FirstOrDefault(c => c.Id == id);
  return Ok(course);
}
[HttpPost]
public IActionResult CreateCourse(TrainingCourse newCourse)
{
  int nextId = (CourseRepository.GetAllCourses().Max(c => (int?)c.Id) ?? 0) + 1;
  newCourse.id = nextId;
  CourseRepository.GetAllCourses().Add(newCourse);
  return Ok(newCourse);
  }

}
}