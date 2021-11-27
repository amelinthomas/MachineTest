using SalesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebAPI.Repository
{
    public class LoginRepo:ILogin
    {
        SalesContext _db;

        public LoginRepo(SalesContext db)
        {
            _db = db;
        }


        // get user details by using username and password
        public Login validateUser(string username, string password)
        {
            if (_db != null)
            {
       Login dbuser = _db.Login.FirstOrDefault(em => em.UserName == username && em.Password == password);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }
            return null;

        }
    }
}
