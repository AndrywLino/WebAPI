using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Visitantes.Domain;
using Visitantes.Persistence.Contexto;
using Visitantes.Persistence.Contratos;

namespace Visitantes.Persistence
{
    public class VisitantesPersistence : IVisitantesPersistence
    {
        private readonly VisitantesContexto _context;
        public VisitantesPersistence(VisitantesContexto context)
        {
            _context = context;

        }

        public async Task<VisitanteModel[]> GetVisitantesAsync()
        {
            IQueryable<VisitanteModel> query = _context.Visitantes.Include(e => e.CpfRg).Include(e => e.Nome).Include(e => e.Local);

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<VisitanteModel[]> GetVisitanteByCpfRgAsync(string cpfRg)
        {
            IQueryable<VisitanteModel> query = _context.Visitantes.Include(e => e.CpfRg).Include(e => e.Nome).Include(e => e.Local);

            query = query.OrderBy(e => e.Id).Where(e => e.CpfRg.ToLower().Contains(cpfRg.ToLower()));

            return await query.ToArrayAsync();
        }

    }
}