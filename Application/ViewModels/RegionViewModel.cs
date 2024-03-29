﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class RegionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debes Colocar el nombre de la region")]
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
