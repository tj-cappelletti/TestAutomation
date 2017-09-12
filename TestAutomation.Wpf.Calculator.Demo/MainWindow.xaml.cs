using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using NCalc;
using TestAutomation.Wpf.Calculator.Demo.Controls;

namespace TestAutomation.Wpf.Calculator.Demo
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly StringBuilder _displayStringBuilder;
        private readonly StringBuilder _expressionStringBuilder;
        private const int MaxDisplayLength = 12;

        public MainWindow()
        {
            InitializeComponent();
            _displayStringBuilder = new StringBuilder();
            _expressionStringBuilder = new StringBuilder();
        }

        [SuppressMessage("ReSharper", "LocalizableElement")]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        [SuppressMessage("ReSharper", "StringIndexOfIsCultureSpecific.1")]
        private void MathOperationsControl_OnEvaluateOperation(object sender, MathOperationsControl.Evaluate e)
        {
            if (e == MathOperationsControl.Evaluate.Equals)
            {
                _expressionStringBuilder.Append(_displayStringBuilder);

                var expression = new Expression(_expressionStringBuilder.ToString());
                var result = expression.Evaluate();

                var resultType = result.GetType();

                _displayStringBuilder.Clear();

                var resultString = result.ToString();

                if (string.IsNullOrWhiteSpace(resultString))
                    throw new ArgumentNullException("resultString", "The result string cannot be null or empty string.");

                var length = resultString.Length;
                var decimalIndex = resultString.IndexOf(".");
                var decimalPlaces = MaxDisplayLength - decimalIndex;

                if (decimalIndex == -1)
                    length--;

                if (resultType == typeof(decimal) && length > MaxDisplayLength)
                {
                    result = Math.Round((decimal)result, decimalPlaces);
                }
                else if (resultType == typeof(double) && length > MaxDisplayLength)
                {
                    result = Math.Round((double)result, decimalPlaces);
                }
                else if (resultType == typeof(float))
                {
                    throw new ArgumentException("Unable to handle floating point at this time.");
                }

                _displayStringBuilder.Append(result);

                UpdateDisplay();

                _displayStringBuilder.Clear();
                _expressionStringBuilder.Clear();
            }

            if (e == MathOperationsControl.Evaluate.Percent)
            {
                throw new NotImplementedException();
            }

            if (e == MathOperationsControl.Evaluate.PlusMinus)
            {
                _displayStringBuilder.Insert(0, "-");
                UpdateDisplay();
            }
        }

        private void MathOperationsControl_OnPerformOperation(object sender, string e)
        {
            _expressionStringBuilder.Append(" ");
            _expressionStringBuilder.Append(_displayStringBuilder);
            _expressionStringBuilder.Append(" ");
            _expressionStringBuilder.Append(e);

            _displayStringBuilder.Clear();
        }

        private void NumericPadControl_OnNumberKeyPressed(object sender, string e)
        {
            _displayStringBuilder.Append(e);

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            DisplayLabelTextBlock.Text = _displayStringBuilder.ToString();
        }
    }
}