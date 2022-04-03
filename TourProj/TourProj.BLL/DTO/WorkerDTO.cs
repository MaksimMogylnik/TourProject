using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProj.BLL.DTO
{
    public class WorkerDTO
    {
        public int WorkerID { get; set; }
        public string FullName { get; set; }
        public Nullable<int> PostID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> AcceptDate { get; set; }
        public Nullable<bool> IsFired { get; set; }
        public virtual List<TourDTO> Tours { get; set; }
    }
}
