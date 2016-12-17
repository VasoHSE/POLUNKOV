using System;
using System.Collections.Generic;
using System.IO;
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
namespace UserGraphShow
{
    /// <summary>
    /// Interaction logic for Painting.xaml
    /// </summary>
    public partial class Painting : Window
    {
        public Painting()
        {
            InitializeComponent();
        }
        private Point _currentPoint;
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
                SaveTo(GetUserGraphUnfoInfo.Path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ":(", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                
            }

            var pnlClient = this.Content as FrameworkElement;
            if (pnlClient == null) return;
            var kek = new GraphOutput(pnlClient.ActualWidth,pnlClient.ActualHeight);
           // var kek2=new KoefGraphOutput();//+arrayXY
            kek.ShowDialog();
        }

        public void SaveTo(string f)
        {
            //        RenderTargetBitmap rtb = new RenderTargetBitmap((int)paintSurface.RenderSize.Width,
            //(int)paintSurface.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            //        rtb.Render(paintSurface);

            //        var crop = new CroppedBitmap(rtb, new Int32Rect(50, 50, 1000, 1000));

            //        BitmapEncoder pngEncoder = new PngBitmapEncoder();
            //        pngEncoder.Frames.Add(BitmapFrame.Create(crop));

            //        using (var fs = System.IO.File.OpenWrite(f))
            //        {
            //            pngEncoder.Save(fs);
            //        }


            var b = VisualTreeHelper.GetDescendantBounds(paintSurface);
            var r = new RenderTargetBitmap((int)b.Width, (int)b.Height, 96, 96, PixelFormats.Default);
            r.Render(paintSurface);
            var e = new PngBitmapEncoder();
            e.Frames.Add(BitmapFrame.Create(r));
            var s = new FileStream(f, FileMode.OpenOrCreate, FileAccess.Write);
            e.Save(s);
            s.Close();
        }

        private void clearButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            paintSurface.Children.Clear();
        }
    }
}
