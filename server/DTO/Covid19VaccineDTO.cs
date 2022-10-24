using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Covid19VaccineDTO
    {
        public string IdPatient { get; set; }
        public int NumberOfVaccine { get; set; }
        public DateTime DateOfVaccine { get; set; }
        public string Creator { get; set; }
    }
}
