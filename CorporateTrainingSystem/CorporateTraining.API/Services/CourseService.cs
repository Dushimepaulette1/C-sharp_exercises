using CorporateTraining.API.Data;
using CorporateTraining.API.DTOs;
using CorporateTraining.API.Mappers;

public class CourseService
{
    private readonly TrainingContext _context;

    public CourseService(TrainingContext context)
    {
        _context = context;
    }

    public List<CourseDto> GetAllCourses()
    {
        var courses = _context.Courses.ToList();
        return courses.Select(CourseMapper.ToDto).ToList();
    }


    public CourseDto? GetCourseById(int id)
    {
       var course = _context.Courses.FirstOrDefault(c => c.Id == id);
       if (course == null){
        return null;
       }
       return CourseMapper.ToDto(course);
    }

    public CourseDto CreateCourse(CreateCourseDto dto)
    {
        var course = CourseMapper.ToEntity(dto);
        _context.Courses.Add(course);
        _context.SaveChanges();

        return CourseMapper.ToDto(course);
    }

    public CourseDto? UpdateCourse(int id, UpdateCourseDto dto)
    {
        var course = _context.Courses.FirstOrDefault(c => c.Id == id);

        if (course == null)
        {
            return  null;
        }

        course.Title = dto.Title;
        course.Description = dto.Description;
        course.Duration = dto.Duration ?? course.Duration;
        course.Instructor = dto.Instructor;
        course.MaxCapacity = dto.MaxCapacity ?? course.MaxCapacity;
        course.Prerequisites = dto.Prerequisites;

        _context.SaveChanges();

        return CourseMapper.ToDto(course);
    }

    public bool DeleteCourse(int id)
    {
        var course = _context.Courses.FirstOrDefault(c => c.Id == id);

        if (course == null)
            return false;

        _context.Courses.Remove(course);
        _context.SaveChanges();

        return true;
    }
}
