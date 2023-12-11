using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ContactoPersonaConfiguration : IEntityTypeConfiguration<ContactoPersona>
{
    public void Configure(EntityTypeBuilder<ContactoPersona> builder)
    {
        builder.ToTable("contacto_persona");
        builder.Property(p => p.Descripcion).IsRequired();

        builder.HasOne(p => p.Persona)
            .WithMany(p => p.ContactoPersonas)
            .HasForeignKey(p => p.IdPersonafk);

        builder.HasOne(p => p.TipoContacto)
            .WithMany(p => p.ContactoPersonas)
            .HasForeignKey(p => p.IdTipoContactofk);
    }
}