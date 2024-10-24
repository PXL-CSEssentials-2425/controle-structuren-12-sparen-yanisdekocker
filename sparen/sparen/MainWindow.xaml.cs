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

namespace sparen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            weekmoneyTextBox.Clear();
            increaseTextBox.Clear();
            desiredTextBox.Clear();
            resultTextBox.Clear();
            resultTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            decimal weeklyAmount = 0.0M;
            decimal weeklyIncrement = 0.0M;
            decimal desiredAmount = 0.0M;

            bool hasFailed = !decimal.TryParse(weekmoneyTextBox.Text, out weeklyAmount) ||
                !decimal.TryParse(increaseTextBox.Text, out weeklyIncrement) ||
                !decimal.TryParse(desiredTextBox.Text, out desiredAmount);


            if (hasFailed)
            {
                clearButton_Click(this, null);
                return;
            }

            decimal savings = 0.0M;
            decimal extraWeeklyAmount = 0.0M;
            decimal totalSavings = 0.0M;
            int numberOfWeeks = 0;
            do
            {
                savings += weeklyAmount;
                extraWeeklyAmount += weeklyIncrement;
                totalSavings = savings + extraWeeklyAmount;
                numberOfWeeks++;
            } while (totalSavings < desiredAmount);

            resultTextBox.Text = $"Spaarbedrag na {numberOfWeeks} weken: {savings:c}\r\n\r\n" +
                $"Extra weekgeld op dat moment: {extraWeeklyAmount:c}\r\n\r\n" +
                $"Totaal spaargeld: {totalSavings:c}";
        }
    }
}