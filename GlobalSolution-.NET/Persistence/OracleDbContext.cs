using GlobalSolution_.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution_.NET.Persistence
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {

        }
        public DbSet<CoordenadasModel> Coordenadas { get; set; }

        public DbSet<DeteccaoModel> Deteccao { get; set; }

        public DbSet<EspecieModel> Especie { get; set; }

        public DbSet<TiporiscoModel> Tiporisco { get; set; }
    }
}
