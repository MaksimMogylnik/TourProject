using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProj.BLL.DTO
{
    public class PayedTourDTO
    {
        public int TourID { get; set; }
        public int ClientID { get; set; }
        public Nullable<decimal> Payment { get; set; }
    }
}
