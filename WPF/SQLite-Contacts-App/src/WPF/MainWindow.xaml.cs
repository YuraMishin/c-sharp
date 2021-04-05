using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SQLite;
using WPF.Classes;

namespace WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    List<Contact> contacts;

    public MainWindow()
    {
      contacts = new List<Contact>();
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
      contacts = (conn.Table<Contact>().ToList())
        .OrderBy(contact => contact.Name)
        .ToList();

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

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      var searchTextBox = sender as TextBox;
      var filteredList = contacts
        .Where(contact => contact.Name.ToLower().Contains(searchTextBox.Text.ToLower()))
        .ToList();

      var filteredList2 = (
        from contact in contacts
        where contact.Name.ToLower().Contains(searchTextBox.Text.ToLower())
        orderby contact.Email
        select contact
        ).ToList();

      ContactsListView.ItemsSource = filteredList;

    }
  }
}
