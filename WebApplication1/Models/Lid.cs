using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Lid
    {
        public int LidId { get; set; }
        
        public string Naam { get; set; }

        public DateTime Geboortedatum { get; set; }

        public string Tussenvoegsel { get; set; }

        public string Achternaam { get; set; }

        public string Aanhef { get; set; }

        public string Geslacht { get; set; }

        public string PostAdres { get; set; }

        public string Plaats { get; set; }

        public int Tel { get; set; }

        public int Mobiel { get; set; }

        public string Email { get; set; }

        public string SoortLid { get; set; }

        public int Betaald { get; set; }
    }
}
