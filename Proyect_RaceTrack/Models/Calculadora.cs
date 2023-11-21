using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Precio.Models
{
    public class Calculadora
    {
        public int Id { get; set; }
        public int Costo { get; set; }
        public int Cantidad { get; set; }
        public int Resultado { get; set; }
        public int Instruccion { get; set; }
    }
}