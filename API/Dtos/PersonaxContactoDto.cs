using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PersonaxContactoDto
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public DateOnly DateReg { get; set; }
        public int IdTipoPersonafk { get; set; }
        public int IdCategoriaPersonafk { get; set; }
        public int IdCiudadfk { get; set; }
        public List<ContactoPersonaDto> ContactoPersonas { get; set; }
    }
}