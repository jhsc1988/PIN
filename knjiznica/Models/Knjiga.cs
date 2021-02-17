using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace knjiznica.Models
{
    public class Knjiga
    {
        public int Id { get; set; }

        [Required]
        public string Naslov { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public string Izdavac { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumIzdavanja { get; set; }

    }
}
