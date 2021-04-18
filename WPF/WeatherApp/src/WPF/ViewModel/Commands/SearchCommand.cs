using System;
using System.Windows.Input;

namespace WPF.ViewModel.Commands
{
  public class SearchCommand : ICommand
  {
    public WeatherVM VM { get; set; }

    /// <inheritdoc />
    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public SearchCommand(WeatherVM vm)
    {
      VM = vm;
    }

    /// <inheritdoc />
    public bool CanExecute(object parameter)
    {
      var query = parameter as string;
      if (string.IsNullOrWhiteSpace(query))
      {
        return false;
      }

      return true;
    }

    /// <inheritdoc />
    public void Execute(object? parameter)
    {
      VM.MakeQuery();
    }
  }
}
