using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class TblInvUbicacionesN
{
    public int IdUbicacion { get; set; }

    public decimal IdItem { get; set; }

    public string Whse { get; set; } = null!;

    public string SkuId { get; set; } = null!;

    public string PrdLvlChild { get; set; } = null!;

    public string? Ubicacion { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public decimal? OnHandQty { get; set; }

    public string? WmsLocnId { get; set; }

    public decimal? Number1 { get; set; }

    public decimal? Number2 { get; set; }

    public string? Vchar1 { get; set; }

    public string? Vchar2 { get; set; }
}
