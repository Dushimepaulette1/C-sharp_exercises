using Microsoft.AspNetCore.Mvc;
using CorporateTraining.API.Data;

namespace CorporateTraining.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
  [HttpGet]
public IActionResult GetCourses()
{
    var courses = CourseRepository.GetAllCourses();

    return Ok(courses);
}
}