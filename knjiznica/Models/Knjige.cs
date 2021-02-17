using System;
using System.ComponentModel.DataAnnotations;

namespace knjiznica.Models
{
    public class Knjige
    {
        public int Id { get; set; }

        [Required]
        public string naslov { get; set; }

        [Required]
        public string Izdavač { get; set; }

        [Required]
        public string ISBN { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime datumIzdavanja { get; set; }
    }
}
