using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1
{
    public static class DataProvider
    {
        public static List<ResultModel> GetResultModels()
        {
            string dateString, format;
            DateTime result;
            CultureInfo provider = CultureInfo.InvariantCulture;

            format = "dd.MM.yyyy";

            var resultModelList = new List<ResultModel>();

            #region Tour1
            var result1 = new ResultModel();
            var tourPlaceDaysList1 = new List<TourPlacesModel>();
            var tour1 = new ToursModel();

            result1.toursModel = tour1;
            result1.tourPlacesModels = tourPlaceDaysList1;

            resultModelList.Add(result1);

            tour1.Id = 1;
            tour1.JointGroups = "Tour # 1";
            dateString = "15.01.2021";
            tour1.StartDate = DateTime.ParseExact(dateString, format, provider);
            dateString = "18.01.2021";
            tour1.EndDate = DateTime.ParseExact(dateString, format, provider);
            tour1.Status = 1;
            tour1.PeopleCount = 2;
        

            var tourPlaceDay1 = new TourPlacesModel();
            tourPlaceDay1.Id = 1;
            tourPlaceDay1.TourId = 1;
            dateString = "15.01.2021";
            tourPlaceDay1.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlaceDay1.PlaceName = "Day1 Place #";

            tourPlaceDaysList1.Add(tourPlaceDay1);

            var tourPlaceDay2 = new TourPlacesModel();
            tourPlaceDay2.Id = 2;
            tourPlaceDay2.TourId = 1;
            dateString = "16.01.2021";
            tourPlaceDay2.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlaceDay2.PlaceName = "Day2 Place #";

            tourPlaceDaysList1.Add(tourPlaceDay2);

            var tourPlaceDay3 = new TourPlacesModel();
            tourPlaceDay3.Id = 3;
            tourPlaceDay3.TourId = 1;
            dateString = "17.01.2021";
            tourPlaceDay3.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlaceDay3.PlaceName = "Day3 Place #";

            tourPlaceDaysList1.Add(tourPlaceDay3);

            var tourPlaceDay4 = new TourPlacesModel();
            tourPlaceDay4.Id = 4;
            tourPlaceDay4.TourId = 1;
            dateString = "18.01.2021";
            tourPlaceDay4.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlaceDay4.PlaceName = "Day4 Place #";

            tourPlaceDaysList1.Add(tourPlaceDay4);

            #endregion

            #region Tour2
            var result2 = new ResultModel();
            var tourPlaceDaysList2 = new List<TourPlacesModel>();
            var tour2 = new ToursModel();

            result2.toursModel = tour2;
            result2.tourPlacesModels = tourPlaceDaysList2;

            resultModelList.Add(result2);

            tour2.Id = 2;
            tour2.JointGroups = "Tour # 2";
            dateString = "16.01.2021";
            tour2.StartDate = DateTime.ParseExact(dateString, format, provider);
            dateString = "21.01.2021";
            tour2.EndDate = DateTime.ParseExact(dateString, format, provider);
            tour2.Status = 0;
            tour2.PeopleCount = 4;


            var tourPlace1Day1 = new TourPlacesModel();
            tourPlace1Day1.Id = 1;
            tourPlace1Day1.TourId = 2;
            dateString = "16.01.2021";
            tourPlace1Day1.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlace1Day1.PlaceName = "Day1 Place 2 #";

            tourPlaceDaysList2.Add(tourPlace1Day1);

            var tourPlace1Day2 = new TourPlacesModel();
            tourPlace1Day2.Id = 2;
            tourPlace1Day2.TourId = 2;
            dateString = "17.01.2021";
            tourPlace1Day2.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlace1Day2.PlaceName = "Day2 Place 2 #";

            tourPlaceDaysList2.Add(tourPlace1Day2);

            var tourPlace1Day3 = new TourPlacesModel();
            tourPlace1Day3.Id = 3;
            tourPlace1Day3.TourId = 2;
            dateString = "18.01.2021";
            tourPlace1Day3.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlace1Day3.PlaceName = "Day3 Place 2 #";

            tourPlaceDaysList2.Add(tourPlace1Day3);

            var tourPlace1Day4 = new TourPlacesModel();
            tourPlace1Day4.Id = 4;
            tourPlace1Day4.TourId = 1;
            dateString = "19.01.2021";
            tourPlace1Day4.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlace1Day4.PlaceName = "Day4 Place 2 #";

            tourPlaceDaysList2.Add(tourPlace1Day4);

            var tourPlace1Day5 = new TourPlacesModel();
            tourPlace1Day5.Id = 5;
            tourPlace1Day5.TourId = 1;
            dateString = "20.01.2021";
            tourPlace1Day5.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlace1Day5.PlaceName = "Day5 Place 2 #";

            tourPlaceDaysList2.Add(tourPlace1Day5);

            var tourPlace1Day6 = new TourPlacesModel();
            tourPlace1Day6.Id = 5;
            tourPlace1Day6.TourId = 1;
            dateString = "21.01.2021";
            tourPlace1Day6.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlace1Day6.PlaceName = "Day6 Place 2 #";

            tourPlaceDaysList2.Add(tourPlace1Day6);

            #endregion

            #region Tour3
            var result3 = new ResultModel();
            var tourPlaceDaysList3 = new List<TourPlacesModel>();
            var tour3 = new ToursModel();

            result3.toursModel = tour3;
            result3.tourPlacesModels = tourPlaceDaysList3;

            resultModelList.Add(result3);

            tour3.Id = 3;
            tour3.JointGroups = "Tour # 3";
            dateString = "01.03.2021";
            tour3.StartDate = DateTime.ParseExact(dateString, format, provider);
            dateString = "05.03.2021";
            tour3.EndDate = DateTime.ParseExact(dateString, format, provider);
            tour3.Status = 2;
            tour3.PeopleCount = 4;


            var tourPlace3Day1 = new TourPlacesModel();
            tourPlace3Day1.Id = 1;
            tourPlace3Day1.TourId = 2;
            dateString = "01.03.2021";
            tourPlace3Day1.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlace3Day1.PlaceName = "Day1 Place 2 $$$$";

            tourPlaceDaysList3.Add(tourPlace3Day1);

            var tourPlace3Day2 = new TourPlacesModel();
            tourPlace3Day2.Id = 1;
            tourPlace3Day2.TourId = 2;
            dateString = "02.03.2021";
            tourPlace3Day2.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlace3Day2.PlaceName = "Day2 Place 2 $$$$";

            tourPlaceDaysList3.Add(tourPlace3Day2);

            var tourPlace3Day3 = new TourPlacesModel();
            tourPlace3Day3.Id = 1;
            tourPlace3Day3.TourId = 2;
            dateString = "03.03.2021";
            tourPlace3Day3.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlace3Day3.PlaceName = "Day3 Place 2 $$$$";

            tourPlaceDaysList3.Add(tourPlace3Day3);

            var tourPlace3Day4 = new TourPlacesModel();
            tourPlace3Day4.Id = 1;
            tourPlace3Day4.TourId = 2;
            dateString = "04.03.2021";
            tourPlace3Day4.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlace3Day4.PlaceName = "Day4 Place 2 $$$$";

            tourPlaceDaysList3.Add(tourPlace3Day4);

            var tourPlace3Day5 = new TourPlacesModel();
            tourPlace3Day5.Id = 1;
            tourPlace3Day5.TourId = 2;
            dateString = "05.03.2021";
            tourPlace3Day5.HappenDate = DateTime.ParseExact(dateString, format, provider);
            tourPlace3Day5.PlaceName = "Day5 Place 2 $$$$";

            tourPlaceDaysList3.Add(tourPlace3Day5);

            #endregion

            return resultModelList;
        }
    }
}
