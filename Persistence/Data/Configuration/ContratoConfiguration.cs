using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        builder.ToTable("contrato");
        builder.Property(p => p.FechaContrato).IsRequired();
        builder.Property(p => p.FechaFin).IsRequired();

        builder.HasOne(p => p.Persona)
            .WithMany(p => p.Contratos)
            .HasForeignKey(p => p.IdClientefk);

        builder.HasOne(p => p.Persona)
            .WithMany(p => p.Contratos)
            .HasForeignKey(p => p.IdEmpleadofk);

        builder.HasOne(p => p.Estado)
            .WithMany(p => p.Contratos)
            .HasForeignKey(p => p.IdEstadofk);
    }
}