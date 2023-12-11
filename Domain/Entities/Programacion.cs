using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Programacion : BaseEntity
    {
        public int IdContratofk { get; set; }
        public Contrato Contrato { get; set; }
        public int IdTurnofk { get; set; }
        public Turno Turno { get; set; }
        public int IdEmpleadofk { get; set; }
        public Persona Persona { get; set; }
    }
}