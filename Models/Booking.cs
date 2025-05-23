using System.ComponentModel.DataAnnotations.Schema;

public class Booking
{
    public int Id { get; set; }

    [Column(TypeName = "TEXT")]
    public string CustomerName { get; set; } = null!;

    public int SeanceId { get; set; }

    public Seance Seance { get; set; } = null!;
}
