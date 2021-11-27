using Microsoft.EntityFrameworkCore;
using SalesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebAPI.Repository
{
    public class Employee:IEmployee
    {
        SalesContext db;

         //constructor dependancy injection;
        public Employee(SalesContext _db)
        {
            db = _db;
        }
        #region
        public async Task<List<EmployeeRegistration>> GetEmployee()
        {

            if (db != null)
            {
                return await db.EmployeeRegistration.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add Employee
        public async Task<int> AddEmployee(EmployeeRegistration emp)
        {

            if (db != null)
            {
                await db.EmployeeRegistration.AddAsync(emp);
                await db.SaveChangesAsync(); //commit the transaction
                return emp.EmpId;
            }
            return 0;

        }
        #endregion

        #region
        public async Task UpdateEmployee(EmployeeRegistration emp)
        {
            if (db != null)
            {
                db.EmployeeRegistration.Update(emp);
                await db.SaveChangesAsync(); //commit the transaction

            }

        }
        #endregion

    }
}
