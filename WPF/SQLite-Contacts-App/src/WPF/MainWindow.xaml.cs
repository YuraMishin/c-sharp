using System.Collections.Generic;
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
      List<Contact> contacts;
      using var conn = new SQLiteConnection(App.databasePath);
      conn.CreateTable<Contact>();
      contacts = conn.Table<Contact>().ToList();

      if (contacts != null)
      {
        //foreach (var contact in contacts)
        //{
        //  ContactsListView.Items.Add(new ListViewItem
        //  {
        //    Content = contact
        //  });
        //}
        ContactsListView.ItemsSource = contacts;
      }
    }
  }
}
