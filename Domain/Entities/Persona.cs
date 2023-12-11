using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona : BaseEntity
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public DateOnly DateReg { get; set; }
        public int IdTipoPersonafk { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public int IdCategoriaPersonafk { get; set; }
        public CategoriaPersona CategoriaPersona { get; set; }
        public int IdCiudadfk { get; set; }
        public Ciudad Ciudad { get; set; }
        public ICollection<ContactoPersona> ContactoPersonas { get; set; }
        public ICollection<DireccionPersona> DireccionPersonas { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
        public ICollection<Programacion> Programacions { get; set; }
    }
}
