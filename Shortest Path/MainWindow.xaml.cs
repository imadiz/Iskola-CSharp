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

            Canvas.SetTop(start, DrawArea.ActualHeight / 2);
            Canvas.SetLeft(start, DrawArea.ActualWidth / 2);

            DrawArea.Children.Clear();

            VM.AllPoints.Clear();
            VM.AllPoints.Add(new Point(DrawArea.ActualWidth / 2, DrawArea.ActualHeight / 2));
            DrawArea.Children.Add(start);

            for (int i = 0; i < 6; i++)
            {
                Ellipse circle = new Ellipse()
                {
                    Width = 5,
                    Height = 5,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    SnapsToDevicePixels = true
                };

                VM.AllPoints.Add(new Point(VM.rnd.Next(5, (int)DrawArea.ActualWidth - 5), VM.rnd.Next(5, (int)DrawArea.ActualHeight - 5)));

                Canvas.SetLeft(circle, VM.AllPoints.Last().X - circle.Width / 2);
                Canvas.SetTop(circle, VM.AllPoints.Last().Y - circle.Height / 2);
                DrawArea.Children.Add(circle);
            }
            WriteLog("Pontok megrajzolva!");
        }
        public void StartSearch()
        {
            List<Point> CurrentPossiblePath = new List<Point>();

            do
            {
                CurrentPossiblePath = new List<Point> { VM.AllPoints[0]/*Indulópont*/ };

                while (true)//Addig, amíg nincs egy egyedi sorrend.
                {
                    while (CurrentPossiblePath.Count != VM.AllPoints.Count)
                    {
                        Point NextRandomPoint = VM.AllPoints[VM.rnd.Next(1, VM.AllPoints.Count)];

                        if (!CurrentPossiblePath.Contains(NextRandomPoint))
                            CurrentPossiblePath.Add(NextRandomPoint);//Véletlenszerű összepakolás
                    }

                    if (!VM.PossiblePaths.Any(x=>Enumerable.SequenceEqual(CurrentPossiblePath, x)))//Ha egyedi az új út
                    {
                        VM.PossiblePaths.Add(CurrentPossiblePath);//Hozzáadás
                        break;//Kész, kilépés
                    }
                    else//Ha már van
                    {
                        CurrentPossiblePath = new List<Point>
                        {
                            VM.AllPoints[0]//Indulópont
                        };//Törlés, újra
                    }
                }

                App.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    for (int i = 0; i < DrawArea.Children.Count; i++)
                    {
                        if (DrawArea.Children[i].GetType() == typeof(Line))//Ha vonal
                            DrawArea.Children.RemoveAt(i);//Törlés
                    }
                }));

                Double PathDistance = 0;//út hossz
                int PointIndex = 0;//Jelen pont index

                while (PointIndex < VM.AllPoints.Count - 1)
                {
                    Point CurrentPoint = CurrentPossiblePath[PointIndex];//Jelenlegi pont
                    Point NextPoint = CurrentPossiblePath[PointIndex + 1];//Következő pont
                    double DistanceBetweenPoints = 0;//Pontok közötti hosszúság

                    App.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        DrawArea.Children.Add(new Line
                        {
                            X1 = CurrentPoint.X,
                            Y1 = CurrentPoint.Y,
                            X2 = NextPoint.X,
                            Y2 = NextPoint.Y,
                            Stroke = Brushes.Red,
                            StrokeThickness = 1
                        });//Pontok közötti vonal látszódik
                    })).Wait();

                    if (CurrentPoint.X >= NextPoint.X)//Ha balra van a következő pont
                    {
                        if (CurrentPoint.Y >= NextPoint.Y)//Ha lefelé van a következő pont
                            DistanceBetweenPoints = Math.Sqrt(Math.Pow(NextPoint.X - CurrentPoint.X, 2) + Math.Pow(CurrentPoint.Y - NextPoint.Y, 2));
                        else//Ha felfelé
                            DistanceBetweenPoints = Math.Sqrt(Math.Pow(NextPoint.X - CurrentPoint.X, 2) + Math.Pow(NextPoint.Y - CurrentPoint.Y, 2));
                    }
                    else//Ha jobbra
                    {
                        if (CurrentPoint.Y >= NextPoint.Y)//Ha lefelé van a következő pont
                            DistanceBetweenPoints = Math.Sqrt(Math.Pow(CurrentPoint.X - NextPoint.X, 2) + Math.Pow(CurrentPoint.Y - NextPoint.Y, 2));
                        else//Ha felfelé
                            DistanceBetweenPoints = Math.Sqrt(Math.Pow(CurrentPoint.X - NextPoint.X, 2) + Math.Pow(NextPoint.Y - CurrentPoint.Y, 2));
                    }

                    PathDistance += DistanceBetweenPoints;//Pontok közötti hossz hozzáadása az úthoz
                    PointIndex++;
                }

                App.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    VM.PossibleDistances.Add(PathDistance);
                }));

                WriteLog($"Út hossza: {PathDistance:0.0000}");

                //TODO: ki kell lépni valahogy a ciklusból.

            } while (true);//Amíg nincs meg a jelenlegi sorrend. (Az összes lehetséges sorrendig)
        }
        public void WriteLog(string log)
        {
            App.Current.Dispatcher.Invoke(new Action(() =>
            {
                VM.AllLogs.Insert(0, log);
            }));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrawPoints();
        }

        private void mi_redraw_Click(object sender, RoutedEventArgs e)
        {
            DrawPoints();
        }

        private async void mi_start_Click(object sender, RoutedEventArgs e)
        {
            mi_redraw.IsEnabled = false;
            mi_start.IsEnabled = false;

            await Task.Run(StartSearch);
            MessageBox.Show($"A legrövidebb út {VM.PossibleDistances.Max():0.0000} hosszú.", "Legrövidebb út számító", MessageBoxButton.OK, MessageBoxImage.Information);

            mi_redraw.IsEnabled = true;
            mi_start.IsEnabled = true;
        }
    }
}
