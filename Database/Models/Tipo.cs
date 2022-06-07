using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        //Navigation Propery's

        public ICollection<Pokemon> Pokemon { get; set; }
        
    }
}
