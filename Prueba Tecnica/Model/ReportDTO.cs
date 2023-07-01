using Core.Entities;

namespace Prueba_Tecnica.Model
{
    public class ReportDTO
    {
        public decimal Netavailability { get; set; }
        public decimal TotalCommittedInventory { get; set; }
        public UnitsByLocationModel UnitsByLocation { get; set; }
    }
}
