using CorporateTraining.API.DTOs;
using CorporateTraining.API.Models;

namespace CorporateTraining.API.Mappers;

public static class CourseMapper
{
    public static CourseDto ToDto(TrainingCourse course)
    {
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


    public static TrainingCourse ToEntity(CreateCourseDto dto)
    {
        return new TrainingCourse
        {
            Title = dto.Title,
            Description = dto.Description,
            Duration = dto.Duration,
            Instructor = dto.Instructor,
            MaxCapacity = dto.MaxCapacity,
            Prerequisites = dto.Prerequisites
        };
    }
}