using System.Collections.Generic;

namespace WPF.Classes
{
  public class WeatherExample
  {
    public string Temperature { get; set; }
    public string Wind { get; set; }
    public string Description { get; set; }
    public List<Forecast> Forecast { get; set; }
  }
}
