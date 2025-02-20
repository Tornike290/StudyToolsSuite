using Microsoft.EntityFrameworkCore;
using StudyToolsSuite.Models;

namespace StudyToolsSuite.Context;

public class ApplicationDbContext : DbContext 
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    public DbSet<Models.User> Users { get; set; }
}