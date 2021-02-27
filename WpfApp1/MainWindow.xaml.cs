using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
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

        private Color TableBackgroundColor = Colors.White;
        private bool ShowGridLines = true;
        private Color DefaultTextColor = Colors.Green;

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

                FillDataToDataGridPivodTable(pivodModelList);
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

        private void FillDataToDataGridPivodTable(List<PivodTableModel> pivodModelList)
        {
            int col = 3;
            int row = 0;

            foreach (var pivod in pivodModelList)
            {
                var color = SetColorFromStatus(pivod);

                dynamic rowToAdd = new ExpandoObject();

                var colValue = string.Format("Column{0}", 0);
                ((IDictionary<String, Object>)rowToAdd)[colValue] = pivod.TourId.ToString();
                colValue = string.Format("Column{0}", 1);
                ((IDictionary<String, Object>)rowToAdd)[colValue] = pivod.JointGroups;
                colValue = string.Format("Column{0}", 2);
                ((IDictionary<String, Object>)rowToAdd)[colValue] = pivod.FromStartTillEndDateWithDash;

                foreach (var dictCell in pivod.TourPlacesModels)
                {
                    colValue = string.Format("Column{0}", col);
                    ((IDictionary<String, Object>)rowToAdd)[colValue] = dictCell.Value;

                    col++;
                }

                PivodDataGrid.Items.Add(rowToAdd);

                SetColorToCell(color, PivodDataGrid, row, 0);
                SetColorToCell(color, PivodDataGrid, row, 1);
                SetColorToCell(color, PivodDataGrid, row, 2);

                col = 3;

                foreach (var dictCell in pivod.TourPlacesModels)
                {

                    if (!string.IsNullOrEmpty(dictCell.Value))
                    {
                        SetColorToCell(color, PivodDataGrid, row, col);
                    }

                    col++;
                }

                row++;
                col = 3;

            }
        }

        private void AddNewRow()
        {
            RowDefinition gridRowN = new RowDefinition();
            gridRowN.Height = new GridLength(RowHeightPixels);
            PivodGrid.RowDefinitions.Add(gridRowN);
        }

        private void SetColorToCell(SolidColorBrush color, DataGrid grid, int row, int col)
        {
            var selectedRow = grid.GetRow(row);
            var columnCell = grid.GetCell(selectedRow, col);
            columnCell.Background = color;
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
            txtBlockCellN.Foreground = new SolidColorBrush(DefaultTextColor);
            txtBlockCellN.VerticalAlignment = VerticalAlignment.Center;
            txtBlockCellN.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(txtBlockCellN, row);
            Grid.SetColumn(txtBlockCellN, col);

            PivodGrid.Children.Add(txtBlockCellN);
        }

        private void PrintTextToCell(Grid grid, string printValue, int row, int col)
        {
            TextBlock txtBlockCellN = new TextBlock();
            txtBlockCellN.Text = printValue;
            txtBlockCellN.FontSize = 14;
            txtBlockCellN.FontWeight = FontWeights.Bold;
            txtBlockCellN.Foreground = new SolidColorBrush(DefaultTextColor);
            txtBlockCellN.VerticalAlignment = VerticalAlignment.Center;
            txtBlockCellN.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(txtBlockCellN, row);
            Grid.SetColumn(txtBlockCellN, col);

            grid.Children.Add(txtBlockCellN);
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
            PivodGrid.ShowGridLines = ShowGridLines;
            PivodGrid.Background = new SolidColorBrush(TableBackgroundColor);

            PivodDataGrid.FrozenColumnCount = 3;
            PivodDataGrid.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            PivodDataGrid.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            PivodDataGrid.IsReadOnly = true;
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
            CreateDataGridColumn(FirstColumnWidthPixels, string.Empty, string.Empty, "Номер", "Column0");

            // Add second column header    
            PrintTextToCell("Сборные группы", 2, 1);
            CreateDataGridColumn(SecondColumnWidthPixels, string.Empty, string.Empty, "Сборные группы", "Column1");

            // Add third column header    
            PrintTextToCell("Даты проведения", 2, 2);
            CreateDataGridColumn(ThirdColumnWidthPixels, string.Empty, string.Empty, "Даты проведения", "Column2");

            var columnDic = pivodModelList.First().TourPlacesModels;

            int col = 3;

            foreach (var dictValue in columnDic)
            {
                PrintTextToCell(((YearMonthes) dictValue.Key.Month).ToString(), 0, col);

                PrintTextToCell(dictValue.Key.Day.ToString(), 1, col);

                PrintTextToCell(((WeekDays) dictValue.Key.DayOfWeek).ToString(), 2, col);

                CreateDataGridColumn(PivodColumnsWidthPixes, ((YearMonthes)dictValue.Key.Month).ToString()
                    , dictValue.Key.Day.ToString()
                    , ((WeekDays)dictValue.Key.DayOfWeek).ToString()
                    , string.Format("Column{0}", col));

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

        private void CreateRowDefinision(Grid grid, int height)
        {
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(height);
            grid.RowDefinitions.Add(gridRow1);
        }

        private void CreateColumnDefinision(int width)
        {
            PivodGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(width) });
        }

        private void CreateDataGridColumn(int width, string text1, string text2, string text3, string colBindingText)
        {
            DataTemplate dataTemplate = new DataTemplate();

            FrameworkElementFactory gridFactory = new FrameworkElementFactory(typeof(Grid));
            FrameworkElementFactory row1 = new FrameworkElementFactory(typeof(RowDefinition));
            FrameworkElementFactory row2 = new FrameworkElementFactory(typeof(RowDefinition));
            FrameworkElementFactory row3 = new FrameworkElementFactory(typeof(RowDefinition));

            row1.SetValue(RowDefinition.HeightProperty, new GridLength(1, GridUnitType.Auto));
            row2.SetValue(RowDefinition.HeightProperty, new GridLength(1, GridUnitType.Auto));
            row3.SetValue(RowDefinition.HeightProperty, new GridLength(1, GridUnitType.Auto));
            gridFactory.AppendChild(row1);
            gridFactory.AppendChild(row2);
            gridFactory.AppendChild(row3);

            FrameworkElementFactory tBlockFactory1 = new FrameworkElementFactory(typeof(TextBlock));
            tBlockFactory1.SetValue(Grid.ColumnProperty, 2);
            tBlockFactory1.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            tBlockFactory1.SetValue(TextBlock.TextProperty
                , string.Format("{0}                                   {1}                           {2}", text1, text2, text3));
            tBlockFactory1.SetValue(TextBlock.TextWrappingProperty, TextWrapping.Wrap);
            tBlockFactory1.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);

            gridFactory.AppendChild(tBlockFactory1);

            dataTemplate.VisualTree = gridFactory;

            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Width = width;
            c1.HeaderTemplate = dataTemplate;
            c1.Binding = new Binding(colBindingText);
            PivodDataGrid.Columns.Add(c1);
        }




    }
}
