using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class TblInvCoDespachadasN
{
    public int IdCoDespachadas { get; set; }

    public string Whse { get; set; } = null!;

    public string ItemName { get; set; } = null!;

    public decimal? CoDesp { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public decimal? Number1 { get; set; }

    public decimal? Number2 { get; set; }

    public string? Vchar1 { get; set; }

    public string? Vchar2 { get; set; }
}
