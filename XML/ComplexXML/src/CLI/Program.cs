using System;
using System.Linq;
using System.Xml.Linq;

namespace CLI
{
  /// <summary>
  /// Class Program
  /// </summary>
  class Program
  {
    /// <summary>
    /// The application entry point
    /// </summary>
    /// <param name="args">args</param>
    static void Main(string[] args)
    {
      var xml = System.IO.File.ReadAllText("_weather.xml");
      var col = XDocument.Parse(xml)
                         .Descendants("MMWEATHER")
                         .Descendants("REPORT")
                         .Descendants("TOWN")
                         .Descendants("FORECAST")
                         .ToList();
      foreach (var item in col)
      {
        Console.WriteLine($"\n\n{item}");
      }
      Console.ReadLine();
      Console.Clear();

      foreach (var item in col)
      {
        Console.WriteLine("day: {0} month: {1} year: {2}",
                            item.Attribute("day").Value,
                            item.Attribute("month").Value,
                            item.Attribute("year").Value);
      }
      Console.ReadLine();
      Console.Clear();

      foreach (var item in col)
      {
        Console.WriteLine("min: {0} max: {1}",
                            item.Element("TEMPERATURE").Attribute("min").Value,
                            item.Element("TEMPERATURE").Attribute("max").Value);
      }
      Console.ReadLine();
      Console.Clear();


      var city = XDocument.Parse(xml)
                             .Element("MMWEATHER")
                             .Element("REPORT")
                             .Element("TOWN")
                             .Attribute("sname").Value;
      Console.WriteLine(city);

      var myMMWEATHER = new XElement("MMWEATHER");
      var myTOWN = new XElement("TOWN");
      var myFORECAST = new XElement("FORECAST");
      var myTEMPERATURE = new XElement("TEMPERATURE");
      var xAttributeMin = new XAttribute("min", 7);
      var xAttributeMax = new XAttribute("max", 10);
      myTEMPERATURE.Add(xAttributeMin, xAttributeMax);
      myFORECAST.Add(myTEMPERATURE);
      var xAttributeCityName = new XAttribute("sname", "Москва");
      myTOWN.Add(myFORECAST, xAttributeCityName);
      myTOWN.Add(myFORECAST);
      myTOWN.Add(myFORECAST);
      myTOWN.Add(myFORECAST);
      myMMWEATHER.Add(myTOWN);
      myMMWEATHER.Save("_myWeather.xml");

      Console.ReadKey();
    }
  }
}
