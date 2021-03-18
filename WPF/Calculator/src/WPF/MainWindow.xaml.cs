using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    double num1;
    double num2;
    string op = "";

    /// <summary>
    /// Constructor
    /// </summary>
    public MainWindow()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Method adds a digit
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void btn_num_Click(object sender, RoutedEventArgs e)
    {
      var button = (Button)sender;
      var num = button.Content.ToString();
      if (txtValue.Text == "0")
      {
        txtValue.Text = num;
      }
      else
      {
        txtValue.Text += num;
      }
      if (op == "")
      {
        num1 = Double.Parse(txtValue.Text);
      }
      else
      {
        num2 = Double.Parse(txtValue.Text);
      }
    }

    /// <summary>
    /// Method sets selected operation
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void btn_opt_Click(object sender, RoutedEventArgs e)
    {
      var button = (Button)sender;
      op = button.Content.ToString();
      txtValue.Text = "0";
    }

    /// <summary>
    /// Method calculates the result
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void btn_eq_Click(object sender, RoutedEventArgs e)
    {
      double result = 0;
      switch (op)
      {
        case "+":
          result = num1 + num2;
          break;
        case "-":
          result = num1 - num2;
          break;
        case "*":
          result = num1 * num2;
          break;
        case "/":
          result = num1 / num2;
          break;
        case "min":
          result = Math.Min(num1, num2);
          break;
        case "max":
          result = Math.Max(num1, num2);
          break;
        case "avg":
          result = (num1 + num2) / 2;
          break;
        case "x^y":
          result = Pow(num1, (int)num2);
          break;
      }
      txtValue.Text = result.ToString();
      op = "";
      num1 = result;
      num2 = 0;
    }

    /// <summary>
    /// Method powers the statement
    /// </summary>
    /// <param name="x">x</param>
    /// <param name="y">y</param>
    /// <returns>double</returns>
    private double Pow(double x, int y)
    {
      if (y == 0)
      {
        return x = 1;
      }
      return Pow(x, y - 1) * x;
    }

    /// <summary>
    /// Method handles C button
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void btn_C_Click(object sender, RoutedEventArgs e)
    {
      num1 = 0;
      num2 = 0;
      op = "";
      txtValue.Text = "0";
    }

    /// <summary>
    /// Method handles CE button
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void btn_CE_Click(object sender, RoutedEventArgs e)
    {
      if (op == "")
      {
        num1 = 0;
      }
      else
      {
        num2 = 0;
      }
      txtValue.Text = "0";
    }

    /// <summary>
    /// Method handles Backspace button
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void btn_Backspace_Click(object sender, RoutedEventArgs e)
    {
      txtValue.Text = DropLastChar(txtValue.Text);
      if (op == "")
      {
        num1 = Double.Parse(txtValue.Text);
      }
      else
      {
        num2 = Double.Parse(txtValue.Text);
      }
    }

    /// <summary>
    /// Method resets displayed data
    /// </summary>
    /// <param name="text">text</param>
    /// <returns>string</returns>
    private string DropLastChar(string text)
    {
      if (text.Length == 1)
      {
        text = "0";
      }

      else
      {
        text = text.Remove(text.Length - 1, 1);
        if (text[text.Length - 1] == ',')
        {
          text = text.Remove(text.Length - 1, 1);
        }
      }

      return text;
    }

    /// <summary>
    /// Method handles +- button
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void btn_plusminus_Click(object sender, RoutedEventArgs e)
    {
      if (op == "")
      {
        num1 *= -1;
        txtValue.Text = num1.ToString();
      }
      else
      {
        num2 *= -1;
        txtValue.Text = num2.ToString();
      }
    }

    /// <summary>
    /// Method handles Comma button
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void btn_comma_Click(object sender, RoutedEventArgs e)
    {
      if (op == "")
      {
        SetComma(num1);
      }
      else
      {
        SetComma(num2);
      }
    }

    /// <summary>
    /// Method sets comma
    /// </summary>
    /// <param name="num">num</param>
    private void SetComma(double num)
    {
      if (txtValue.Text.Contains(","))
      {
        return;
      }

      txtValue.Text += ',';
    }
  }
}
