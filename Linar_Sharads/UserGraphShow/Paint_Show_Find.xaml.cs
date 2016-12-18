using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Main_Logic;
using System.Threading;
using System.Windows.Controls.DataVisualization.Charting;
using Main_Logic.DTO.Models;

namespace UserGraphShow
{
    /// <summary>
    /// Interaction logic for Paint_Show_Find.xaml
    /// </summary>
    public partial class Paint_Show_Find : Window
    {
        private double percent;
        private List<int[]> _usergraph;
        private IEnumerable<DATAResult> _listofgraphs;
        private GetUserGraphUnfoInfo graphinfo;

        public Paint_Show_Find()
        {
            //try
            //{

           
           InitializeComponent();

           ShowGraph();
            graphinfo = new GetUserGraphUnfoInfo();
            _listofgraphs = graphinfo.EconGraphArray(_usergraph);
           
            ShowInfo();
            //MessageBox.Show($"{l}");
            FindGraph();
            //}
            //catch (Exception e)
            //{

            //    MessageBox.Show(e.Message);
            //}
        }
       

        private  void button_Click(object sender, RoutedEventArgs e)
        {
            FindGraph();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private  void  ShowGraph()
        {
            _usergraph = GetUserGraphUnfoInfo.FindXy(GetUserGraphUnfoInfo.Path);
            var x = _usergraph[0];  // array of x
            var y = _usergraph[1]; // array of y

            var a = new KeyValuePair<int, int>[x.Length - 1];
            for (var i = 0; i < x.Length - 1; i++)
                a[i] = new KeyValuePair<int, int>(x[i], y[i]);
            UserChart.ItemsSource = a;
        }

        private void FindGraph()
        {
           var graph = new GetUserGraphUnfoInfo().RandomGraph(_listofgraphs);
            
            var y = graph.Dots[0];  // array of x
            var x = graph.Dots[1]; // array of y

            var a = new KeyValuePair<float, float>[x.Count - 1];
            for (var i = 0; i < x.Count - 1; i++)
                a[i] = new KeyValuePair<float, float>(x[i], y[i]);
            Chart.ItemsSource = a;
            Description.Text = graph.Description;
            Name.Text = graph.Name;
        }

        private void ShowInfo()
        {
            percent = (int)((double)graphinfo.K / (double)GetUserGraphUnfoInfo.Pointamount * 100);
            textBox.Text = $"Found {_listofgraphs.Count()} graphs, {percent}% match";
        }
    }
}
