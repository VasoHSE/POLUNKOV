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
            var b = GetUserGraphUnfoInfo.FindXY("../../../Main_Logic/image.jpeg");
            var X = b[0];
            var Y = b[1];
            LineSeries ls = new LineSeries();
            ls.IndependentValueBinding = new Binding("Key");
            ls.DependentValueBinding = new Binding("Value");
            var a = new KeyValuePair<int, int>[GetUserGraphUnfoInfo.Pointamount];
            for (int i = 0; i < GetUserGraphUnfoInfo.Pointamount; i++)
            {
                a[i] = new KeyValuePair<int, int>(X[i], Y[i]);
            }
            ls.ItemsSource = a;
            Chart.Series.Clear();
           
            Chart.Series.Add(ls);
          
            //var c = GetUserGraphUnfoInfo.KoefArray("../../../Main_Logic/image.jpeg");
            //int fgfg = 3;
        }

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    var k = new int[] { 1, 2 };
        //    var X= new int[] { 1,2,3};
        //    var Y = new int[] { X[0], (X[1] - X[0]) * k[0], (X[2]-X[1])*k[1]+(X[1]-X[0])*k[0] };
        //    LineSeries ls = new LineSeries();
        //    ls.IndependentValueBinding = new Binding("Key");
        //    ls.DependentValueBinding = new Binding("Value");
        //    var a = new KeyValuePair<int, int>[GetUserGraphUnfoInfo.Pointamount];
        //    for (int i = 0; i < 3; i++)
        //    {
        //        a[i] = new KeyValuePair<int, int>(X[i], Y[i]);
        //    }
        //    ls.ItemsSource = a;
        //    Chart.Series.Clear();
        //    Chart.Series.Add(ls);


        //}
    }
}
