using SalesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebAPI.Repository
{
    public interface ILogin
    {
        // get user details by using username and password
        public Login validateUser(string username, string password);
    }
}
