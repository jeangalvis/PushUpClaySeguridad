using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class ProgramacionRepository : GenericRepository<Programacion>, IProgramacion
{
    private readonly PruebaContext _context;
    public ProgramacionRepository(PruebaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Programacion> GetByIdAsync(int id)
    {
        return await _context.Programacions
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Programacion>> GetAllAsync()
    {
        return await _context.Programacions.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Programacion> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Programacions as IQueryable<Programacion>;
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