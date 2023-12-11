using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DireccionPersona : BaseEntity
    {
        public string Direccion { get; set; }
        public int IdPersonafk { get; set; }
        public Persona Persona { get; set; }
        public int IdTipoDireccionfk { get; set; }
        public TipoDireccion TipoDireccion { get; set; }
        
    }
}