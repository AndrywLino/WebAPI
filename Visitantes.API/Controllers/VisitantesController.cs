using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Visitantes.Domain;
using Visitantes.Application.Contratos;
using Microsoft.AspNetCore.Http;
using Visitantes.Persistence.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace Visitantes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitantesController : ControllerBase
    {
        private readonly IVisitanteService _visitanteService;
        private readonly VisitantesContexto _context;
        public VisitantesController(IVisitanteService visitanteService, VisitantesContexto context)
        {
            _context = context;
            _visitanteService = visitanteService;

        }

        //não funciona

        // [HttpGet]
        // public async Task<IActionResult> Get()
        // {
        //     try
        //     {
        //         var visitantes = await _visitanteService.GetVisitantesAsync();
        //         if (visitantes == null)
        //             return NotFound("Nenhum visitante encontrado.");

        //         return Ok(visitantes);
        //     }
        //     catch(Exception ex)
        //     {
        //         return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar visitantes. Erro: {ex.Message}");
        //     }
        // }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetById(int id)
        // {
        //     try
        //     {
        //         var visitante = await _visitanteService.GetVisitanteByIdAsync(id);
        //         if (visitante == null)
        //             return NotFound("Nenhum visitante encontrado.");

        //         return Ok(visitante);
        //     }
        //     catch(Exception ex)
        //     {
        //         return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar visitantes. Erro: {ex.Message}");
        //     }
        // }

        // [HttpGet("cpfrg/{cpfRg}")]
        // public async Task<IActionResult> GetByCpfRg(string cpfRg)
        // {
        //     try
        //     {
        //         var visitante = await _visitanteService.GetVisitanteByCpfRgAsync(cpfRg);
        //         if (visitante == null)
        //             return NotFound("Nenhum visitante encontrado.");

        //         return Ok(visitante);
        //     }
        //     catch(Exception ex)
        //     {
        //         return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar visitantes. Erro: {ex.Message}");
        //     }
        // }

        [HttpPost]
        public async Task<IActionResult> Post(VisitanteModel model)
        {
            try
            {
                model.Entrada = System.DateTime.Now;
                var visitante = await _visitanteService.AddVisitantes(model);
                if (visitante == null)
                    return BadRequest("Erro ao cadastrar visitante.");

                return Ok(visitante);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar visitantes. Erro: {ex.Message}");
            }
        }


        //primeira parte get funciona

        // private readonly VisitantesContexto _context;
        // public VisitantesController(VisitantesContexto context)
        // {
        //     _context = context;

        // }

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
    }
}
