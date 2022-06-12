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
        [Required(ErrorMessage = "Debes Colocar el link de la imagen")]
        public string ImgUrl { get; set; }
        [Required(ErrorMessage = "Debes Colocar el tipo de pokemon")]
        public int TipoId { get; set; }
        public int TipoIdSec { get; set; }
        [Required(ErrorMessage = "Debes Colocar la region del pokemon")]
        public int RegionId { get; set; }


    }
}
