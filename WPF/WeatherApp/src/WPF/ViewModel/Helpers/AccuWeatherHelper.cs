using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WPF.Model;

namespace WPF.ViewModel.Helpers
{
  public class AccuWeatherHelper
  {
    public const string BASE_URL = "curl -X GET "http://dataservice.accuweather.com/";
    public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
    public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
    public const string API_KEY = "afmroIUQaazo4aEveaKYeaSGjCZ4Ld5V";

    public static async Task<List<City>> GetCities(string query)
    {
      var cities = new List<City>();
      var url = $"{BASE_URL}{string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query)}";
      using var client = new HttpClient();
      var response = await client.GetAsync(url);
      var json = await response.Content.ReadAsStringAsync();
      cities = JsonConvert.DeserializeObject<List<City>>(json);

      return cities;
    }

    public static async Task<CurrentConditions> GetCurrentConditions(string cityKey)
    {
      var currentConditions = new CurrentConditions();
      var url = $"{BASE_URL}{string.Format(CURRENT_CONDITIONS_ENDPOINT, cityKey, API_KEY)}";
      using var client = new HttpClient();
      var response = await client.GetAsync(url);
      var json = await response.Content.ReadAsStringAsync();
      currentConditions = (JsonConvert.DeserializeObject<List<CurrentConditions>>(json)).FirstOrDefault();

      return currentConditions;
    }
  }
}
