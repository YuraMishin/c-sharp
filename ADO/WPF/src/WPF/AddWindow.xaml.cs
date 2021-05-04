using System.Data;
using System.Windows;

namespace WPF
{
  /// <summary>
  /// Логика взаимодействия для AddWindow.xaml
  /// </summary>
  public partial class AddWindow : Window
  {
    public AddWindow()
    {
      InitializeComponent();
    }

    public AddWindow(DataRow row) : this()
    {
      cancelBtn.Click += delegate { this.DialogResult = false; };
      okBtn.Click += delegate
      {
        row["Name"] = txtName.Text;
        this.DialogResult = !false;
      };
    }
  }
}
