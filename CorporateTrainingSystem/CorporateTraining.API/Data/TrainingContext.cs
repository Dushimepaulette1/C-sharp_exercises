using Microsoft.EntityFrameworkCore;
using CorporateTraining.API.Models;

namespace CorporateTraining.API.Data;

public class TrainingContext : DbContext
{
   public TrainingContext(DbContextOptions<TrainingContext> options)
        : base(options)
    {}
    public DbSet<TrainingCourse> Courses { get; set; }
}