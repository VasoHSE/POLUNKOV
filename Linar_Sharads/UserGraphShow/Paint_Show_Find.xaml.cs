using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using  Main_Logic;
using System.Windows.Controls.DataVisualization.Charting;
namespace UserGraphShow
{
    /// <summary>
    /// Interaction logic for Paint_Show_Find.xaml
    /// </summary>
    public partial class Paint_Show_Find : Window
    {

        private List<int[]> _b;
        public Paint_Show_Find()
        {
            InitializeComponent();
            ShowGraph();
            FindGraph(_b);
        }
       

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FindGraph(_b);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private  void  ShowGraph()
        {
            _b = GetUserGraphUnfoInfo.FindXy(GetUserGraphUnfoInfo.Path);
            var x = _b[0];  // array of x
            var y = _b[1]; // array of y
            //var ls = new LineSeries
            //{
            //    IndependentValueBinding = new Binding("Key"),
            //    DependentValueBinding = new Binding("Value")
            //};
            var a = new KeyValuePair<int, int>[x.Length - 1];
            for (var i = 0; i < x.Length - 1; i++)
                a[i] = new KeyValuePair<int, int>(x[i], y[i]);
            //ls.ItemsSource = a;
            UserChart.ItemsSource = a;
        }

        private void FindGraph(List<int[]> b)
        {
             var _list = new GetUserGraphUnfoInfo().EconGraphArray(b);
            var y = _list[0];  // array of x
            var x = _list[1]; // array of y
            //var ls = new LineSeries
            //{
            //    IndependentValueBinding = new Binding("Key"),
            //    DependentValueBinding = new Binding("Value")
            //};
            var a = new KeyValuePair<float, float>[x.Count - 1];
            for (var i = 0; i < x.Count - 1; i++)
                a[i] = new KeyValuePair<float, float>(x[i], y[i]);
            //ls.ItemsSource = a;
            Chart.ItemsSource = a;
        }
    }
}
