using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.DAL.DbModels
{
    public class Appointment:Base
    {
        [ForeignKey("Hospital")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
