using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }


        //Fk's
        public int TipoId { get; set; }
        public int RegionId { get; set; }

        //Navigation Property's
        public Tipo Tipo { get; set; }
        public Region Region { get; set; }
    }
}
