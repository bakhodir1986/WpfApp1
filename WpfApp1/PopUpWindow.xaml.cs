using System;
using System.Collections.Generic;
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
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PopUpWindow.xaml
    /// </summary>
    public partial class PopUpWindow : Window
    {
        private PivodTableModel _model;

        public PopUpWindow(PivodTableModel model)
        {
            InitializeComponent();

            _model = model;

            DetailDg.IsReadOnly = true;

            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "HappenDate";
            c2.Width = 110;
            c2.Binding = new Binding("HappenDate");
            DetailDg.Columns.Add(c2);
            DataGridTextColumn c3 = new DataGridTextColumn();
            c3.Header = "PlaceName";
            c3.Width = 110;
            c3.Binding = new Binding("PlaceName");
            DetailDg.Columns.Add(c3);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TourId.Text = _model.TourId.ToString();
            JointGroups.Text = _model.JointGroups;
            FromStartTillEndDateWithDash.Text = _model.FromStartTillEndDateWithDash;

            foreach(var element in _model.TourPlacesModels)
            {
                if (!string.IsNullOrEmpty(element.Value))
                {
                    DetailDg.Items.Add(new TourPlacesModel() { HappenDate = element.Key, PlaceName = element.Value });
                }
                
            }
        }
    }
}
