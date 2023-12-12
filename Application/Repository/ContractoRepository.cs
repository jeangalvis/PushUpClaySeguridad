using Domain.Entities;
using Domain.Interfaces;
using Domain.Views;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class ContratoRepository : GenericRepository<Contrato>, IContrato
{
    private readonly PruebaContext _context;
    public ContratoRepository(PruebaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Contrato> GetByIdAsync(int id)
    {
        return await _context.Contratos
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Contrato>> GetAllAsync()
    {
        return await _context.Contratos.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Contrato> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Contratos as IQueryable<Contrato>;
        if (!string.IsNullOrEmpty(search))
        {
            // query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        return (totalRegistros, registros);
    }
    public async Task<IEnumerable<ContratosActivos>> ObtenerContratosActivos(){
            return await _context.Contratos
                                    .Include(p => p.Estado)
                                    .Include(p => p.Persona)
                                    .Where(p => p.Estado.Descripcion.ToLower() == "activo")
                                    .Select(p => new ContratosActivos
                                    {
                                        Id = p.Id,
                                        NombreCliente = p.Persona.Id == p.IdClientefk ? p.Persona.Nombre : string.Empty,
                                        NombreEmpleado = p.Persona.Id == p.IdEmpleadofk ? p.Persona.Nombre : string.Empty,
                                    })
                                    .ToListAsync();
    }
}