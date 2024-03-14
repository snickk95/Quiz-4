using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quiz4_Nick_Harrison.Entities;

public partial class BpmeasurementsContext : DbContext
{
    public BpmeasurementsContext()
    {
    }

    public BpmeasurementsContext(DbContextOptions<BpmeasurementsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bpmeasurement> Bpmeasurements { get; set; }

    public virtual DbSet<MeasurementPosition> MeasurementPositions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=Quiz4DB8476855");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bpmeasurement>(entity =>
        {
            entity.HasOne(d => d.MeasurementPosition).WithMany(p => p.Bpmeasurements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MeasurementPosition");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
