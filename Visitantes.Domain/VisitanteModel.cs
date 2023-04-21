using System;

namespace Visitantes.Domain
{
    public class VisitanteModel
    {
        public int Id { get; set; }
        public string CpfRg { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public DateTime Entrada { get; set; }
        public string ImageVisitante { get; set; }
        public string ImageDocumento { get; set; }
        public string Unidade { get; set; }
    }
}