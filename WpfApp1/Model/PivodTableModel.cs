using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class PivodTableModel
    {
        public int TourId { get; set; }

        public string JointGroups { get; set; }

        public string FromStartTillEndDateWithDash { get; set; }

        public int Status { get; set; }

        public StatusColor colorOfRow { get; set; }

        public Dictionary<DateTime,string>  TourPlacesModels { get; set; }

        public PivodTableModel()
        {
            TourPlacesModels = new Dictionary<DateTime, string>();
        }
    }

}
