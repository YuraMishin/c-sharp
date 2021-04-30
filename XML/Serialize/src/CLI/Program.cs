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
    /// Method deserializes the object
    /// </summary>
    /// <param name="path">path</param>
    /// <returns>Worker</returns>
    static Worker DeserializeWorker(string path)
    {
      var xmlSerializer = new XmlSerializer(typeof(Worker));
      using var fStream = new FileStream(path, FileMode.Open, FileAccess.Read);
      return xmlSerializer.Deserialize(fStream) as Worker;
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
      worker = DeserializeWorker("Ivanov.xml");
      Console.WriteLine("Deserialization is completed");
      Console.WriteLine(worker);
      Console.ReadKey();
    }
  }
}
