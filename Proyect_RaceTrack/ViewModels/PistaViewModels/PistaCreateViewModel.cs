using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyect_RaceTrack.Models;
using System.ComponentModel.DataAnnotations;
using Proyect_RaceTrack.Utils;

namespace Proyect_RaceTrack.ViewModels.PistaViewModels
{
    public class PistaCreateViewModel
    {

        public int PistaId { get; set; }
        [Display(Name = "Nombre de la pista")]
        [Required(ErrorMessage = "Debe ingresar el nombre de la pista")]
        public string? PistaNombre { get; set; }
        [Display(Name = "Nomenclatura")]
        [Required(ErrorMessage = "Debe ingresar la nomenclatura de la pista")]
        public int PistaCodigo { get; set; }
        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Debe ingresar el tipo de material")]
        public PistaType PistaMaterial { get; set; }
        [Display(Name = "Iluminacion")]
        public bool PistaIluminacion { get; set; } = true;
        [Display(Name = "Aprovisionamiento")]
        public bool PistaAprovisionamiento { get; set; } = true;
        [Display(Name = "Cocheras asignadas")]
        public List<int>? CocheraIds { get; set; }


        //public virtual List<Cochera> Cocheras { get; set; }
    }
}