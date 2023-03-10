using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.DAL.DbModels
{
    public class Medicine: Base
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Composition { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Cost { get; set; }
        public string Type { get; set; }
        public string Dose { get; set; }
        public string Description { get; set; }
    }
}
