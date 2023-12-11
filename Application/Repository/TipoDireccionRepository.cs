using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class TipoDireccionRepository : GenericRepository<TipoDireccion>, ITipoDireccion
{
    private readonly PruebaContext _context;
    public TipoDireccionRepository(PruebaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<TipoDireccion> GetByIdAsync(int id)
    {
        return await _context.TipoDirecciones
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<TipoDireccion>> GetAllAsync()
    {
        return await _context.TipoDirecciones.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<TipoDireccion> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.TipoDirecciones as IQueryable<TipoDireccion>;
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