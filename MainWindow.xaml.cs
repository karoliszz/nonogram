
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace nonogram
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Generate(10,10);

        }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textGameHeight.Text, out int height) && int.TryParse(textGameWidth.Text, out int width))
            {
                Generate(height, width);
            }
            else
            {
                textGameHeight.Text = "bad ";
                textGameWidth.Text = "bad ";
            }
            
            
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Rectangle_LeftMouseDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("Clicked");
            Rectangle rect = (Rectangle)sender;

            if (rect.Fill == Brushes.Red)
                rect.Fill = Brushes.Blue;
            else
                rect.Fill = Brushes.Red;

            Point position = (Point)rect.Tag;
            MessageBox.Show($"Clicked row {position.X}, column {position.Y}");
        
        /*
        if (((Rectangle)sender).Fill == Brushes.Red) { ((Rectangle)sender).Fill = Brushes.Blue; }
        else ((Rectangle)sender).Fill = Brushes.Red;

        Point position = (Point)((Rectangle)sender).Tag;

        MessageBox.Show($"Clicked row {position.X}, column {position.Y}");
        */
        }
        private void Generate(int rowSize, int colSize)
        {
            GameGrid.ColumnDefinitions.Clear();
            GameGrid.RowDefinitions.Clear();
            GameGrid.Children.Clear();
            

            for (int i = 0; i <= rowSize; i++)
            {
                Rectangle rect = new Rectangle
                {
                    Fill = Brushes.RosyBrown,
                    Stroke = Brushes.Black,
                };



                GameGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                Grid.SetRow(rect, i);
                Grid.SetColumn(rect, 0);
                GameGrid.Children.Add(rect);

            }
            for (int i = 0; i <= colSize; i++)
            {
                Rectangle rect = new Rectangle
                {
                    Fill = Brushes.RosyBrown,
                    Stroke = Brushes.Black,
                };

                GameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });
                rect = new Rectangle
                {
                    Fill = Brushes.RosyBrown,
                    Stroke = Brushes.Black,


                };
                Grid.SetColumn(rect, i);
                Grid.SetRow(rect, 0);
                GameGrid.Children.Add(rect);
            }

            for (int row = 1; row <= rowSize; row++)
            {
                for (int col = 1; col <= colSize; col++)
                {


                    Rectangle rect = new Rectangle
                    {
                        Fill = Brushes.Red,
                        Stroke = Brushes.Black,
                        Tag = new Point(row, col),
                        IsHitTestVisible = true,
                        Width = 30,
                        Height = 30

                    };
                    Panel.SetZIndex(rect, 10);

                    rect.MouseLeftButtonDown += Rectangle_LeftMouseDown;
                    Grid.SetColumn(rect, col);
                    Grid.SetRow(rect, row);
                    GameGrid.Children.Add(rect);

                }
            }
        }
    }
}