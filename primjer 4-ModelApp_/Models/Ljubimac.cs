using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace primjer_4_ModelApp.Models
{
    public class Ljubimac
    {
        [Required, MaxLength(40)]
        public int Id { get; set; }
        public string Ime { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum rođenja")]
        public DateTime DatRod { get; set; }

        [MaxLength(400)]
        public string Opis { get; set; }

        [Display(Name ="Životinjska vrsta")]

        public Vrsta Vrsta { get; set; }
        public int VrstaId { get; set; }

    }
}