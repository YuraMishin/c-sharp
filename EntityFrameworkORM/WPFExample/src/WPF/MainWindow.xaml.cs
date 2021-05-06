using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using WPF.Data;
using WPF.Models;

namespace WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private AppDbContext _context;
    public MainWindow()
    {
      InitializeComponent();
      var optInMemory = new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(databaseName: "test.db")
        .Options;
      _context = new AppDbContext(optInMemory);
      _context.Employees.AddRange(new List<Employee>
      {
        new Employee
        {
          Name = "Name1"
        },
        new Employee
        {
          Name = "Name2"
        }
      });
      _context.SaveChanges();
    }

    private void LoadData_Click(object sender, RoutedEventArgs e)
    {
      lvEmployees.ItemsSource = _context.Employees.ToList();
    }

  }
}
