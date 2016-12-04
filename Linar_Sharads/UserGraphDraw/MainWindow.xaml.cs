using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace UserGraphDraw
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Point _currentPoint;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                _currentPoint = e.GetPosition(this);
        }

        private void Canvas_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            var line = new Line
            {
                Stroke = System.Windows.SystemColors.WindowFrameBrush,
                X1 = _currentPoint.X,
                Y1 = _currentPoint.Y,
                X2 = e.GetPosition(this).X,
                Y2 = e.GetPosition(this).Y
            };
            _currentPoint = e.GetPosition(this);
            paintSurface.Children.Add(line);
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveTo("../../../Main_Logic/image.jpeg");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ":(", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            var kek = new UserGraphShow.MainWindow();
            kek.ShowDialog();          
        }

        public void SaveTo(string f)
        {
            var b = VisualTreeHelper.GetDescendantBounds(paintSurface);
            var r = new RenderTargetBitmap((int) b.Width, (int) b.Height, 96, 96,
                PixelFormats.Default);
            r.Render(paintSurface);
            var e = new JpegBitmapEncoder();
            e.Frames.Add(BitmapFrame.Create(r));
            var s = new FileStream(f,
                FileMode.OpenOrCreate, FileAccess.Write);
            e.Save(s);
            s.Close();
        }

        private void clearButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            paintSurface.Children.Clear();
        }
    }
}
