using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vježba_6.Models
{
    public class Ptice
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Vrsta { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum rođenja")]
        public DateTime DatSnimanja { get; set; }


    }
}
