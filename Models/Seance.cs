using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Seance
{
    public int Id { get; set; }

    public DateTime StartTime { get; set; }

    // Foreign key
    public int FilmId { get; set; }

    // Navigation property
    [ValidateNever]
    public Film Film { get; set; } = null!;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
