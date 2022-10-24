using BL;
using DTO;
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
    [RoutePrefix("api/Vaccines")]
    public class VaccinesController : ApiController
    {
        [Route("AddVaccineToPatient")]
        [HttpPost]
        public IHttpActionResult AddVaccineToPatient(Covid19VaccineDTO vaccine)
        {
            try
            {
                VaccinesBL.AddVaccineToPatient(vaccine);
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }

        }
        [Route("GetVaccinesToPatient/{PatientId}")]
        [HttpGet]
        public IHttpActionResult GetVaccineToPatient(string PatientId)
        {
            return Ok(VaccinesBL.GetVaccineToPatient(PatientId));
        }

    }
}
