using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace herramientas_parcial1_OliveraJorgeDaniel.Models
{
    public class Piloto
    {
        public int PilotoId { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el nombre del piloto")]
        [MinLength(3, ErrorMessage = "El nombre ingresado debe poseer mas de tres letras")]
        [MaxLength(15)]
        public string? PilotoNombre { get; set; }
        public string? PilotoApellido { get; set; }
        public int PilotoDni { get; set; }
        public int PilotoNumeroLicencia { get; set; }
        public DateTime PilotoExpedicion { get; set; }
        public bool PilotoPropietario { get; set; } = true;
        public int VehiculoId { get; set; }
        public virtual Vehiculo? Vehiculo { get; set; }
    }
}