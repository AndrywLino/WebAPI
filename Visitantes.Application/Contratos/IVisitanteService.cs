using System.Threading.Tasks;
using Visitantes.Domain;

namespace Visitantes.Application.Contratos
{
    public interface IVisitanteService
    {
        Task<VisitanteModel> AddVisitantes(VisitanteModel model);
        Task<VisitanteModel> UpdateVisitantes(int Id, VisitanteModel model);
        Task<bool> DeleteVisitantes(int Id, VisitanteModel model);

        Task<VisitanteModel[]> GetVisitantesAsync();

        Task<VisitanteModel[]> GetVisitanteByCpfRgAsync(string cpfRg);
    }
}