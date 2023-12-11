using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class DireccionPersonaConfiguration : IEntityTypeConfiguration<DireccionPersona>
{
    public void Configure(EntityTypeBuilder<DireccionPersona> builder)
    {
        builder.ToTable("direccion_persona");
        builder.Property(p => p.Direccion).IsRequired();
        builder.HasOne(p => p.Persona)
           .WithMany(p => p.DireccionPersonas)
           .HasForeignKey(p => p.IdPersonafk);
        builder.HasOne(p => p.TipoDireccion)
            .WithMany(p => p.DireccionPersonas)
            .HasForeignKey(p => p.IdTipoDireccionfk);
    }
}