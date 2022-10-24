using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GeneralDetailsBL
    {
        public static int NumberNotVaccine()
        {
            int count = 0;
            List<Patient> DalPatient = new List<Patient>();
            List<Covid19_Vaccine> DalCovid = new List<Covid19_Vaccine>();
            using (healthOrganizationDBEntities db = new healthOrganizationDBEntities())
            {
                DalPatient = db.Patients.ToList();
                DalCovid = db.Covid19_Vaccine.ToList();
            }
            foreach (var p in DalPatient)
            {
                var covid = DalCovid.FirstOrDefault(c => c.IdPatient == p.Id);
                if (covid == null)
                {
                    count++;
                }
            }

            return count;


        }

        public static int[] SickInMonth()
        {
            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int[] sickInMonth = new int[days];
            for (int i = 0; i < days; i++)
            {
                sickInMonth[i] = 0;
            }
            List<Patient> DalPatient = new List<Patient>();
            using (healthOrganizationDBEntities db = new healthOrganizationDBEntities())
            {
                DalPatient = db.Patients.ToList();
            }
            foreach (var p in DalPatient)
            {
                if (p.StartCovid19 != null && p.EndCovid19 == null)
                    if (p.StartCovid19.Value.Month == DateTime.Now.Month && p.StartCovid19.Value.Year == DateTime.Now.Year)
                    {
                        sickInMonth[p.StartCovid19.Value.Day - 1] += 1;
                    }
            }
            return sickInMonth;
        }
    }
}
