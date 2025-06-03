using System;
using System.Collections.Generic;

namespace ProyectoDatabaseFirst.Models;

public partial class Continente
{
    public int IdContinente { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Pai> Pais { get; set; } = new List<Pai>();
}
