using System.Windows;

namespace WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private double lastNumber, result;
    private SelectedOperator _selectedOperator;

    public MainWindow()
    {
      InitializeComponent();
      acButton.Click += AcButton_Click;
      negativeButton.Click += NegativeButton_Click;
      percentageButton.Click += PercentageButton_Click;
      equalButton.Click += EqualButton_Click;
    }

    private void EqualButton_Click(object sender, RoutedEventArgs e)
    {
      double newNumber;
      if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
      {
        switch (_selectedOperator)
        {
          case SelectedOperator.Addition:
            result = SimpleMath.Add(lastNumber, newNumber);
            break;
          case SelectedOperator.Subtraction:
            result = SimpleMath.Subtract(lastNumber, newNumber);
            break;
          case SelectedOperator.Multiplication:
            result = SimpleMath.Multiply(lastNumber, newNumber);
            break;
          case SelectedOperator.Division:
            result = SimpleMath.Divide(lastNumber, newNumber);
            break;
        }

        resultLabel.Content = result.ToString();
      }
    }

    private void PercentageButton_Click(object sender, RoutedEventArgs e)
    {
      double tempNumber;
      if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
      {
        tempNumber = tempNumber / 100;
        if (lastNumber != 0)
        {
          tempNumber *= lastNumber;
        }


        resultLabel.Content = tempNumber.ToString();
      }
    }

    private void NegativeButton_Click(object sender, RoutedEventArgs e)
    {
      if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
      {
        lastNumber = lastNumber * (-1);
        resultLabel.Content = lastNumber.ToString();
      }
    }

    private void AcButton_Click(object sender, RoutedEventArgs e)
    {
      resultLabel.Content = "0";
      result = 0;
      lastNumber = 0;
    }

    private void NumberButton_Click(object sender, RoutedEventArgs e)
    {
      var selectedValue = 0;
      if (sender.Equals(zeroButton))
      {
        selectedValue = 0;
      }
      if (sender.Equals(oneButton))
      {
        selectedValue = 1;
      }
      if (sender.Equals(twoButton))
      {
        selectedValue = 2;
      }
      if (sender.Equals(threeButton))
      {
        selectedValue = 3;
      }
      if (sender.Equals(fourButton))
      {
        selectedValue = 4;
      }
      if (sender.Equals(fiveButton))
      {
        selectedValue = 5;
      }
      if (sender.Equals(sixButton))
      {
        selectedValue = 6;
      }
      if (sender.Equals(sevenButton))
      {
        selectedValue = 7;
      }
      if (sender.Equals(eightButton))
      {
        selectedValue = 8;
      }
      if (sender.Equals(nineButton))
      {
        selectedValue = 9;
      }

      if (resultLabel.Content.ToString().Equals("0"))
      {
        resultLabel.Content = $"{selectedValue}";
      }
      else
      {
        resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
      }
    }

    private void OperationButton_Click(object sender, RoutedEventArgs e)
    {
      if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
      {
        resultLabel.Content = "0";
      }

      if (sender.Equals(plusButton))
      {
        _selectedOperator = SelectedOperator.Addition;
      }
      if (sender.Equals(minusButton))
      {
        _selectedOperator = SelectedOperator.Subtraction;
      }
      if (sender.Equals(multiplicationButton))
      {
        _selectedOperator = SelectedOperator.Multiplication;
      }
      if (sender.Equals(divisionButton))
      {
        _selectedOperator = SelectedOperator.Division;
      }
    }

    private void PointButton_Click(object sender, RoutedEventArgs e)
    {
      if (!resultLabel.Content.ToString().Contains("."))
      {
        resultLabel.Content = $"{resultLabel.Content}.";
      }
    }
  }

  public enum SelectedOperator
  {
    Addition,
    Subtraction,
    Multiplication,
    Division
  }

  public class SimpleMath
  {
    public static double Add(double n1, double n2)
    {
      return n1 + n2;
    }

    public static double Subtract(double n1, double n2)
    {
      return n1 - n2;
    }

    public static double Multiply(double n1, double n2)
    {
      return n1 * n2;
    }

    public static double Divide(double n1, double n2)
    {
      if (n2 == 0)
      {
        MessageBox.Show(
          "Error !",
          "Error!",
          MessageBoxButton.OK,
          MessageBoxImage.Error);
        return 0;
      }

      return n1 / n2;
    }
  }
}
