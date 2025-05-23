using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Booking
{
    public int Id { get; set; }

    [Column(TypeName = "TEXT")]
    public string CustomerName { get; set; } = null!;

    public int SeanceId { get; set; }

    [ValidateNever]
    public Seance Seance { get; set; } = null!;
}
