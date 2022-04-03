using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProj.BLL.DTO
{
    public class SightDTO
    {
        public int SightID { get; set; }
        public string SightName { get; set; }
        public Nullable<int> CoutryID { get; set; }
        public Nullable<int> CityID { get; set; }
        public string ImageUri { get; set; }
    }
}
