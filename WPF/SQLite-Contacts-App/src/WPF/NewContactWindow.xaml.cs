using System.Windows;
using SQLite;
using WPF.Classes;

namespace WPF
{
  /// <summary>
  /// Логика взаимодействия для NewContactWindow.xaml
  /// </summary>
  public partial class NewContactWindow : Window
  {
    public NewContactWindow()
    {
      InitializeComponent();
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
      var contact = new Contact
      {
        Name = NameTextBox.Text,
        Email = EmailTextBox.Text,
        Phone = PhoneNumberTextBox.Text
      };


      using var connection = new SQLiteConnection(App.databasePath);
      connection.CreateTable<Contact>();
      connection.Insert(contact);

      Close();
    }
  }
}
