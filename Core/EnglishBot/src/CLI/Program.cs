using System;
using System.Collections.Generic;
using Domain;
using Telegram.Bot;

namespace CLI
{
  class Program
  {
    static TelegramBotClient Bot;
    static Tutor Tutor;
    static Dictionary<int, string> LastWord = new Dictionary<int, string>();
    private const string COMMAND_LIST = @"Список команд:
/add <eng> <rus> - добавить английское слово и его перевод в словарь
/get - получить случайное английское слово из словаря
/check <eng> <rus> - проверить правильность перевода английского слова";


    static void Main(string[] args)
    {
      Tutor = new Tutor();
      Bot = new TelegramBotClient("token");

      // check bot
      var me = Bot.GetMeAsync().Result;
      Console.WriteLine(me.FirstName);

      // subscribe to receive messages from users
      Bot.OnMessage += Bot_OnMessage;
      Bot.StartReceiving();
      Console.ReadLine();
      Bot.StartReceiving();
    }

    private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
    {
      if (e == null || e.Message == null || e.Message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
      {
        return;
      }
      Console.WriteLine(e.Message.Text);

      var userId = e.Message.From.Id;
      var msgArgs = e.Message.Text.Split(' ');
      string text;
      switch (msgArgs[0])
      {
        case "/start":
          text = COMMAND_LIST;
          break;
        case "/add":
          text = AddWords(msgArgs);
          break;
        case "/get":
          text = GetRandomEngWord(userId);
          var newWord = GetRandomEngWord(userId);
          text = $"{text}. Next word: {newWord}";
          break;
        case "/check":
          text = CheckWord(msgArgs);
          break;
        default:
          if (LastWord.ContainsKey(userId))
          {
            text = CheckWord(LastWord[userId], msgArgs[0]);
            newWord = GetRandomEngWord(userId);
            text = $"{text}. Next word: {newWord}";
          }
          else
          {
            text = COMMAND_LIST;
          }
          break;
      }
      await Bot.SendTextMessageAsync(userId, text);
    }

    private static string GetRandomEngWord(int userId)
    {
      var text = Tutor.GetRandomEngWord();
      if (LastWord.ContainsKey(userId))
      {
        LastWord[userId] = text;
      }
      else
      {
        LastWord.Add(userId, text);
      }
      return text;
    }

    private static string CheckWord(string[] msgArgs)
    {
      if (msgArgs.Length != 3)
      {
        return "Error!";
      }

      return CheckWord(msgArgs[1], msgArgs[2]);
    }

    private static string CheckWord(string eng, string rus)
    {
      if (Tutor.CheckWord(eng, rus))
      {
        return "Correct!";
      }
      var correctAnswer = Tutor.Translate(eng);
      return $"Wrong! The answer is {correctAnswer}";
    }

    static string AddWords(string[] msgArgs)
    {
      if (msgArgs.Length != 3)
      {
        return "Wrong data !";
      }
      else
      {
        Tutor.AddWord(msgArgs[1], msgArgs[2]);
        return "The new word is added";
      }
    }
  }
}
