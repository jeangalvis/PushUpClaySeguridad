using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
{
    public void Configure(EntityTypeBuilder<Programacion> builder)
    {
        builder.ToTable("programacion");
        builder.HasOne(p => p.Contrato)
            .WithMany(p => p.Programacions)
            .HasForeignKey(p => p.IdContratofk);
        
        builder.HasOne(p => p.Turno)
            .WithMany(p => p.Programacions)
            .HasForeignKey(p => p.IdTurnofk);

        builder.HasOne(p => p.Persona)
            .WithMany(p => p.Programacions)
            .HasForeignKey(p => p.IdEmpleadofk);
    }
}