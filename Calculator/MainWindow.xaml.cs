using System;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {
        private string currentInput = "";
        private string currentOperator = "";
        private double result = 0.0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            currentInput += button.Content.ToString();
            Display.Text += button.Content.ToString();
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            if (!string.IsNullOrEmpty(currentInput))
            {
                if (!string.IsNullOrEmpty(currentOperator))
                {
                    Calculate();
                    Display.Text = result.ToString();
                    currentInput = result.ToString();
                }
                else
                {
                    if (double.TryParse(currentInput, out double inputNumber))
                    {
                        result = inputNumber;
                    }
                    else
                    {
                        MessageBox.Show("Invalid input");
                        return;
                    }
                }

                currentOperator = button.Content.ToString();
                Display.Text += $" {currentOperator} ";
                currentInput = "";
            }
            else if (!string.IsNullOrEmpty(currentOperator) && result != 0.0)
            {
                // If there's no current input, use the result and update the operator
                currentOperator = button.Content.ToString();
                Display.Text = $"{result} {currentOperator} ";
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // Clear the current input
            currentInput = "";
            Display.Text = "";
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            // Check if there is an ongoing operation
            if (!string.IsNullOrEmpty(currentInput) && !string.IsNullOrEmpty(currentOperator))
            {
                if (double.TryParse(currentInput, out double inputNumber))
                {
                    Calculate();
                    Display.Text = result.ToString();
                    currentInput = "";
                    // Remove this line if you want to keep the result for further operations
                    // currentOperator = "";
                }
                else
                {
                    MessageBox.Show("Invalid input");
                }
            }
            else
            {
                MessageBox.Show("Invalid operation");
            }
        }

        private void Calculate()
        {
            if (double.TryParse(currentInput, out double inputNumber))
            {
                switch (currentOperator)
                {
                    case "+":
                        result += inputNumber;
                        break;
                    case "-":
                        result -= inputNumber;
                        break;
                    case "*":
                        result *= inputNumber;
                        break;
                    case "/":
                        if (inputNumber != 0)
                            result /= inputNumber;
                        else
                            MessageBox.Show("Cannot divide by zero");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }
    }
}
