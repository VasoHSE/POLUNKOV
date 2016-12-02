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
using Main_Logic;
using System.Windows.Controls.DataVisualization.Charting;

namespace UserGraphShow
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

        private void button_Click(object sender, RoutedEventArgs e)
        {

           // var repo = new GetUserGraphUnfoInfo();
            var b = GetUserGraphUnfoInfo.FindXY("../../../Main_Logic/image.png");
            var X = b[0];
            var Y = b[1];
            LineSeries ls = new LineSeries();
            ls.IndependentValueBinding = new Binding("Key");
            ls.DependentValueBinding = new Binding("Value");
            var a = new KeyValuePair<int, int>[40];
            for (int i = 0; i < 40; i++)
            {
                a[i] = new KeyValuePair<int, int>(X[i], Y[i]);
            }
            ls.ItemsSource = a;

            Chart.Series.Clear();
            Chart.Series.Add(ls);
        }
    }
}
