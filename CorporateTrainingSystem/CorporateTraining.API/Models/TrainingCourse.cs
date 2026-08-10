using System.ComponentModel.DataAnnotations;

namespace CorporateTraining.API.Models;

public class TrainingCourse
{
    public int Id { get; set; }
    [Required]
    [MinLength(2)]
    public string Title { get; set; }


    public string? Description { get; set; }

    [Range(1,1000)]
    public int Duration { get; set; }

    [Required]
    [MinLength(2)]
    public string Instructor { get; set; }

    [Range(1, 1000)]
    public int MaxCapacity { get; set; }

    public string? Prerequisites { get; set; }
}
