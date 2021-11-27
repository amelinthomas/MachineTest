using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWebAPI.Models;
using SalesWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        //construct dependancy injection for postrepository
        IVisitRepo visitRepository;
        SalesContext context;
        public VisitController(IVisitRepo _p)
        {
            visitRepository = _p;

        }

        #region
        //Get all visits
        [HttpGet]
        [Route("GetVisits")]
        public async Task<ActionResult<IEnumerable<VisitTable>>> GetVisits()
        {


            try
            {

                var visits = await visitRepository.GetVisits();

                if (visits == null)
                {
                    return NotFound();
                }
                return Ok(visits);
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }
        #endregion

        #region Add a new visit
        [HttpPost]
        [Route("AddVisit")]
        public async Task<IActionResult> AddVisit([FromBody]  VisitTable model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var visitId = await visitRepository.AddVisit(model);
                    if (visitId > 0)
                    {
                        return Ok(visitId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Update Vist
        [HttpPut]
        [Route("UpdateVist")]
        public async Task<IActionResult> UpdateVist([FromBody] VisitTable model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await visitRepository.UpdateVisit(model);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
    
}
}
