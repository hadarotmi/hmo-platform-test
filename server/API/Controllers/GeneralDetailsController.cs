using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/GeneralDetails")]
    public class GeneralDetailsController : ApiController
    {
        [Route("NumberNotVaccine")]
        [HttpGet]
        public IHttpActionResult NumberNotVaccine()
        {
            return Ok(GeneralDetailsBL.NumberNotVaccine());
        }


        [Route("SickInMonth")]
        [HttpGet]
        public IHttpActionResult SickInMonth()
        {
            return Ok(GeneralDetailsBL.SickInMonth());
        }
    }
}
