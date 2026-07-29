using CorporateTraining.API.Data;
using CorporateTraining.API.Models;

namespace CorporateTraining.API.Services;

public static class CourseService
{
    public static List<TrainingCourse> GetAllCourses()
    {
        return CourseRepository.GetAllCourses();
    }

    public static TrainingCourse? GetCourseById(int id)
    {
        return CourseRepository.GetCourseById(id);
    }

    public static TrainingCourse CreateCourse(TrainingCourse newCourse)
    {
        int nextId = (CourseRepository.GetAllCourses().Max(c => (int?)c.Id) ?? 0) + 1;
        newCourse.Id = nextId;
        CourseRepository.GetAllCourses().Add(newCourse);
        return newCourse;
    }

    public static TrainingCourse? UpdateCourse(int id, TrainingCourse updatedCourse)
    {
        var courseToUpdate = CourseRepository.GetCourseById(id);
        if (courseToUpdate == null)
        {
            return null;
        }

        courseToUpdate.Title = updatedCourse.Title;
        courseToUpdate.Description = updatedCourse.Description;
        courseToUpdate.Duration = updatedCourse.Duration;
        courseToUpdate.Instructor = updatedCourse.Instructor;
        courseToUpdate.MaxCapacity = updatedCourse.MaxCapacity;
        courseToUpdate.Prerequisites = updatedCourse.Prerequisites;

        return courseToUpdate;
    }

    public static bool DeleteCourse(int id)
    {
        var courseToDelete = CourseRepository.GetCourseById(id);
        if (courseToDelete == null)
        {
            return false;
        }

        return CourseRepository.RemoveCourse(courseToDelete);
    }
}
