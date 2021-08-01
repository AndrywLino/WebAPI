using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Visitantes.API.Data;
using Visitantes.API.Models;

namespace Visitantes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitantesController : ControllerBase
    {
        private readonly VisitanteContexto _context;
        public VisitantesController(VisitanteContexto context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<VisitanteModel> Get()
        {
            return _context.Visitantes;
        }

        [HttpGet("{cpfRg}")]
        public VisitanteModel GetByCpfOrRG(int cpfRg)
        {
            return _context.Visitantes.FirstOrDefault(visitante => visitante.CpfRg == cpfRg);
        }
    }
}
