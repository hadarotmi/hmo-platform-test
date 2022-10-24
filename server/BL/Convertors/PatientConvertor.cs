using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Convertors
{
    public class PatientConvertor
    {
        public static Patient ConvertPatientToDAL(PatientDTO myPatient)
        {
            return new Patient
            {
                Id = myPatient.Id,
                FirstName = myPatient.FirstName,
                LastName = myPatient.LastName,
                Address = myPatient.Address,
                Birth = myPatient.Birth,
                Telephone = myPatient.Telephone,
                Phone = myPatient.Phone,
                EndCovid19 = myPatient.EndCovid19,
                StartCovid19 = myPatient.StartCovid19
            };
        }

        public static PatientDTO ConvertPatientToDTO(Patient myPatient)
        {
            return new PatientDTO
            {
                Id = myPatient.Id,
                FirstName = myPatient.FirstName,
                LastName = myPatient.LastName,
                Address = myPatient.Address,
                Birth = myPatient.Birth,
                Telephone = myPatient.Telephone,
                Phone = myPatient.Phone,
                EndCovid19 = myPatient.EndCovid19,
                StartCovid19 = myPatient.StartCovid19
            };
        }
    }
}
