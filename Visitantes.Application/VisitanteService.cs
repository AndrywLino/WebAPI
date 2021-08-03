using System;
using System.Threading.Tasks;
using Visitantes.Application.Contratos;
using Visitantes.Domain;
using Visitantes.Persistence.Contratos;

namespace Visitantes.Application
{
    public class VisitanteService : IVisitanteService
    {
        private readonly IGeralPersistence _geralPersist;
        private readonly IVisitantesPersistence _visitantePersist;
        public VisitanteService(IGeralPersistence geralPersist, IVisitantesPersistence visitantePersist)
        {
            _visitantePersist = visitantePersist;
            _geralPersist = geralPersist;

        }
        public async Task<VisitanteModel> AddVisitantes(VisitanteModel model)
        {
            try
            {
                _geralPersist.Add<VisitanteModel>(model);
                if(await _geralPersist.SaveChangesAsync())
                {
                    return model;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VisitanteModel> UpdateVisitantes(int id, VisitanteModel model)
        {
            try
            {
                var visitante = await _visitantePersist.GetVisitanteByIdAsync(id);
                if(visitante == null)
                    return null;

                model.Id = id;
                
                _geralPersist.Update(model);
                if(await _geralPersist.SaveChangesAsync())
                {
                    return model;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteVisitantes(int id)
        {
            try
            {
                var visitante = await _visitantePersist.GetVisitanteByIdAsync(id);
                if(visitante == null)
                    throw new Exception("Visitante não encontrado.");
                
                _geralPersist.Delete<VisitanteModel>(visitante);
                return await _geralPersist.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VisitanteModel[]> GetVisitanteByCpfRgAsync(string cpfRg)
        {
            try
            {
                var visitantes = await _visitantePersist.GetVisitanteByCpfRgAsync(cpfRg);
                if(visitantes == null)
                    return null;
                return visitantes;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VisitanteModel[]> GetVisitantesAsync()
        {
            try
            {
                var visitantes = await _visitantePersist.GetVisitantesAsync();
                if(visitantes == null)
                    return null;
                return visitantes;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VisitanteModel> GetVisitanteByIdAsync(int Id)
        {
            try
            {
                var visitante = await _visitantePersist.GetVisitanteByIdAsync(Id);
                if(visitante == null)
                    return null;
                return visitante;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}