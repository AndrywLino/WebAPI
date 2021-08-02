using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Visitantes.Persistence;
using Visitantes.Domain;
using Visitantes.Persistence.Contexto;

namespace Visitantes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitantesController : ControllerBase
    {
        private readonly VisitantesContexto _context;
        public VisitantesController(VisitantesContexto context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<VisitanteModel> Get()
        {
            return _context.Visitantes;
        }

        [HttpGet("{cpfRg}")]
        public VisitanteModel GetByCpfOrRG(string cpfRg)
        {
            return _context.Visitantes.FirstOrDefault(visitante => visitante.CpfRg == cpfRg);
        }

        // [HttpPost]
        // public VisitanteModel PostVisitante(VisitanteModel model)
        // {
        //     var evento = _context.Visitantes.AddDbContext(model);
        //     return model;
        // }
    }
}
