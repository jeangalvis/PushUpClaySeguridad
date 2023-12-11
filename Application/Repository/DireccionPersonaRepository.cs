using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class DireccionPersonaRepository : GenericRepository<DireccionPersona>, IDireccionPersona
{
    private readonly PruebaContext _context;
    public DireccionPersonaRepository(PruebaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<DireccionPersona> GetByIdAsync(int id)
    {
        return await _context.DireccionPersonas
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<DireccionPersona>> GetAllAsync()
    {
        return await _context.DireccionPersonas.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<DireccionPersona> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.DireccionPersonas as IQueryable<DireccionPersona>;
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
}