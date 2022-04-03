using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProj.BLL.DTO
{
    public class ClientDTO
    {
        public int ClientID { get; set; }
        public string ClientFullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
    }
}
