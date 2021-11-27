using SalesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebAPI.Repository
{
   public interface IVisitRepo
    {
        //Asynchronous operation
        Task<List<VisitTable>> GetVisits();

        //add visit
        Task<int> AddVisit(VisitTable visit);

        //update visit
        Task UpdateVisit(VisitTable visit);
    }
}
