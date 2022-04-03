using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProj.BLL.DTO
{
    public class TourVisitDTO
    {
        public int TourID { get; set; }
        public int CoutryID { get; set; }
        public int CityID { get; set; }
        public int HotelID { get; set; }
        public Nullable<System.DateTime> VisitDate { get; set; }
    }
}
