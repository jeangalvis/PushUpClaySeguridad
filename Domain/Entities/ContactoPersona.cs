using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContactoPersona : BaseEntity
    {
        public string Descripcion { get; set; }
        public int IdPersonafk { get; set; }
        public Persona Persona { get; set; }
        public int IdTipoContactofk { get; set; }
        public TipoContacto TipoContacto { get; set; }
    }
}