using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Race_Track.Models;

namespace Race_Track.Data
{
    public class VehiculoContext : DbContext
    {
        public VehiculoContext (DbContextOptions<VehiculoContext> options)
            : base(options)
        {
        }

        public DbSet<Race_Track.Models.Vehiculo> Vehiculo { get; set; } = default!;

        public DbSet<Race_Track.Models.Piloto> Piloto { get; set; } = default!;
    }
}
