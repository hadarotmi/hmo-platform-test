using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PatientDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Birth { get; set; }
        public string Telephone { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> StartCovid19 { get; set; }
        public Nullable<System.DateTime> EndCovid19 { get; set; }

    }
}
