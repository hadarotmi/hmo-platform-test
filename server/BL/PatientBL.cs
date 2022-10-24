using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PatientBL
    {

        public static void AddPatient(PatientDTO patient)
        {
            using (healthOrganizationDBEntities db = new healthOrganizationDBEntities())
            {
                db.Patients.Add(Convertors.PatientConvertor.ConvertPatientToDAL(patient));
                db.SaveChanges();
            }
        }

        public static List<PatientDTO> GetAllPatients()
        {
            try
            {
                List<Patient> DalPatient = new List<Patient>();
                using (healthOrganizationDBEntities db = new healthOrganizationDBEntities())
                {
                    DalPatient = db.Patients.ToList();
                }
                List<PatientDTO> DtoPatient = new List<PatientDTO>();
                foreach (var p in DalPatient)
                {
                    DtoPatient.Add(
                        Convertors.PatientConvertor.ConvertPatientToDTO(p)
                        );
                }

                return DtoPatient;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static PatientDTO GetCurrentPatient(string id)
        {

            using (healthOrganizationDBEntities db = new healthOrganizationDBEntities())
            {
                var patient = (from p in db.Patients
                               where p.Id.Equals(id)
                               select p).ToList();
                return patient.Select(d => Convertors.PatientConvertor.ConvertPatientToDTO(d)).FirstOrDefault();
                
            }

        }

        public static bool UpdatePatient(PatientDTO patient)
        {

            try
            {
                using (healthOrganizationDBEntities db = new healthOrganizationDBEntities())
                {
                    Patient newPatient = Convertors.PatientConvertor.ConvertPatientToDAL(patient);
                    db.Patients.FirstOrDefault(d => d.Id == newPatient.Id).FirstName = newPatient.FirstName;
                    db.Patients.FirstOrDefault(d => d.Id == newPatient.Id).LastName = newPatient.LastName;
                    db.Patients.FirstOrDefault(d => d.Id == newPatient.Id).Address = newPatient.Address;
                    db.Patients.FirstOrDefault(d => d.Id == newPatient.Id).Telephone = newPatient.Telephone;
                    db.Patients.FirstOrDefault(d => d.Id == newPatient.Id).Phone = newPatient.Phone;
                    db.Patients.FirstOrDefault(d => d.Id == newPatient.Id).StartCovid19 = newPatient.StartCovid19;
                    db.Patients.FirstOrDefault(d => d.Id == newPatient.Id).EndCovid19 = newPatient.EndCovid19;

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }

        public static bool DeletePatient(string Id)
        {
            try
            {
                using (healthOrganizationDBEntities db = new healthOrganizationDBEntities())
                {
                    var patient = (from p in db.Patients
                                   where p.Id.Equals(Id)
                                   select p);
                    db.Patients.Remove(patient.First());


                    var vaccinesToPatient = (from v in db.Covid19_Vaccine
                                             where v.IdPatient.Equals(Id)
                                             select v);
                    foreach (var vac in vaccinesToPatient)
                    {
                        db.Covid19_Vaccine.Remove(vac);
                    }

                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

       
    }
}
