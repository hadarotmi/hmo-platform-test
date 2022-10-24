using BL;
using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Patients")]
    public class PatientController : ApiController
    {
        [Route("AddPatient")]
        [HttpPost]
        public IHttpActionResult AddPatient(PatientDTO patient )
        {
            try
            {
                PatientBL.AddPatient(patient);
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
            
        }


        [Route("GetPatient")]
        [HttpGet]
        public IHttpActionResult GetPatient()
        {
            return Ok(PatientBL.GetAllPatients());
        }

        

        [HttpGet]
        [Route("GetCurrentPatient/{PatientId}")]
        public IHttpActionResult GetCurrentPatient(string PatientId)
        {
            return Ok(PatientBL.GetCurrentPatient(PatientId));
        }

        [Route("UpdatePatient")]
        [HttpPost]
        public IHttpActionResult UpdatePatient(PatientDTO patient)
        {
            try
            {
                PatientBL.UpdatePatient(patient);
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
          
        }

        [Route("DeletePatient/{patientId}")]
        [HttpDelete]
        public IHttpActionResult DeletePatient(string patientId)
        {
            try
            {
                PatientBL.DeletePatient(patientId);
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }

       

    }
}
