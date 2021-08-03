using System.Threading.Tasks;
using Visitantes.Domain;

namespace Visitantes.Application.Contratos
{
    public interface IVisitanteService
    {
        Task<VisitanteModel> AddVisitantes(VisitanteModel model);
        Task<VisitanteModel> UpdateVisitantes(int id, VisitanteModel model);
        Task<bool> DeleteVisitantes(int id);

        Task<VisitanteModel[]> GetVisitantesAsync();

        Task<VisitanteModel> GetVisitanteByIdAsync(int id);

        Task<VisitanteModel[]> GetVisitanteByCpfRgAsync(string cpfRg);
    }
}