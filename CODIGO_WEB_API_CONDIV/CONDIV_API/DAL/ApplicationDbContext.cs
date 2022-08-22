using Microsoft.EntityFrameworkCore;
using DAO.Models;
namespace API.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<CONDIV_TC_CONVERTIR> CONDIV_TC_CONVERTIR { get; set; }
        public DbSet<CONDIV_TC_CONVERTIR_MONEDA> CONDIV_TC_CONVERTIR_MONEDA { get; set; }
        public DbSet<CONDIV_TC_MONEDA> CONDIV_TC_MONEDA { get; set; }
        public DbSet<CONDIV_TC_TIPO_CAMBIO> CONDIV_TC_TIPO_CAMBIO { get; set; }
        public DbSet<CONDIV_TC_USUARIO> CONDIV_TC_USUARIO { get; set; }
        public DbSet<CONDIV_TH_USUARIO_DIVISA> CONDIV_TH_USUARIO_DIVISA { get; set; }
        public DbSet<CONDIV_TM_CATEGORIA_CAMBIO> CONDIV_TM_CATEGORIA_CAMBIO { get; set; }
    }
}
