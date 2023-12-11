using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoriaPersona : BaseEntity
    {
        public string NombreCat { get; set; }
        public ICollection<Persona> Personas { get; set; }
    }
}