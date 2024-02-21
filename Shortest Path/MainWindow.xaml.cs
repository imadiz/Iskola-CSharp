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
            DrawPoints();
        }
        public void DrawPoints()
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

            DrawArea.Children.Clear();

            VM.AllPoints.Clear();
            VM.AllPoints.Add(new Point(DrawArea.Width / 2, DrawArea.Height / 2));
            DrawArea.Children.Add(start);

            for (int i = 0; i < 7; i++)
            {
                Ellipse circle = new Ellipse()
                {
                    Width = 5,
                    Height = 5,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    SnapsToDevicePixels = true
                };

                VM.AllPoints.Add(new Point(VM.rnd.Next(5, (int)DrawArea.Width - 5), VM.rnd.Next(5, (int)DrawArea.Height - 5)));

                Canvas.SetLeft(circle, VM.AllPoints.Last().X);
                Canvas.SetTop(circle, VM.AllPoints.Last().Y);
                DrawArea.Children.Add(circle);
            }
        }

        private void mi_redraw_Click(object sender, RoutedEventArgs e)
        {
            DrawPoints();
        }

        private void mi_start_Click(object sender, RoutedEventArgs e)
        {
            StartSearch();
        }

        public void StartSearch()
        {
            ObservableCollection<Point> CurrentPossiblePath = new ObservableCollection<Point>();
            do
            {
                while (true)//Addig, amíg van nincs egy egyedi sorrend.
                {
                    for (int i = 0; i < VM.AllPoints.Count; i++)
                    {
                        CurrentPossiblePath.Add(VM.AllPoints[VM.rnd.Next(VM.AllPoints.Count - 1)]);//Véletlenszerű összepakolás
                    }

                    if (!VM.PossiblePaths.Contains(CurrentPossiblePath))//Ha még nincs ilyen sorrend
                    {
                        VM.PossiblePaths.Add(CurrentPossiblePath);//Hozzáadás
                        break;//Kész, kilépés
                    }
                }

                //Path számolási logika

            } while (!VM.PossiblePaths.Contains(CurrentPossiblePath));//Amíg nincs meg a jelenlegi sorrend. (Az összes lehetséges sorrendig)
        }
    }
}
