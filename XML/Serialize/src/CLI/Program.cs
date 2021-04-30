using System;
using System.IO;
using System.Xml.Serialization;

namespace CLI
{
  class Program
  {
    /// <summary>
    /// Method serializes the object
    /// </summary>
    /// <param name="worker">worker</param>
    /// <param name="path">path</param>
    static void SerializeWorker(Worker worker, string path)
    {
      var xmlSerializer = new XmlSerializer(typeof(Worker));
      using var fStream = new FileStream(path, FileMode.Create, FileAccess.Write);
      xmlSerializer.Serialize(fStream, worker);
    }

    /// <summary>
    /// The application entry point
    /// </summary>
    /// <param name="args">args</param>
    static void Main(string[] args)
    {
      var worker = new Worker() { FirstName = "Ivan", LastName = "Ivanov" };
      SerializeWorker(worker, "Ivanov.xml");
      Console.WriteLine("Serialization is completed");
      Console.ReadKey();
    }
  }
}
