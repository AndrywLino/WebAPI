using Microsoft.EntityFrameworkCore;
using Visitantes.API.Models;

namespace Visitantes.API.Data
{
    public class VisitanteContexto : DbContext
    {
        public DbSet<VisitanteModel> Visitantes { get; set; }

        public VisitanteContexto(DbContextOptions<VisitanteContexto> options) : base(options){ }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Password=apaj1916;Persist Security Info=True;User ID=sa;Initial Catalog=VisitantesDB;Data Source=DESKTOP-798N3ET");
        // }
    }
}