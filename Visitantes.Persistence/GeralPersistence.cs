using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Visitantes.Domain;
using Visitantes.Persistence.Contexto;
using Visitantes.Persistence.Contratos;

namespace Visitantes.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly VisitantesContexto _context;
        public GeralPersistence(VisitantesContexto context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}