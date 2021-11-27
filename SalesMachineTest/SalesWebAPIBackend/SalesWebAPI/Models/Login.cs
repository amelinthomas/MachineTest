using System;
using System.Collections.Generic;

namespace SalesWebAPI.Models
{
    public partial class Login
    {
        public Login()
        {
            EmployeeRegistration = new HashSet<EmployeeRegistration>();
        }

        public int LId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<EmployeeRegistration> EmployeeRegistration { get; set; }
    }
}
