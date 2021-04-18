using System.ComponentModel;
using WPF.Model;
using WPF.ViewModel.Commands;
using WPF.ViewModel.Helpers;

namespace WPF.ViewModel
{
  public class WeatherVM : INotifyPropertyChanged
  {
    private string query;

    public string Query
    {
      get { return query; }
      set
      {
        query = value;
        OnPropertyChanged("Query");
      }
    }

    private CurrentConditions currentConditions;

    public CurrentConditions CurrentConditions
    {
      get { return currentConditions; }
      set
      {
        currentConditions = value;
        OnPropertyChanged("CurrentConditions");
      }
    }

    private City selectedCity;

    public City SelectedCity
    {
      get { return selectedCity; }
      set
      {
        selectedCity = value;
        OnPropertyChanged("SelectedCity");
      }
    }

    public SearchCommand SearchCommand { get; set; }

    public WeatherVM()
    {
      if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
      {
        SelectedCity = new City { LocalizedName = "Moscow" };
        CurrentConditions = new CurrentConditions
        {
          WeatherText = "Partly cloudy",
          Temperature = new Temperature { Metric = new Units { Value = 21 } }
        };
      }

      SearchCommand = new SearchCommand(this);
    }

    public async void MakeQuery()
    {
      var cities = await AccuWeatherHelper.GetCities(Query);
    }

    /// <inheritdoc />
    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
