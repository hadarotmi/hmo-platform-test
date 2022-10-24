using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Convertors
{
    public class Covid19VaccineConvertor
    {
        public static Covid19_Vaccine ConvertCovid19VaccineToDAL(Covid19VaccineDTO myPatient)
        {
            return new Covid19_Vaccine
            {
                IdPatient = myPatient.IdPatient,
                NumberOfVaccine = myPatient.NumberOfVaccine,
                DateOfVaccine = myPatient.DateOfVaccine,
                Creator_ = myPatient.Creator,

            };
        }

        public static Covid19VaccineDTO ConvertCovid19VaccineToDTO(Covid19_Vaccine myPatient)
        {
            return new Covid19VaccineDTO
            {
                IdPatient = myPatient.IdPatient,
                NumberOfVaccine = myPatient.NumberOfVaccine,
                DateOfVaccine = myPatient.DateOfVaccine,
                Creator = myPatient.Creator_,
            };
        }
    }
}
