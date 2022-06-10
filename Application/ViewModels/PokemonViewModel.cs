using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PokemonViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debes Colocar el nombre del Pokemon")]
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public int TipoId { get; set; }
        public int TipoIdSec { get; set; }
        public int RegionId { get; set; }


    }
}
