using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPersona : IGeneric<Persona>
    {
        Task<IEnumerable<Persona>> ObtenerTodosLosEmpleados();
        Task<IEnumerable<Persona>> ObtenerEmpleadosVigilantes();
        Task<IEnumerable<Persona>> ObtenerNumeroContactoVigilante();
        Task<IEnumerable<Persona>> ObtenerClientesBucaramanga();
        Task<IEnumerable<Persona>> ObtenerEmpleadosGironPiedecuesta();
        Task<IEnumerable<Persona>> ObtenerClientes5AnyosAntiguedad();
    }
}