using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Shortest_Path
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel VM;
        public MainWindow()
        {
            InitializeComponent();
            VM = (ViewModel)DataContext;
            AddPoints();
        }
        public void AddPoints()
        {
            Ellipse start = new Ellipse()
            {
                Width = 5,
                Height = 5,
                Stroke = Brushes.Red,
                StrokeThickness = 2
            };

            Canvas.SetTop(start, DrawArea.Height / 2);
            Canvas.SetLeft(start, DrawArea.Width / 2);

            VM.AllPoints.Add(new Point(DrawArea.Width / 2, DrawArea.Height / 2));
            DrawArea.Children.Add(start);

            for (int i = 0; i < 7; i++)
            {
                Ellipse circle = new Ellipse()
                {
                    Width = 5,
                    Height = 5,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                VM.AllPoints.Add(new Point(VM.rnd.Next((int)DrawArea.Width), VM.rnd.Next((int)DrawArea.Height)));

                Canvas.SetLeft(circle, VM.AllPoints.Last().X);
                Canvas.SetTop(circle, VM.AllPoints.Last().Y);
                DrawArea.Children.Add(circle);
            }
        }
    }
}
