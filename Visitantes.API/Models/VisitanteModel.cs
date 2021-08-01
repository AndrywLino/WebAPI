using System;

namespace Visitantes.API.Models
{
    public class VisitanteModel
    {
        public int Id { get; set; }
        public int CpfRg { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public DateTime Entrada { get; set; }
        public string ImageVisitante { get; set; }
        public string ImageDocumento { get; set; }
    }
}