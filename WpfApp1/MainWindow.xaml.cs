using System.Collections.Generic;
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
        #region DefaultSettings

        private const int RowHeightPixels = 45;
        private const int FirstColumnWidthPixels = 60;
        private const int SecondColumnWidthPixels = 200;
        private const int ThirdColumnWidthPixels = 200;
        private const int PivodColumnsWidthPixes = 120;

        #endregion

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
            CreateAndConfigPivodTable(GetPivodTableModelsCollection());
        }

        private static List<PivodTableModel> GetPivodTableModelsCollection()
        {
            return (new PivodTableController()).ProcessPivodTable(DataProvider.GetResultModels());
        }

        private void CreateAndConfigPivodTable(List<PivodTableModel> pivodModelList)
        {
            ConfigPivodTableGeneral();

            if (pivodModelList.Any())
            {
                CreateHeaderOfPivodTable(pivodModelList);

                FillDataToPivodTable(pivodModelList);
            }
        }

        private void FillDataToPivodTable(List<PivodTableModel> pivodModelList)
        {
            int col = 3;
            int row = 3;

            foreach (var pivod in pivodModelList)
            {
                AddNewRow();

                var color = SetColorFromStatus(pivod);

                FillCell(color, pivod.TourId.ToString(), row, 0);

                FillCell(color, pivod.JointGroups, row, 1);

                FillCell(color, pivod.FromStartTillEndDateWithDash, row, 2);

                foreach (var dictCell in pivod.TourPlacesModels)
                {

                    FillCell(color, dictCell.Value, row, col);

                    col++;
                }

                row++;
                col = 3;
            }
        }

        private void AddNewRow()
        {
            RowDefinition gridRowN = new RowDefinition();
            gridRowN.Height = new GridLength(45);
            PivodGrid.RowDefinitions.Add(gridRowN);
        }

        private void FillCell(SolidColorBrush color, string text, int row, int col)
        {
            if (!string.IsNullOrEmpty(text))
            {
                BrushCellOfPivod(color, row, col);
            }

            PrintTextToCell(text, row, col);
        }

        private void PrintTextToCell(string printValue, int row, int col)
        {
            TextBlock txtBlockCellN = new TextBlock();
            txtBlockCellN.Text = printValue;
            txtBlockCellN.FontSize = 14;
            txtBlockCellN.FontWeight = FontWeights.Bold;
            txtBlockCellN.Foreground = new SolidColorBrush(Colors.Green);
            txtBlockCellN.VerticalAlignment = VerticalAlignment.Center;
            txtBlockCellN.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(txtBlockCellN, row);
            Grid.SetColumn(txtBlockCellN, col);

            PivodGrid.Children.Add(txtBlockCellN);
        }

        private void BrushCellOfPivod(SolidColorBrush color, int row, int col)
        {
            Rectangle rectN = new Rectangle();
            rectN.Fill = color;
            Grid.SetRow(rectN, row);
            Grid.SetColumn(rectN, col);
            PivodGrid.Children.Add(rectN);
        }

        private static SolidColorBrush SetColorFromStatus(PivodTableModel pivod)
        {
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

            return color;
        }

        private void ConfigPivodTableGeneral()
        {
            PivodGrid.ShowGridLines = true;
            PivodGrid.Background = new SolidColorBrush(Colors.White);
        }

        private void CreateHeaderOfPivodTable(List<PivodTableModel> pivodModelList)
        {
            int pivodColumnsCount = pivodModelList.First().TourPlacesModels.Count;

            CreateDefaultColAndRowsDefinisions(pivodColumnsCount);

            FillHeaders(pivodModelList);
        }

        private void FillHeaders(List<PivodTableModel> pivodModelList)
        {
            // Add first column header    
            PrintTextToCell("Номер", 2, 0);

            // Add second column header    
            PrintTextToCell("Сборные группы", 2, 1);

            // Add third column header    
            PrintTextToCell("Даты проведения", 2, 2);

            var columnDic = pivodModelList.First().TourPlacesModels;

            int col = 3;

            foreach (var dictValue in columnDic)
            {
                PrintTextToCell(((YearMonthes) dictValue.Key.Month).ToString(), 0, col);

                PrintTextToCell(dictValue.Key.Day.ToString(), 1, col);

                PrintTextToCell(((WeekDays) dictValue.Key.DayOfWeek).ToString(), 2, col);

                col++;
            }
        }

        private void CreateDefaultColAndRowsDefinisions(int pivodColumnsCount)
        {
            CreateColumnDefinision(FirstColumnWidthPixels);
            CreateColumnDefinision(SecondColumnWidthPixels);
            CreateColumnDefinision(ThirdColumnWidthPixels);

            for (int i = 0; i <= pivodColumnsCount; i++)
            {
                CreateColumnDefinision(PivodColumnsWidthPixes);
            }

            // Create Rows    
            CreateRowDefinision();
            CreateRowDefinision();
            CreateRowDefinision();
            CreateRowDefinision();
        }

        private void CreateRowDefinision()
        {
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(RowHeightPixels);
            PivodGrid.RowDefinitions.Add(gridRow1);
        }

        private void CreateColumnDefinision(int width)
        {
            PivodGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(width) });
        }
    }
}
