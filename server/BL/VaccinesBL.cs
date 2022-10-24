using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class VaccinesBL
    {
        public static void AddVaccineToPatient(Covid19VaccineDTO Vaccine)
        {
            using (healthOrganizationDBEntities db = new healthOrganizationDBEntities())
            {
                db.Covid19_Vaccine.Add(Convertors.Covid19VaccineConvertor.ConvertCovid19VaccineToDAL(Vaccine));
                db.SaveChanges();
            }
        }


        public static List<Covid19VaccineDTO> GetVaccineToPatient(string Id)
        {

            try
            {
                List<Covid19_Vaccine> DalCovid = new List<Covid19_Vaccine>();
                using (healthOrganizationDBEntities db = new healthOrganizationDBEntities())
                {
                    DalCovid = db.Covid19_Vaccine.ToList();
                }
                List<Covid19VaccineDTO> DtoCvid = new List<Covid19VaccineDTO>();
                foreach (var c in DalCovid)
                {
                    if (c.IdPatient.ToString()==Id+" ")
                    {
                        DtoCvid.Add(
                                    Convertors.Covid19VaccineConvertor.ConvertCovid19VaccineToDTO(c));
                    }
                      
                }

                return DtoCvid;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

     
    }
}
