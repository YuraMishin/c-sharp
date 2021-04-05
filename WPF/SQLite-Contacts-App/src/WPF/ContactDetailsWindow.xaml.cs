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
      InitializeComponent();
      _contact = contact;
      NameTextBox.Text = contact.Name;
      EmailTextBox.Text = contact.Email;
      PhoneNumberTextBox.Text = contact.Phone;
    }

    private void Update_OnClick(object sender, RoutedEventArgs e)
    {
      _contact.Name = NameTextBox.Text;
      _contact.Email = EmailTextBox.Text;
      _contact.Phone = PhoneNumberTextBox.Text;
      using var connection = new SQLiteConnection(App.databasePath);
      connection.CreateTable<Contact>();
      connection.Update(_contact);
      Close(); ;
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
