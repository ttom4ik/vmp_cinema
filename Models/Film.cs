using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Film
{
    public int Id { get; set; }

    [Column(TypeName = "TEXT")]
    public string Title { get; set; } = null!;

    [Column(TypeName = "TEXT")]
    public string Genre { get; set; } = null!;

    public ICollection<Seance> Seances { get; set; } = new List<Seance>();
}
