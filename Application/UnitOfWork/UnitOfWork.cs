using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PruebaContext context;
        private ICategoriaPersona _categoriaPersona;
        private ICiudad _ciudad;
        private IContactoPersona _contactoPersona;
        private IContrato _contrato;
        private IDepartamento _departamento;
        private IDireccionPersona _direccionPersona;
        private IEstado _estado;
        private IPais _pais;
        private IPersona _persona;
        private IProgramacion _programacion;
        private ITipoContacto _tipoContacto;
        private ITipoDireccion _tipoDireccion;
        private ITipoPersona _tipoPersona;
        private ITurno _turno;
        private IUser _user;
        private IRol _rol;

        public UnitOfWork(PruebaContext _context)
        {
            context = _context;
        }

        public ICategoriaPersona CategoriaPersonas {
            get{
                if(_categoriaPersona == null){
                    _categoriaPersona = new CategoriaPersonaRepository(context);
                }
                return _categoriaPersona;
            }
        }

        public ICiudad Ciudades {
            get{
                if(_ciudad == null){
                    _ciudad = new CiudadRepository(context);
                }
                return _ciudad;
            }
        }
        public IContactoPersona ContactoPersonas {
            get{
                if(_contactoPersona == null){
                    _contactoPersona = new ContactoPersonaRepository(context);
                }
                return _contactoPersona;
            }
        }
        public IContrato Contratos {
            get{
                if(_contrato == null){
                    _contrato = new ContratoRepository(context);
                }
                return _contrato;
            }
        }
        public IDepartamento Departamentos {
            get{
                if(_departamento == null){
                    _departamento = new DepartamentoRepository(context);
                }
                return _departamento;
            }
        }
        public IDireccionPersona DireccionPersonas {
            get{
                if(_direccionPersona == null){
                    _direccionPersona = new DireccionPersonaRepository(context);
                }
                return _direccionPersona;
            }
        }
        public IEstado Estados {
            get{
                if(_estado == null){
                    _estado = new EstadoRepository(context);
                }
                return _estado;
            }
        }
        public IPais Paises {
            get{
                if(_pais == null){
                    _pais = new PaisRepository(context);
                }
                return _pais;
            }
        }
        public IPersona Personas {
            get{
                if(_persona == null){
                    _persona = new PersonaRepository(context);
                }
                return _persona;
            }
        }
        public IProgramacion Programacions {
            get{
                if(_programacion == null){
                    _programacion = new ProgramacionRepository(context);
                }
                return _programacion;
            }
        }
        public ITipoContacto TipoContactos {
            get{
                if(_tipoContacto == null){
                    _tipoContacto = new TipoContactoRepository(context);
                }
                return _tipoContacto;
            }
        }
        public ITipoDireccion TipoDirecciones {
            get{
                if(_tipoDireccion == null){
                    _tipoDireccion = new TipoDireccionRepository(context);
                }
                return _tipoDireccion;
            }
        }
        public ITipoPersona TipoPersonas {
            get{
                if(_tipoPersona == null){
                    _tipoPersona = new TipoPersonaRepository(context);
                }
                return _tipoPersona;
            }
        }
        public ITurno Turnos {
            get{
                if(_turno == null){
                    _turno = new TurnoRepository(context);
                }
                return _turno;
            }
        }
        public IUser Users {
            get{
                if(_user == null){
                    _user = new UserRepository(context);
                }
                return _user;
            }
        }
        public IRol Rols {
            get{
                if(_rol == null){
                    _rol = new RolRepository(context);
                }
                return _rol;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}