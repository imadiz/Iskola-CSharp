using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
            VM.AllPoints.Add(new Point(DrawArea.ActualWidth / 2 + start.Width / 2, DrawArea.ActualHeight / 2 + start.Height / 2));
            DrawArea.Children.Add(start);

            for (int i = 0; i < VM.NumberOfPoints; i++)
            {
                Ellipse circle = new Ellipse()
                {
                    Width = 5,
                    Height = 5,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    SnapsToDevicePixels = true
                };

                int PointX = VM.rnd.Next(5, (int)DrawArea.ActualWidth - 5);
                int PointY = VM.rnd.Next(5, (int)DrawArea.ActualHeight - 5);

                while (VM.AllPoints.All(x => Math.Abs(x.X - PointX) > 10) && VM.AllPoints.All(x => Math.Abs(x.Y - PointY) > 10))//Legyen minimum 10 pixel a pontok között.
                {
                    PointX = VM.rnd.Next(5, (int)DrawArea.ActualWidth - 5);
                    PointY = VM.rnd.Next(5, (int)DrawArea.ActualHeight - 5);
                }

                VM.AllPoints.Add(new Point(PointX, PointY));//Új pont hozzáadása

                Canvas.SetLeft(circle, VM.AllPoints.Last().X - circle.Width / 2);
                Canvas.SetTop(circle, VM.AllPoints.Last().Y - circle.Height / 2);
                DrawArea.Children.Add(circle);
            }

            CalculateNumberOfPossibilites();//Összes lehetőség kiszámolása

            WriteLog("Pontok megrajzolva!");
        }
        public void StartSearch()
        {
            List<Point> CurrentPossiblePath = new List<Point>();

            VM.PossiblePaths.Clear();//Eddigi adatok törlése
            VM.PossibleDistances.Clear();//Eddigi adatok törlése

            for (int i = 0; i < VM.NumberOfPossibilities; i++)
            {
                CurrentPossiblePath = new List<Point> { VM.AllPoints[0]/*Indulópont*/ };

                while (true)//Addig, amíg nincs egy egyedi sorrend.
                {
                    while (CurrentPossiblePath.Count != VM.AllPoints.Count)//Addig amíg a sorrendben nincs ugyanannyi pont mint az összes pont
                    {
                        Point NextRandomPoint = VM.AllPoints[VM.rnd.Next(1, VM.AllPoints.Count)];//Új random pont

                        if (!CurrentPossiblePath.Contains(NextRandomPoint))//Ha még nincs benne a jelenlegi pont (egy sorrendben duplicate-ek kiszűrése)
                            CurrentPossiblePath.Add(NextRandomPoint);//Jelenlegi random pont hozzáadása a sorrendhez
                    }

                    if (!VM.PossiblePaths.Any(x => Enumerable.SequenceEqual(CurrentPossiblePath, x)))//Ha egyedi az új út
                    {
                        VM.PossiblePaths.Add(CurrentPossiblePath);//Hozzáadás
                        break;//Kész, kilépés
                    }
                    else//Ha már van, törlés és új sorrend
                    {
                        CurrentPossiblePath = new List<Point>
                        {
                            VM.AllPoints[0]//Indulópont
                        };
                    }
                }

                App.Current.Dispatcher.Invoke(new Action(() =>
                {
                    List<Line> ToRemove = new List<Line>();//Eltávolítandó vonalak

                    foreach (var item in DrawArea.Children)//Vonalak megkeresése
                    {
                        if (item.GetType() == typeof(Line))//Ha vonal típusú UIElement
                            ToRemove.Add(item as Line);//Hozzáadás az eltávolítandókhoz
                    }

                    foreach (Line item in ToRemove)//Eltávolítandó vonalak
                        DrawArea.Children.Remove(item);//Törlés
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
                            X1 = CurrentPoint.X,//Kezdet X-koordináta
                            Y1 = CurrentPoint.Y,//Kezdet Y-koordináta
                            X2 = NextPoint.X,//Vég X-koordináta
                            Y2 = NextPoint.Y,//Vég Y-koordináta
                            Stroke = Brushes.Red,//Szín
                            StrokeThickness = 1//Vastagság
                        });
                    }));//Pontok közötti vonal megjelenítése

                    Task.Delay(VM.Delay).Wait();//Késleltetés

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
                    PointIndex++;//Következő pont
                }

                App.Current.Dispatcher.BeginInvoke(new Action(() => { VM.PossibleDistances.Add(PathDistance); })).Wait();//Kiszámolt sorrend hozzáadása

                WriteLog($"Út hossza: {PathDistance:0.0000}");
            }

            WriteLog($"Legrövidebb út hossza: {VM.PossibleDistances.Min():0.0000}");
        }
        public void DrawShortestPath()
        {
            List<Point> Path = VM.PossiblePaths[VM.PossibleDistances.IndexOf(VM.PossibleDistances.Min())];
            List<Line> ToRemove = new List<Line>();

            foreach (var item in DrawArea.Children)
            {
                if (item.GetType() == typeof(Line))
                    ToRemove.Add(item as Line);
            }

            foreach (Line item in ToRemove)
                DrawArea.Children.Remove(item);

            for (int i = 0; i < Path.Count - 1; i++)
            {
                DrawArea.Children.Add(new Line
                {
                    X1 = Path[i].X,
                    Y1 = Path[i].Y,
                    X2 = Path[i + 1].X,
                    Y2 = Path[i + 1].Y,
                    Stroke = Brushes.Red,
                    StrokeThickness = 1
                });//Pontok közötti vonal látszódik
            }
        }
        public void CalculateNumberOfPossibilites()//Faktoriális számolás
        {
            WriteLog("Lehetőségek számának kiszámítása...");
            int EllipseCount = 0;

            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                EllipseCount = DrawArea.Children.OfType<Ellipse>().Count();//Pontok száma
            })).Wait();

            VM.NumberOfPossibilities = EllipseCount - 1;

            for (int i = 1; i < EllipseCount - 1; i++)//Ahány pont van a kezdésen kívül
            {
                VM.NumberOfPossibilities *= i;//Lehetőségek megszorzása a pontok számával
            }

            WriteLog($"Lehetőségek száma: {VM.NumberOfPossibilities}");
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
        private async void mi_start_Click(object sender, RoutedEventArgs e)
        {
            mi_points.IsEnabled = false;
            mi_start.IsEnabled = false;
            sli_delay.IsEnabled = true;

            VM.Delay = 1;//Késleltetés (azért 1 mert így kirajzolódik minden más is a UI-on, ha utána a user leveszi 0-ra rendesen működik minden, csak akkor nem ha 0-val indul.)

            await Task.Run(StartSearch);

            DrawShortestPath();

            MessageBox.Show($"A legrövidebb út {VM.PossibleDistances.Min():0.0000} hosszú, és ki van rajzolva.", "Legrövidebb út számító", MessageBoxButton.OK, MessageBoxImage.Information);

            sli_delay.IsEnabled = false;
            mi_points.IsEnabled = true;
            mi_start.IsEnabled = true;
        }
        private void mi_redraw_Click(object sender, RoutedEventArgs e)
        {
            DrawPoints();
        }
        private void mi_pointcount_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;

            VM.NumberOfPoints = Convert.ToInt32(mi.Header);//Új pontszám
            DrawPoints();//Pontok újrarajzolása
        }
    }
}