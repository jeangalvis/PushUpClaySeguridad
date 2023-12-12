using Domain.Entities;
using Domain.Views;

namespace Domain.Interfaces
{
    public interface IContrato : IGeneric<Contrato>
    {
        Task<IEnumerable<ContratosActivos>> ObtenerContratosActivos();
    }
}