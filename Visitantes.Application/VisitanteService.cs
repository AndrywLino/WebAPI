using System.Threading.Tasks;
using Visitantes.Application.Contratos;
using Visitantes.Domain;

namespace Visitantes.Application
{
    public class VisitanteService : IVisitanteService
    {
        public Task<VisitanteModel> AddVisitantes(VisitanteModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteVisitantes(int Id, VisitanteModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task<VisitanteModel[]> GetVisitanteByCpfRgAsync(string cpfRg)
        {
            throw new System.NotImplementedException();
        }

        public Task<VisitanteModel[]> GetVisitantesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<VisitanteModel> UpdateVisitantes(int Id, VisitanteModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}