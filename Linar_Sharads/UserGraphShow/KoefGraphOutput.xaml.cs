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
using Main_Logic.GraphProcessing;

namespace UserGraphShow
{
    /// <summary>
    /// Interaction logic for KoefGraphOutput.xaml
    /// </summary>
    public partial class KoefGraphOutput : Window
    {
        private readonly List<List<float>> _list;

        public KoefGraphOutput(List<int[]> b)
        {
            InitializeComponent();
            _list = new GetUserGraphUnfoInfo().EconGraphArray(b);

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var y = _list[0];  // array of x
            var x = _list[1]; // array of y
            var ls = new LineSeries
            {
                IndependentValueBinding = new Binding("Key"),
                DependentValueBinding = new Binding("Value")
            };
            var a = new KeyValuePair<float, float>[x.Count - 1];
            for (var i = 0; i < x.Count - 1; i++)
                a[i] = new KeyValuePair<float, float>(x[i],  y[i]);
            ls.ItemsSource = a;
            Chart.ItemsSource = a;
            //try
            //{
            //    var kek = new DrawByKoef();
            //    var b = kek.XYKOEF();
            //    var x = b[0];
            //    var y = b[1];
            //    var ls = new LineSeries
            //    {
            //        IndependentValueBinding = new Binding("Key"),
            //        DependentValueBinding = new Binding("Value")
            //    };
            //    var a = new KeyValuePair<double, double>[GetUserGraphUnfoInfo.Pointamount];
            //    for (var i = 0; i < GetUserGraphUnfoInfo.Pointamount; i++)
            //        a[i] = new KeyValuePair<double, double>(x[i], y[i]);

            //    ls.ItemsSource = a;
            //    Chart.Series.Clear();
            //    Chart.Series.Add(ls);


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, ":(", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            //    this.Close();

            //}

            // find XY
            // koef
            // 





        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
