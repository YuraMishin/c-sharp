using System;
using System.Windows;
using SQLite;
using WPF.Classes;

namespace WPF
{
  /// <summary>
  /// Логика взаимодействия для ContactDetailsWindow.xaml
  /// </summary>
  public partial class ContactDetailsWindow : Window
  {
    private readonly Contact _contact;

    public ContactDetailsWindow(Contact contact)
    {
      _contact = contact;
      InitializeComponent();
    }

    private void Update_OnClick(object sender, RoutedEventArgs e)
    {
      throw new NotImplementedException();
    }

    private void Delete_OnClick(object sender, RoutedEventArgs e)
    {
      using var connection = new SQLiteConnection(App.databasePath);
      connection.CreateTable<Contact>();
      connection.Delete(_contact);
      Close();
    }
  }
}
