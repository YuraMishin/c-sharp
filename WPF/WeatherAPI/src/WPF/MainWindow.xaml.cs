using System.Net.Http;
using System.Windows;
using Newtonsoft.Json;
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
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
      var url = "https://goweather.herokuapp.com/weather/Moscow";
      using var client = new HttpClient();
      var response = await client.GetAsync(url);
      var responseString = await response.Content.ReadAsStringAsync();
      var forecast = JsonConvert.DeserializeObject<WeatherExample>(responseString).Forecast;
      ForecastListView.ItemsSource = forecast;
    }
  }
}
