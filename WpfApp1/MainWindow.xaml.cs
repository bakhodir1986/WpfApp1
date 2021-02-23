using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public enum YearMonthes
        {
            Январь = 1,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь
        }

        public enum WeekDays
        {
            Воскресенье = 0,
            Понедельник,
            Вторник,
            Среда,
            Четверг,
            Пятница,
            Суббота
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var controller = new PivodTableController();

            var rowData = DataProvider.GetResultModels();

            var pivodModelList = controller.ProcessPivodTable(rowData);

            //Create Columns
            PivodGrid.ShowGridLines = true;
            PivodGrid.Background = new SolidColorBrush(Colors.White);
            

            PivodGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(60) });
            PivodGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(200) });
            PivodGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(200) });

            if (pivodModelList.Any())
            {
                for (int i = 0; i <= pivodModelList.First().TourPlacesModels.Count; i++)
                {
                    PivodGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(120) });
                }
 
                // Create Rows    
                RowDefinition gridRow1 = new RowDefinition();
                gridRow1.Height = new GridLength(45);
                RowDefinition gridRow2 = new RowDefinition();
                gridRow2.Height = new GridLength(45);
                RowDefinition gridRow3 = new RowDefinition();
                gridRow3.Height = new GridLength(45);
                RowDefinition gridRow4 = new RowDefinition();
                gridRow4.Height = new GridLength(45);
                PivodGrid.RowDefinitions.Add(gridRow1);
                PivodGrid.RowDefinitions.Add(gridRow2);
                PivodGrid.RowDefinitions.Add(gridRow3);
                PivodGrid.RowDefinitions.Add(gridRow4);

                // Add first column header    
                TextBlock txtBlock1 = new TextBlock();
                txtBlock1.Text = "Номер";
                txtBlock1.FontSize = 14;
                txtBlock1.FontWeight = FontWeights.Bold;
                txtBlock1.Foreground = new SolidColorBrush(Colors.Black);
                txtBlock1.VerticalAlignment = VerticalAlignment.Center;
                txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(txtBlock1, 2);
                Grid.SetColumn(txtBlock1, 0);

                // Add second column header    
                TextBlock txtBlock2 = new TextBlock();
                txtBlock2.Text = "Сборные группы";
                txtBlock2.FontSize = 14;
                txtBlock2.FontWeight = FontWeights.Bold;
                txtBlock2.Foreground = new SolidColorBrush(Colors.Black);
                txtBlock2.VerticalAlignment = VerticalAlignment.Center;
                txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(txtBlock2, 2);
                Grid.SetColumn(txtBlock2, 1);

                // Add third column header    
                TextBlock txtBlock3 = new TextBlock();
                txtBlock3.Text = "Даты проведения";
                txtBlock3.FontSize = 14;
                txtBlock3.FontWeight = FontWeights.Bold;
                txtBlock3.Foreground = new SolidColorBrush(Colors.Black);
                txtBlock3.VerticalAlignment = VerticalAlignment.Center;
                txtBlock3.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(txtBlock3, 2);
                Grid.SetColumn(txtBlock3, 2);

                //// Add column headers to the Grid    
                PivodGrid.Children.Add(txtBlock1);
                PivodGrid.Children.Add(txtBlock2);
                PivodGrid.Children.Add(txtBlock3);

                var columnDic = pivodModelList.First().TourPlacesModels;

                int col = 3;

                foreach (var dictValue in columnDic)
                {
                    TextBlock txtBlockMonth = new TextBlock();
                    txtBlockMonth.Text = ((YearMonthes)dictValue.Key.Month).ToString();
                    txtBlockMonth.FontSize = 14;
                    txtBlockMonth.FontWeight = FontWeights.Bold;
                    txtBlockMonth.Foreground = new SolidColorBrush(Colors.Green);
                    txtBlockMonth.VerticalAlignment = VerticalAlignment.Center;
                    txtBlockMonth.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetRow(txtBlockMonth, 0);
                    Grid.SetColumn(txtBlockMonth, col);

                    PivodGrid.Children.Add(txtBlockMonth);

                    TextBlock txtBlockDay = new TextBlock();
                    txtBlockDay.Text = dictValue.Key.Day.ToString();
                    txtBlockDay.FontSize = 14;
                    txtBlockDay.FontWeight = FontWeights.Bold;
                    txtBlockDay.Foreground = new SolidColorBrush(Colors.Green);
                    txtBlockDay.VerticalAlignment = VerticalAlignment.Center;
                    txtBlockDay.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetRow(txtBlockDay, 1);
                    Grid.SetColumn(txtBlockDay, col);

                    PivodGrid.Children.Add(txtBlockDay);

                    TextBlock txtBlockWeek = new TextBlock();
                    txtBlockWeek.Text = ((WeekDays)dictValue.Key.DayOfWeek).ToString();
                    txtBlockWeek.FontSize = 14;
                    txtBlockWeek.FontWeight = FontWeights.Bold;
                    txtBlockWeek.Foreground = new SolidColorBrush(Colors.Green);
                    txtBlockWeek.VerticalAlignment = VerticalAlignment.Center;
                    txtBlockWeek.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetRow(txtBlockWeek, 2);
                    Grid.SetColumn(txtBlockWeek, col);

                    PivodGrid.Children.Add(txtBlockWeek);

                    col++;
                }

                col = 3;
                int row = 3;

                foreach (var pivod in pivodModelList)
                {
                    RowDefinition gridRowN = new RowDefinition();
                    gridRowN.Height = new GridLength(45);
                    PivodGrid.RowDefinitions.Add(gridRowN);
                    
                    SolidColorBrush color = new SolidColorBrush();

                    if (pivod.colorOfRow == StatusColor.Gray)
                    {
                        color.Color = Colors.Gainsboro;
                    }
                    else if (pivod.colorOfRow == StatusColor.Blue)
                    {
                        color.Color = Colors.CornflowerBlue;
                    }
                    else if (pivod.colorOfRow == StatusColor.Red)
                    {
                        color.Color = Colors.LightPink;
                    }

                    TextBlock txtBlockCell1 = new TextBlock();
                    txtBlockCell1.Text = pivod.TourId.ToString();
                    txtBlockCell1.FontSize = 14;
                    txtBlockCell1.FontWeight = FontWeights.Bold;
                    txtBlockCell1.Foreground = new SolidColorBrush(Colors.Green);
                    txtBlockCell1.VerticalAlignment = VerticalAlignment.Center;
                    txtBlockCell1.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetRow(txtBlockCell1, row);
                    Grid.SetColumn(txtBlockCell1, 0);

                    Rectangle rect1 = new Rectangle();
                    rect1.Fill = color;
                    Grid.SetRow(rect1, row);
                    Grid.SetColumn(rect1, 0);
                    PivodGrid.Children.Add(rect1);

                    PivodGrid.Children.Add(txtBlockCell1);

                    TextBlock txtBlockCell2 = new TextBlock();
                    txtBlockCell2.Text = pivod.JointGroups;
                    txtBlockCell2.FontSize = 14;
                    txtBlockCell2.FontWeight = FontWeights.Bold;
                    txtBlockCell2.Foreground = new SolidColorBrush(Colors.Green);
                    txtBlockCell2.VerticalAlignment = VerticalAlignment.Center;
                    txtBlockCell2.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetRow(txtBlockCell2, row);
                    Grid.SetColumn(txtBlockCell2, 1);

                    Rectangle rect2 = new Rectangle();
                    rect2.Fill = color;
                    Grid.SetRow(rect2, row);
                    Grid.SetColumn(rect2, 1);
                    PivodGrid.Children.Add(rect2);

                    PivodGrid.Children.Add(txtBlockCell2);

                    TextBlock txtBlockCell3 = new TextBlock();
                    txtBlockCell3.Text = pivod.FromStartTillEndDateWithDash;
                    txtBlockCell3.FontSize = 14;
                    txtBlockCell3.FontWeight = FontWeights.Bold;
                    txtBlockCell3.Foreground = new SolidColorBrush(Colors.Green);
                    txtBlockCell3.VerticalAlignment = VerticalAlignment.Center;
                    txtBlockCell3.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetRow(txtBlockCell3, row);
                    Grid.SetColumn(txtBlockCell3, 2);

                    Rectangle rect3 = new Rectangle();
                    rect3.Fill = color;
                    Grid.SetRow(rect3, row);
                    Grid.SetColumn(rect3, 2);
                    PivodGrid.Children.Add(rect3);

                    PivodGrid.Children.Add(txtBlockCell3);


                    foreach (var dictCell in pivod.TourPlacesModels)
                    {
                        TextBlock txtBlockCellN = new TextBlock();
                        txtBlockCellN.Text = dictCell.Value;
                        txtBlockCellN.FontSize = 14;
                        txtBlockCellN.FontWeight = FontWeights.Bold;
                        txtBlockCellN.Foreground = new SolidColorBrush(Colors.Green);
                        txtBlockCellN.VerticalAlignment = VerticalAlignment.Center;
                        txtBlockCellN.HorizontalAlignment = HorizontalAlignment.Center;

                        Rectangle rectN = new Rectangle();
                        rectN.Fill = color;
                        Grid.SetRow(rectN, row);
                        Grid.SetColumn(rectN, col);
                        PivodGrid.Children.Add(rectN);

                        Grid.SetRow(txtBlockCellN, row);
                        Grid.SetColumn(txtBlockCellN, col++);

                        PivodGrid.Children.Add(txtBlockCellN);
                    }

                    row++;
                    col = 3;
                }
            }
        }
    }
}
