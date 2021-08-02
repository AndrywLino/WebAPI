using System.Threading.Tasks;
using Visitantes.Domain;

namespace Visitantes.Persistence.Contratos
{
    public interface IVisitantesPersistence
    {
        Task<VisitanteModel[]> GetVisitantesAsync();

        Task<VisitanteModel[]> GetVisitanteByCpfRgAsync(string cpfRg);
    }
}