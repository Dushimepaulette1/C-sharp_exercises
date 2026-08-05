public class CourseService
{
    private readonly TrainingContext _context;

    public CourseService(TrainingContext context)
    {
        _context = context;
    }

    public List<TrainingCourse> GetAllCourses()
    {
        return _context.Courses.ToList();
    }

    public TrainingCourse? GetCourseById(int id)
    {
        return _context.Courses.FirstOrDefault(c => c.Id == id);
    }

    public TrainingCourse CreateCourse(TrainingCourse course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();

        return course;
    }

    public bool UpdateCourse(int id, TrainingCourse updatedCourse)
    {
        var course = _context.Courses.FirstOrDefault(c => c.Id == id);

        if (course == null)
            return false;

        course.Title = updatedCourse.Title;
        course.Description = updatedCourse.Description;
        course.Duration = updatedCourse.Duration;
        course.Instructor = updatedCourse.Instructor;
        course.MaxCapacity = updatedCourse.MaxCapacity;
        course.Prerequisites = updatedCourse.Prerequisites;

        _context.SaveChanges();

        return true;
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