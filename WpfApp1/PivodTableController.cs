using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using WpfApp1.Model;

namespace WpfApp1
{
    public class PivodTableController
    {
        private DateTime? GetMinDate(List<ResultModel> inputData)
        {
            var minDate = inputData?.Min(r => r.toursModel.StartDate);

            return minDate;
        }

        private DateTime? GetMaxDate(List<ResultModel> inputData)
        {
            var maxDate = inputData?.Max(r => r.toursModel.EndDate);

            return maxDate;
        }

        public List<PivodTableModel> ProcessPivodTable(List<ResultModel> inputData)
        {
            var minDate = GetMinDate(inputData);
            var maxDate = GetMaxDate(inputData);

            var datesList = generateDateTimesBetween(minDate, maxDate);

            var resultList = new List<PivodTableModel>();

            foreach (var value in inputData)
            {
                var model = new PivodTableModel();

                model.TourId = value.toursModel.Id;
                model.JointGroups = value.toursModel.JointGroups;
                model.FromStartTillEndDateWithDash = string.Format("{0}-{1}",
                    value.toursModel.StartDate.ToString("dd.MM.yyyy"),
                    value.toursModel.EndDate.ToString("dd.MM.yyyy"));

                model.Status = value.toursModel.Status;
                model.colorOfRow = (StatusColor)value.toursModel.Status;

                foreach (var date in datesList)
                {
                    var tourPlacesModels = 
                        value.tourPlacesModels.Where(z => z.HappenDate == date);

                    string descForDate = string.Empty;

                    if (tourPlacesModels.Any())
                    {
                        descForDate = tourPlacesModels.First().PlaceName;
                    }

                    model.TourPlacesModels.Add(date, descForDate);
                }

                resultList.Add(model);
            }

            return resultList;
        }

        private List<DateTime> generateDateTimesBetween(DateTime? minDate, DateTime? maxDate)
        {
            if (minDate == null || maxDate == null) return new List<DateTime>();

            if (minDate > maxDate) throw new ArgumentException("mindate is bigger then maxdate");

            var resultList = new List<DateTime>();
            DateTime currentDateTime = minDate.Value;

            while (currentDateTime <= maxDate.Value)
            {
                resultList.Add(currentDateTime);
                currentDateTime = currentDateTime.AddDays(1);
            }

            return resultList;
        }
    }
}
