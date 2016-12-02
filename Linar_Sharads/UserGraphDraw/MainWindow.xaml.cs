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
using UserGraphShow;
using Main_Logic;
using System.Drawing;
using System.IO;

namespace UserGraphDraw
{//System.Windows.
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Point currentPoint = new System.Windows.Point();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
        }

        private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();
                line.Stroke = System.Windows.SystemColors.WindowFrameBrush;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;
                currentPoint = e.GetPosition(this);
                paintSurface.Children.Add(line);
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            
            SaveTo("../../../Main_Logic/image.jpeg");
            UserGraphShow.MainWindow kek = new UserGraphShow.MainWindow();
            kek.ShowDialog();


        }
        public void SaveTo(string f)
        {
           
            Rect b = VisualTreeHelper.GetDescendantBounds(paintSurface);            
            RenderTargetBitmap r = new RenderTargetBitmap((int)b.Width, (int)b.Height,96,96, PixelFormats.Default);
            r.Render(paintSurface);
            var e = new JpegBitmapEncoder();
            e.Frames.Add(BitmapFrame.Create(r));
            FileStream s = new FileStream(f,
                FileMode.OpenOrCreate, FileAccess.Write);
            e.Save(s);
            s.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            paintSurface.Children.Clear();
        }
    }
}
