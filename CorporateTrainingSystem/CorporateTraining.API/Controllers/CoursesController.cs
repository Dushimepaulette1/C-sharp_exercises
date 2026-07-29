using Microsoft.AspNetCore.Mvc;
using CorporateTraining.API.Services;
using CorporateTraining.API.Models;
namespace CorporateTraining.API.Controllers;

[ApiController]
[Route("courses")]
public class CoursesController : ControllerBase
{
  [HttpGet]
public IActionResult GetCourses()
{
    var courses = CourseService.GetAllCourses();
    return Ok(courses);
}
[HttpGet("{id}")]
public IActionResult GetCourse(int id ){
  var course = CourseService.GetCourseById(id);
  if(course == null){
    return NotFound();
  }
  return Ok(course);
}
[HttpPost]
public IActionResult CreateCourse(TrainingCourse newCourse)
{
  var createdCourse = CourseService.CreateCourse(newCourse);
  return Ok(createdCourse);
  }
  [HttpPut("{id}")]
public IActionResult UpdateCourse(int id, TrainingCourse updatedCourse)
{
  var courseToUpdate = CourseService.UpdateCourse(id, updatedCourse);
  if(courseToUpdate == null){
    return NotFound("Course with the id provided was not provided");
  }
   return Ok(courseToUpdate);

}
[HttpDelete("{id}")]
public IActionResult DeleteCourse(int id)
{
  var deleted = CourseService.DeleteCourse(id);
  if (!deleted){
    return NotFound("The course with ID doesnot exist");
  }
  return NoContent();
  }

}
