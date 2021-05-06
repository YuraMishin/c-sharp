using Microsoft.EntityFrameworkCore;
using WPF.Models;

namespace WPF.Data
{
  /// <summary>
  /// Class AppDbContext
  /// </summary>
  public class AppDbContext : DbContext
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public AppDbContext()
    {
      Database.EnsureCreated();
    }

    /// <summary>
    /// Employees
    /// </summary>
    public DbSet<Employee> Employees { get; set; }

    /// <summary>
    /// Method sets options
    /// </summary>
    /// <param name="options">options</param>
    public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
    { }
  }
}
