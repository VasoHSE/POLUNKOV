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
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        public Info()
        {
            InitializeComponent();
            InfoMessage.Text = "Hello, it's Linar Sharades\nPress 'Start' button to begin work\nOn the next window you should draw your graph and press 'Ok' to continue\n In new window you will see your graph in the left corner\nsimilar graph from DB in the right corner\nButton with brush move you to the painting window\nThe second button for outputing new graph";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var helloo = new HelloO();
            helloo.Show();
            this.Close();
        }
    }
}
