using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using herramientas_parcial1_OliveraJorgeDaniel.Utils;

namespace herramientas_parcial1_OliveraJorgeDaniel.Models
{
    public class Cochera
    {
        public int CocheraId { get; set; }
        public CocheraType CocheraSector { get; set; }
        public bool CocheraAptoMantenimiento { get;set;} = true;
        public bool CocheraOficinas { get;set;} = true;

    }
}