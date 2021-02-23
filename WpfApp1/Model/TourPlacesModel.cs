using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class TourPlacesModel
    {
        public int Id { get; set; }

        public int TourId { get; set; }

        public DateTime HappenDate { get; set; }

        public string PlaceName { get; set; }
    }
}
