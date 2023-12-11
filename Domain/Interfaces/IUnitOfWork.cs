namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoriaPersona CategoriaPersonas {get;}
        ICiudad Ciudades {get;}
        IContactoPersona ContactoPersonas {get;}
        IContrato Contratos {get;}
        IDepartamento Departamentos {get;}
        IDireccionPersona DireccionPersonas {get;}
        IEstado Estados {get;}
        IPais Paises {get;}
        IPersona Personas {get;}
        IProgramacion Programacions {get;}
        ITipoContacto TipoContactos {get;}
        ITipoPersona TipoPersonas {get;}
        ITipoDireccion TipoDirecciones {get;}
        ITurno Turnos {get;}
        IUser Users {get;}
        IRol Rols {get;}
        Task<int> SaveAsync();
    }
}