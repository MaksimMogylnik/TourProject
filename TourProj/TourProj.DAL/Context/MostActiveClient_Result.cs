//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TourProj.DAL.Context
{
    using System;
    
    public partial class MostActiveClient_Result
    {
        public int ID { get; set; }
        public Nullable<int> CountID { get; set; }
        public int ClientID { get; set; }
        public string ClientFullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
    }
}