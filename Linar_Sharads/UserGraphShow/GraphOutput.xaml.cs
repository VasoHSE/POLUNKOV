using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using Main_Logic;
using System.Windows.Controls.DataVisualization.Charting;

namespace UserGraphShow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GraphOutput
    {
        public GraphOutput()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // var repo = new GetUserGraphUnfoInfo();
                var b = GetUserGraphUnfoInfo.FindXY("../../../Main_Logic/image.jpeg");
                var x = b[0];
                var y = b[1];
                var ls = new LineSeries
                {
                    IndependentValueBinding = new Binding("Key"),
                    DependentValueBinding = new Binding("Value")
                };
                var a = new KeyValuePair<int, int>[GetUserGraphUnfoInfo.Pointamount];
                for (var i = 0; i < GetUserGraphUnfoInfo.Pointamount; i++)
                    a[i] = new KeyValuePair<int, int>(x[i], y[i]);

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
