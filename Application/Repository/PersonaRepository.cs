using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly PruebaContext _context;
    public PersonaRepository(PruebaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Persona> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Personas as IQueryable<Persona>;
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

    public async Task<IEnumerable<Persona>> ObtenerTodosLosEmpleados(){
        return await _context.Personas
                                    .Include(p => p.TipoPersona)
                                    .Where(p => p.TipoPersona.Descripcion.ToLower() == "empleado")
                                    .ToListAsync();
    }

    public async Task<IEnumerable<Persona>> ObtenerEmpleadosVigilantes(){
                return await _context.Personas
                                    .Include(p => p.TipoPersona)
                                    .Include(p => p.CategoriaPersona)
                                    .Where(p => p.TipoPersona.Descripcion.ToLower() == "empleado" && p.CategoriaPersona.NombreCat.ToLower() == "vigilante")
                                    .ToListAsync();
    }
    public async Task<IEnumerable<Persona>> ObtenerNumeroContactoVigilante(){
        return await _context.Personas
                                .Include(p => p.TipoPersona)
                                .Include(p => p.CategoriaPersona)
                                .Include(p => p.ContactoPersonas)
                                .Where(p => p.TipoPersona.Descripcion.ToLower() == "empleado" && p.CategoriaPersona.NombreCat.ToLower() == "vigilante" && p.ContactoPersonas.Any(p => p.IdPersonafk == p.Id))
                                .ToListAsync();
    }

    public async Task<IEnumerable<Persona>> ObtenerClientesBucaramanga(){
        return await _context.Personas
                                    .Include(p => p.TipoPersona)
                                    .Include(p => p.Ciudad)
                                    .Where(p => p.TipoPersona.Descripcion.ToLower() == "cliente" && p.Ciudad.NombreCiudad.ToLower() == "bucaramanga")
                                    .ToListAsync();
    }
    public async Task<IEnumerable<Persona>> ObtenerEmpleadosGironPiedecuesta(){
        return await _context.Personas
                                .Include(p => p.TipoPersona)
                                .Include(p => p.DireccionPersonas)
                                .Where(p => p.TipoPersona.Descripcion.ToLower() == "empleado" && p.DireccionPersonas.Any(p => p.Direccion.ToLower().Contains("giron") || p.Direccion.ToLower().Contains("piedecuesta")))
                                .ToListAsync();
    }
    public async Task<IEnumerable<Persona>> ObtenerClientes5AnyosAntiguedad(){
        DateTime fechaActual = DateTime.Now;
        return await _context.Personas
                                    .Include(p => p.Contratos)
                                    .Where(p => p.Contratos.Any(p => (fechaActual.Year - p.FechaContrato.Year) > 5))
                                    .ToListAsync();
    }
}