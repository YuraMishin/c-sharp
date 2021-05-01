using System;
using System.Net;
using System.Text;

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
      string url = @"YuraMishin/c-sharp/main/img/avatar.jpg";
      var webClient = new WebClient() { Encoding = Encoding.UTF8 };
      webClient.BaseAddress = "https://raw.githubusercontent.com/";
      webClient.DownloadFile(url, "avatar.jpg");
      Console.WriteLine("Download is completed");
      Console.ReadKey();
    }
  }
}
