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
[HttpGet("{id}")]
public IActionResult GetCourse(int id ){
  var course = CourseRepository.GetCourseById(id);
  if(course == null){
    return NotFound();
  }
  return Ok(course);
}
[HttpPost]
public IActionResult CreateCourse(TrainingCourse newCourse)
{
  int nextId = (CourseRepository.GetAllCourses().Max(c => (int?)c.Id) ?? 0) + 1;
  newCourse.Id = nextId;
  CourseRepository.GetAllCourses().Add(newCourse);
  return Ok(newCourse);
  }
  [HttpPut("{id}")]
public IActionResult UpdateCourse(int id, TrainingCourse updatedCourse)
{
  var courseToUpdate = CourseRepository.GetCourseById(id); 
  if(courseToUpdate == null){
    return NotFound("Course with the id provided was not provided");
  }
    courseToUpdate.Title = updatedCourse.Title;
    courseToUpdate.Description = updatedCourse.Description;
    courseToUpdate.Duration = updatedCourse.Duration;
    courseToUpdate.Instructor = updatedCourse.Instructor;
    courseToUpdate.MaxCapacity = updatedCourse.MaxCapacity;
    courseToUpdate.Prerequisites = updatedCourse.Prerequisites;
   return Ok(courseToUpdate);

}
[HttpDelete("{id}")]
public IActionResult DeleteCourse(int id)
{
  var courseToDelete = CourseRepository.GetCourseById(id);
  if (courseToDelete == null){
    return NotFound("The course with ID doesnot exist");
  }
  CourseRepository.RemoveCourse(courseToDelete);
  return NoContent(); 
  }

}
