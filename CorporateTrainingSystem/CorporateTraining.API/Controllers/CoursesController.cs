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
  newCourse.Id = nextId;
  CourseRepository.GetAllCourses().Add(newCourse);
  return Ok(newCourse);
  }
  [HttpPut("{id}")]
public IActionResult UpdateCourse(int id, TrainingCourse updatedCourse)
{
  var allCourses = CourseRepository.GetAllCourses();
  var courseToUpdate = allCourses.FirstOrDefault(c => c.Id == id);
  if(courseToUpdate == null){
    return NotFound("Course with the id provided was not provided");
  }
    courseToUpdate.Id = updatedCourse.Id;
    courseToUpdate.Title = updateCourse.Title;
    courseToUpdate.Description = updateCourse.Description;
    courseToUpdate.Duration = updateCourse.Duration;
    courseToUpdate.Instructor = updateCourse.Instructor;
    courseToUpdate.MaxCapacity = updateCourse.MaxCapacity;
    courseToUpdate.Prerequisites = updateCourse.Prerequisites;
   return Ok(courseToUpdate);

}

}
