using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

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
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var dialog = new OpenFileDialog();
      dialog.Filter = "Image files (*.png; *.jpg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
      dialog.InitialDirectory =
        Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
      if (dialog.ShowDialog() == true)
      {
        var fileName = dialog.FileName;
        SelectedImage.Source = new BitmapImage(new Uri(fileName));
      }
    }
  }
}
