using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contrato : BaseEntity
    {
        public int IdClientefk { get; set; }
        public Persona Persona { get; set; }
        public DateOnly FechaContrato { get; set; }
        public int IdEmpleadofk { get; set; }
        public DateOnly FechaFin { get; set; }
        public int IdEstadofk { get; set; }
        public Estado Estado { get; set; }
        public ICollection<Programacion> Programacions { get; set; }
    }
}