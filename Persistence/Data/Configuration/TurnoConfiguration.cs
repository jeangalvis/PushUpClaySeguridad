using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class TurnoConfiguration : IEntityTypeConfiguration<Turno>
{
    public void Configure(EntityTypeBuilder<Turno> builder)
    {
        builder.ToTable("turno");
        builder.Property(p => p.NombreTurno).IsRequired();
        builder.Property(p => p.HoraTurnoI).IsRequired();
        builder.Property(p => p.HoraTurnoF).IsRequired();
    }
}