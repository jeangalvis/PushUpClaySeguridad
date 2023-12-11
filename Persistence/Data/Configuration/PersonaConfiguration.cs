using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");
        builder.Property(p => p.IdPersona).IsRequired();
        builder.Property(p => p.Nombre).IsRequired();
        builder.Property(p => p.DateReg).IsRequired();
        builder.HasOne(p => p.TipoPersona)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdTipoPersonafk);
        
        builder.HasOne(p => p.CategoriaPersona)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdCategoriaPersonafk);

        builder.HasOne(p => p.Ciudad)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdCiudadfk);
    }
}