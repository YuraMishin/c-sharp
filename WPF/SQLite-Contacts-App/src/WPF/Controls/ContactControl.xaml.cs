using System.Windows;
using System.Windows.Controls;
using WPF.Classes;

namespace WPF.Controls
{
  /// <summary>
  /// Логика взаимодействия для ContactControl.xaml
  /// </summary>
  public partial class ContactControl : UserControl
  {
    public Contact Contact
    {
      get { return (Contact)GetValue(ContentProperty); }
      set { SetValue(ContentProperty, value); }
    }

    public static readonly DependencyProperty ContactProperty =
      DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(
        new Contact
        {
          Name = "Name Lastname",
          Email = "user@mail.ru",
          Phone = "(123) 456 7890"
        }, SetText));

    private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var control = d as ContactControl;
      if (control != null)
      {
        control.NameTextBlock.Text = (e.NewValue as Contact).Name;
        control.EmailTextBlock.Text = (e.NewValue as Contact).Email;
        control.PhoneTextBlock.Text = (e.NewValue as Contact).Phone;
      }
    }


    public ContactControl()
    {
      InitializeComponent();
    }
  }
}
