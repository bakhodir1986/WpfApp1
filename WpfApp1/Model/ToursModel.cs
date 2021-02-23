using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class ToursModel
    {
        public int Id { get; set; }
        public string JointGroups { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PeopleCount { get; set; }
        public int Status { get; set; }
    }

    public enum StatusColor
    {
        Gray = 0,
        Blue,
        Red
    }
}
