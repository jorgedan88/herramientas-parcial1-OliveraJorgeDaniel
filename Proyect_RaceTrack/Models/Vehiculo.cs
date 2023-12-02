using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyect_RaceTrack.Models
{
    public class Vehiculo
    {
        public int VehiculoId { get; set; }
        public string? VehiculoNombre { get; set; }
        public string? VehiculoApellido { get; set; }
        public string? VehiculoTipo { get; set; }
        public string? VehiculoMatricula { get; set; }
        public DateTime VehiculoFabricacion { get; set; }
        public ICollection<Piloto> PilotoList { get; set; } = new List<Piloto>();
    }
}