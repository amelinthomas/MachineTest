using Microsoft.EntityFrameworkCore;
using SalesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebAPI.Repository
{
    public class VisitRepo:IVisitRepo
    {
        SalesContext db;

        //constructor dependancy injection;
        public VisitRepo(SalesContext _db)
        {
            db = _db;
        }
        #region
        public async Task<List<VisitTable>> GetVisits()
        {

            if (db != null)
            {
                return await db.VisitTable.ToListAsync();
            }
            return null;
        }
        #endregion
        #region Add Visit
        public async Task<int> AddVisit(VisitTable visit)
        {

            if (db != null)
            {
                await db.VisitTable.AddAsync(visit);
                await db.SaveChangesAsync(); //commit the transaction
                return visit.VisitId;
            }
            return 0;

        }
        #endregion

        #region
        public async Task UpdateVisit(VisitTable visit)
        {
            if (db != null)
            {
                db.VisitTable.Update(visit);
                await db.SaveChangesAsync(); //commit the transaction

            }

        }
        #endregion
    }
}
