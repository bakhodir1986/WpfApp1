using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class ResultModel
    {
        public ToursModel toursModel;
        public List<TourPlacesModel> tourPlacesModels;

        public ResultModel()
        {
            toursModel = new ToursModel();
            tourPlacesModels = new List<TourPlacesModel>();
        }
    }
}
