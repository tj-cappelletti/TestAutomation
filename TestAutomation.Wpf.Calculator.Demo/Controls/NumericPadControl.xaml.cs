using System;
using System.Windows;
using System.Windows.Controls;

namespace TestAutomation.Wpf.Calculator.Demo.Controls
{
    /// <summary>
    ///     Interaction logic for NumericPadControl.xaml
    /// </summary>
    public partial class NumericPadControl : UserControl
    {
        public NumericPadControl()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button != null)
                NumberKeyPressed?.Invoke(this, button.Tag as string);
        }

        public event EventHandler<string> NumberKeyPressed;
    }
}