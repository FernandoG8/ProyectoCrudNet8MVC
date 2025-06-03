using System;
using System.Collections.Generic;

namespace ProyectoDatabaseFirst.Models;

public partial class Ciudad
{
    public int IdCiudad { get; set; }

    public string NombreCiudad { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Habitantes { get; set; }

    public decimal Altura { get; set; }

    public decimal Latitud { get; set; }

    public decimal Longitud { get; set; }

    public int PaisId { get; set; }

    public virtual Pai Pais { get; set; } = null!;
}
