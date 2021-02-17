using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace primjer_5_IdentityApp.Models
{
    public class Ispit
    {
        public int Id { get; set; }
        public string predmet{ get; set; }

        [DataType(DataType.Date)]
        public DateTime Datm{ get; set; }
    }
}
