using Microsoft.EntityFrameworkCore;
using Visitantes.Domain;

namespace Visitantes.Persistence.Contexto
{
    public class VisitantesContexto : DbContext
    {
        public DbSet<VisitanteModel> Visitantes { get; set; }

        public VisitantesContexto(DbContextOptions<VisitantesContexto> options) : base(options){ }
    }
}