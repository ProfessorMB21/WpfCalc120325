using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCalc120325
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Data _data = new Data();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                if (b.Content.ToString() == ",")
                {
                    if (InOutput.Text.Contains(',')) return;
                    if (_data.IsNew)
                    {
                        InOutput.Text = "0";
                        _data.IsNew = false;
                    }
                }

                if (_data.IsNew) { InOutput.Text = b.Content.ToString(); }
                else InOutput.Text += b.Content.ToString();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InOutput.Text = "0";
            _data.Number = 0;
            _data.IsNew = true;
            _data.Operation = null;
        }

        private void Action_Click(object sender, RoutedEventArgs e)
        {
            double value = 0;
            if (!double.TryParse(InOutput.Text, out value)) return;
            _data.Number = value;

            if (sender is Button b)
            {
                _data.Operation = b.Content switch
                {
                    "+" => Operation.Plus,
                    "-" => Operation.Minus,
                    "×" => Operation.Multiply,
                    "÷" => Operation.Divide,
                    _ => null
                };
                _data.IsNew = true;
            }
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            double secondValue;
            if (!double.TryParse(InOutput.Text, out secondValue)) return;

            double result = _data.Operation switch
            {
                Operation.Plus => _data.Number + secondValue,
                Operation.Minus => _data.Number - secondValue,
                Operation.Multiply => _data.Number * secondValue,
                Operation.Divide => _data.Number / secondValue,
                _ => secondValue
            };

            InOutput.Text = result.ToString();
            if (!_data.IsNew) _data.Number = secondValue;
            _data.IsNew = true;
        }

        private enum Theme { Denis, Marina };
        private Theme T = Theme.Denis;
        private void Theme_Click(object sender, RoutedEventArgs e)
        {
            T = (Theme)(((int)T + 1) % 2);
            var dict = new ResourceDictionary { Source= new Uri(T+".xaml", UriKind.Relative) };
            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(dict);
        }
    }
}