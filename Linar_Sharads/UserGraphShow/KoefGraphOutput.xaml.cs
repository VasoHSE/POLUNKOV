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
using System.Windows.Shapes;
using Main_Logic;
using System.Windows.Controls.DataVisualization.Charting;
namespace UserGraphShow
{
    /// <summary>
    /// Interaction logic for KoefGraphOutput.xaml
    /// </summary>
    public partial class KoefGraphOutput : Window
    {
        public KoefGraphOutput()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var kek = new DrawByKoef();
                var b = kek.XYKOEF();
                var x = b[0];
                var y = b[1];
                var ls = new LineSeries
                {
                    IndependentValueBinding = new Binding("Key"),
                    DependentValueBinding = new Binding("Value")
                };
                var a = new KeyValuePair<double, double>[GetUserGraphUnfoInfo.Pointamount];
                for (var i = 0; i < GetUserGraphUnfoInfo.Pointamount; i++)
                    a[i] = new KeyValuePair<double, double>(x[i], y[i]);

                ls.ItemsSource = a;
                Chart.Series.Clear();
                Chart.Series.Add(ls);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ":(", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                this.Close();

            }

        }
    }
}
