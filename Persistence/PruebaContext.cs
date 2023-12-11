using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class PruebaContext : DbContext
    {
        public PruebaContext(DbContextOptions<PruebaContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<CategoriaPersona> CategoriaPersonas { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<ContactoPersona> ContactoPersonas { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<DireccionPersona> DireccionPersonas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Programacion> Programacions { get; set; }
        public DbSet<TipoContacto> TipoContactos { get; set; }
        public DbSet<TipoDireccion> TipoDirecciones { get; set; }
        public DbSet<TipoPersona> TipoPersonas { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<UserRol> UserRols { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}




