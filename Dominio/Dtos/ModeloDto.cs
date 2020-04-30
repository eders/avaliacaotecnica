using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Dtos
{
    public class ModeloDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ano { get; set; }
        public int MarcaId { get; set; }
        public string NomeMarca { get; set; }
    }
}
