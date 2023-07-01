using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ITblInvUbicacionesNService
    {
        Task<IEnumerable<TblInvUbicacionesN>> GetAll();

        Task<IEnumerable<WareHouseModel>> GetAllWareHouses();

        Task<decimal> GetNetavailability(SearchModel values);

        Task<decimal> GetTotalCommittedInventory(SearchModel values);

        Task<UnitsByLocationModel> GetUnitsByLocation(SearchModel values);
    }
}
