using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

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
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      var json = File.ReadAllText("telegram.json");
      Console.WriteLine(json);
      Console.ReadLine();
      Console.Clear();

      Console.WriteLine(JObject.Parse(json)["ok"].ToString());

      var messages = JObject.Parse(json)["result"].ToArray();
      Console.WriteLine();
      foreach (var item in messages)
      {
        Console.WriteLine(item["message"]["message_id"].ToString());
        Console.WriteLine(item["message"]["text"].ToString());
        Console.WriteLine(item["message"]["chat"]["username"].ToString());
        Console.WriteLine();
      }

      Console.ReadKey();

      var array = new JArray();
      var mainTree = new JObject();
      mainTree["ok"] = true;

      var o = new JObject();
      o["update_id"] = 1880746;
      o["message_id"] = 886;
      array.Add(o);
      array.Add(o);
      array.Add(o);
      mainTree["messages"] = array;

      var userObj = new JObject();
      userObj["id"] = 220310598;
      userObj["first_name"] = "С.K.";
      userObj["username"] = "sk";
      mainTree["user"] = userObj;


      string jsonOut = mainTree.ToString();
      Console.WriteLine(jsonOut);
      Console.ReadKey();

      var jArray = new JArray();
      for (int i = 1; i <= 5; i++)
      {
        JObject obj = new JObject
        {
          ["FirstName"] = $"Имя_{i}",
          ["LastName"] = $"Фамилия_{i}",
          ["Position"] = $"Должность_{i}",
          ["Department"] = $"Отдел_{i}",
          ["Salary"] = i * 1000
        };
        jArray.Add(obj);
      }

      Console.WriteLine(jArray.ToString());
      Console.ReadKey();
    }
  }
}
