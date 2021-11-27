using SalesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebAPI.Repository
{
    public interface IEmployee
    {
        //Asynchronous operation
        Task<List<EmployeeRegistration>> GetEmployee();

        //add employee
        Task<int> AddEmployee(EmployeeRegistration emp);

        //update employee
        Task UpdateEmployee(EmployeeRegistration emp);

        
    }
}
