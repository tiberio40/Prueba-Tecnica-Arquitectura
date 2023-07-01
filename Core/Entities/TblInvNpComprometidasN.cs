using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class TblInvNpComprometidasN
{
    public int IdNpComprometidas { get; set; }

    public string Sticker { get; set; } = null!;

    public string IdAlmEnt { get; set; } = null!;

    public decimal OrgLvlChild { get; set; }

    public decimal IdEstado { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public decimal? QtyPend { get; set; }

    public string? SkuId { get; set; }

    public decimal? Number1 { get; set; }

    public decimal? Number2 { get; set; }

    public string? Vchar1 { get; set; }

    public string? Vchar2 { get; set; }
}
