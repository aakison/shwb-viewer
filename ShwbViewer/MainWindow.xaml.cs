using Microsoft.Win32;
using SharedWhiteboard.DataModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ShwbViewer {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog() { Filter = "Whiteboards|*.shwb" };
            if(openFileDialog.ShowDialog() == true) {
                RenderFile(openFileDialog.FileName);
            }
        }

        public void RenderFile(string filename)
        {
            ClearBoard();
            var file = File.OpenText(filename);
            var json = file.ReadToEnd();
            var whiteboard = JsonSerializer.Deserialize<Whiteboard>(json);
            foreach(var scribble in whiteboard.Scribbles) {
                RenderScribble(scribble);
            }
            Title = $"Shared Whiteboard: {whiteboard.Title}";
        }

        private void ClearBoard()
        {
            Title = "Shared Whiteboard";
            foreach(var path in paths) {
                myGrid.Children.Remove(path);
            }
            paths.Clear();
        }

        private void RenderScribble(SharedWhiteboard.Scribble scribble)
        {
            var path = new Polyline {
                Stroke = new SolidColorBrush(scribble.Color),
                StrokeThickness = scribble.StrokeThickness,
                FillRule = FillRule.EvenOdd,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round,
                StrokeLineJoin = PenLineJoin.Round,
            };
            var points = new PointCollection(scribble.Points.Select(e => new Point(e.Point.X, e.Point.Y)));
            path.Points = points;
            myGrid.Children.Add(path);
            paths.Add(path);
        }

        private List<Polyline> paths = new List<Polyline>();

    }
}
