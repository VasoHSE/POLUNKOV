using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using Main_Logic;
using System.Windows.Controls.DataVisualization.Charting;
using Main_Logic.GraphProcessing;

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
            //var pnlClient = this.Content as FrameworkElement;
            //pnlClient.Height = height;
            //pnlClient.Width = width;
          

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
                var b = GetUserGraphUnfoInfo.FindXy(GetUserGraphUnfoInfo.Path);
                var x = b[0];  // array of x
                var y = b[1]; // array of y
                var ls = new LineSeries
                {
                    IndependentValueBinding = new Binding("Key"),
                    DependentValueBinding = new Binding("Value")
                };
                var a = new KeyValuePair<int, int>[x.Length-1];
                for (var i = 0; i < x.Length-1; i++)
                    a[i] = new KeyValuePair<int, int>(x[i], y[i]);
                ls.ItemsSource = a;
            Chart.ItemsSource = a;
           var kek = new KoefGraphOutput(b);
            kek.ShowDialog();
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
