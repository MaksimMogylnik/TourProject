using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProj.BLL.DTO
{
    public class FullTourInfoDTO
    {
        public int TourID { get; set; }
        public string TourName { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<int> MaxPeople { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string TransportType { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> VisitDate { get; set; }
        public string HotelName { get; set; }
        public string HotelImageUri { get; set; }
        public string CoutryName { get; set; }
        public string CityName { get; set; }
        public string SightName { get; set; }
        public string SightImageUri { get; set; }
    }
}
