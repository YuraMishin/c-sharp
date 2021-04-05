using System.Windows;
using SQLite;
using WPF.Classes;

namespace WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      ReadDatabase();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var newContactWindow = new NewContactWindow();
      newContactWindow.ShowDialog();
      ReadDatabase();
    }

    void ReadDatabase()
    {
      using var conn = new SQLiteConnection(App.databasePath);
      conn.CreateTable<Contact>();
      var contacts = conn.Table<Contact>().ToList();
    }
  }
}
