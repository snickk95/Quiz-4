using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Quiz4_Nick_Harrison.Entities;

public partial class MeasurementPosition
{
    [Key]
    public string MeasurementPositionId { get; set; } = null!;

    public string? Name { get; set; }

    [InverseProperty("MeasurementPosition")]
    public virtual ICollection<Bpmeasurement> Bpmeasurements { get; set; } = new List<Bpmeasurement>();
}
