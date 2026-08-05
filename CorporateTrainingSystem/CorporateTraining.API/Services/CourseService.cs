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
        return courses.Select(course => new CourseDto
    {
        Id = course.Id,
        Title = course.Title,
        Description = course.Description,
        Duration = course.Duration,
        Instructor = course.Instructor,
        MaxCapacity = course.MaxCapacity,
        Prerequisites = course.Prerequisites

    }).ToList();
    }


    public CourseDto? GetCourseById(int id)
    {
       var course = _context.Courses.FirstOrDefault(c => c.Id == id);
       if (course == null){
        return null;
       }
       return new CourseDto
       {
        Id = course.Id,
        Title = course.Title,
        Description = course.Description,
        Duration = course.Duration,
        Instructor = course.Instructor,
        MaxCapacity = course.MaxCapacity,
        Prerequisites = course.Prerequisites
       };
    }

    public CourseDto CreateCourse(CreateCourseDto dto)
    {
        var course = new TrainingCourse
    {
        Title = dto.Title,
        Description = dto.Description,
        Duration = dto.Duration,
        Instructor = dto.Instructor,
        MaxCapacity = dto.MaxCapacity,
        Prerequisites = dto.Prerequisites
    };
        _context.Courses.Add(course);
        _context.SaveChanges();

        return new CourseDto
    {
        Id = course.Id,
        Title = course.Title,
        Description = course.Description,
        Duration = course.Duration,
        Instructor = course.Instructor,
        MaxCapacity = course.MaxCapacity,
        Prerequisites = course.Prerequisites
    };
    }

    public CourseDto? UpdateCourse(int id, CreateCourseDto dto)
    {
        var course = _context.Courses.FirstOrDefault(c => c.Id == id);

        if (course == null)
        {
            return  null;
        }

        course.Title = dto.Title;
        course.Description = dto.Description;
        course.Duration = dto.Duration;
        course.Instructor = dto.Instructor;
        course.MaxCapacity = dto.MaxCapacity;
        course.Prerequisites = dto.Prerequisites;

        _context.SaveChanges();

        return new CourseDto
    {
        Id = course.Id,
        Title = course.Title,
        Description = course.Description,
        Duration = course.Duration,
        Instructor = course.Instructor,
        MaxCapacity = course.MaxCapacity,
        Prerequisites = course.Prerequisites
    };
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