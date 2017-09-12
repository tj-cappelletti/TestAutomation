using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestAutomation.Wpf.Calculator.Demo.Controls
{
    /// <summary>
    /// Interaction logic for MathOperationsControl.xaml
    /// </summary>
    public partial class MathOperationsControl : UserControl
    {
        public enum Evaluate
        {
            Equals,
            Percent,
            PlusMinus
        }
        public MathOperationsControl()
        {
            InitializeComponent();
        }

        private void EvaluateButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button == null) return;

            var tag = button.Tag as string;

            if (tag == null) return;

            EvaluateOperation?.Invoke(this, (Evaluate)Enum.Parse(typeof(Evaluate), tag));
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button != null)
                PerformOperation?.Invoke(this, button.Tag as string);
        }

        public event EventHandler<Evaluate> EvaluateOperation;
        public event EventHandler<string> PerformOperation;
    }
}
