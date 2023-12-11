using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProgramacionDto
    {
        public int Id { get; set; }
        public int IdContratofk { get; set; }
        public int IdTurnofk { get; set; }
        public int IdEmpleadofk { get; set; }
    }
}