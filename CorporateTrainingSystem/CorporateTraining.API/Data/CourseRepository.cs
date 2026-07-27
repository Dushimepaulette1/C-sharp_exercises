using CorporateTraining.API.Models;

namespace CorporateTraining.API.Data;

public static class CourseRepository
{
    public static List<TrainingCourse> GetAllCourses()
    {
        return new List<TrainingCourse>
        {
            new TrainingCourse
            {
                Id = 1,
                Title = "C# Fundamentals",
                Description = "Learn the basics of C# programming.",
                Duration = 20,
                Instructor = "Sarah",
                MaxCapacity = 30,
                Prerequisites = "Basic programming knowledge"
            },

            new TrainingCourse
            {
                Id = 2,
                Title = "ASP.NET Core",
                Description = "Build web applications with ASP.NET.",
                Duration = 25,
                Instructor = "David",
                MaxCapacity = 25,
                Prerequisites = "C# knowledge"
            },

            new TrainingCourse
            {
                Id = 3,
                Title = "React Fundamentals",
                Description = "Learn modern frontend development.",
                Duration = 15,
                Instructor = "Emily",
                MaxCapacity = 40,
                Prerequisites = "JavaScript basics"
            }
        };
    }
}