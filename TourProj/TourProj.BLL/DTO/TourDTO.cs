using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProj.BLL.DTO
{
    public class TourDTO
    {
        public int TourID { get; set; }
        public string TourName { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<int> TransportID { get; set; }
        public Nullable<int> MaxPeople { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
