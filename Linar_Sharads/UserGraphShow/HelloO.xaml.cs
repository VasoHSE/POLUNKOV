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

namespace UserGraphShow
{
    /// <summary>
    /// Логика взаимодействия для HelloO.xaml
    /// </summary>
    public partial class HelloO : Window
    {
        public HelloO()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            
            var painting = new Painting();
            painting.Show();
            this.Close();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            
            var info = new Info();
            info.Show();
            this.Close();
        }
    }
}
