using Lessons.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Lessons.Infrastructure;
public class LessonsDbContext : DbContext
{
    public LessonsDbContext()
    {
        
    }

    public LessonsDbContext(DbContextOptions<LessonsDbContext> options) : base(options)
    {
        
    }
    
    // DbSets
    
    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Supervisor> Supervisors { get; set; } = null!;
    public DbSet<Lesson> Lessons { get; set; } = null!;
    public DbSet<PracticalLesson> PracticalLessons { get; set; } = null!;
    public DbSet<Lecture> Lectures { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=lessons;Username=postgres;Password=postgres");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //настройки
        modelBuilder.Entity<Group>().HasIndex(u => u.Number).IsUnique();

    }
}