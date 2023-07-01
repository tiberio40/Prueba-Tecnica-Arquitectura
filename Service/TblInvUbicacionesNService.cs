using Core.Interfaces.Services;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using System.Linq.Expressions;

namespace Service
{
    public class TblInvUbicacionesNService : ITblInvUbicacionesNService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TblInvUbicacionesNService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TblInvUbicacionesN>> GetAll()
        {
            return await _unitOfWork.tblInvUbicacionesNRepository.GetAllAsync();
        }

        public async Task<IEnumerable<WareHouseModel>> GetAllWareHouses()
        {
            var warehouse = await _unitOfWork.tblInvUbicacionesNRepository.GetAllAsync();
            var result = warehouse.GroupBy(x => new { x.SkuId, x.Whse }).Select(x => new WareHouseModel { SkuId = x.Key.SkuId, Whse = x.Key.Whse }).OrderBy(x => x.Whse);

            return result;
        }

        public async Task<decimal> GetNetavailability(SearchModel values) {
            values.SkuId = values.SkuId.ToUpper();
            values.WareHouseName = values.WareHouseName.ToUpper();

            var ubicationList =  await _unitOfWork.tblInvUbicacionesNRepository.GetAllAsync();
            var comprometidasList = await _unitOfWork.tblInvNpComprometidasNRepository.GetAllAsync();
            var despachadasList = await _unitOfWork.tblInvCoDespachadasNRepository.GetAllAsync();

            if (!String.IsNullOrEmpty(values.SkuId)) {
                ubicationList = ubicationList.Where(x => x.SkuId == values.SkuId);
                comprometidasList = comprometidasList.Where(x => x.SkuId == values.SkuId);
                despachadasList = despachadasList.Where(x => x.Whse == ubicationList.FirstOrDefault().Whse);
            }

            if (!String.IsNullOrEmpty(values.WareHouseName))
            {
                ubicationList = ubicationList.Where(x => x.Whse == values.WareHouseName);
                comprometidasList = comprometidasList.Where(x => x.SkuId == ubicationList.FirstOrDefault().SkuId);
                despachadasList = despachadasList.Where(x => x.Whse == values.WareHouseName);
            }


            var ubicationCount = ubicationList.Sum(x => x.OnHandQty) ?? 0;            
            var comprometidasCount = comprometidasList.Sum(x => x.QtyPend) ?? 0;            
            var despachadasCount = despachadasList.Sum(x => x.CoDesp) ?? 0;

            return ubicationCount - comprometidasCount - despachadasCount;
        }

        public async Task<decimal> GetTotalCommittedInventory(SearchModel values) {
            values.SkuId = values.SkuId.ToUpper();
            values.WareHouseName = values.WareHouseName.ToUpper();

            var ubicationList = await _unitOfWork.tblInvUbicacionesNRepository.GetAllAsync();
            var comprometidasList = await _unitOfWork.tblInvNpComprometidasNRepository.GetAllAsync();
            var despachadasList = await _unitOfWork.tblInvCoDespachadasNRepository.GetAllAsync();

            if (!String.IsNullOrEmpty(values.SkuId))
            {
                ubicationList = ubicationList.Where(x => x.SkuId == values.SkuId);
                comprometidasList = comprometidasList.Where(x => x.SkuId == values.SkuId);
                despachadasList = despachadasList.Where(x => x.Whse == ubicationList.FirstOrDefault().Whse);
            }

            if (!String.IsNullOrEmpty(values.WareHouseName))
            {
                ubicationList = ubicationList.Where(x => x.Whse == values.WareHouseName);
                comprometidasList = comprometidasList.Where(x => x.SkuId == ubicationList.FirstOrDefault().SkuId);
                despachadasList = despachadasList.Where(x => x.Whse == values.WareHouseName);
            }

            var comprometidasCount = comprometidasList.Sum(x => x.QtyPend) ?? 0;
            var despachadasCount = despachadasList.Sum(x => x.CoDesp) ?? 0;

            return comprometidasCount + despachadasCount;
        }

        public async Task<UnitsByLocationModel> GetUnitsByLocation(SearchModel values)
        {
            values.SkuId = values.SkuId.ToUpper();
            values.WareHouseName = values.WareHouseName.ToUpper();

            decimal active = 0, reserve = 0, notStored = 0;


            var ubicationList = await _unitOfWork.tblInvUbicacionesNRepository.GetAllAsync();


            if (!String.IsNullOrEmpty(values.SkuId))
            {
                ubicationList = ubicationList.Where(x => x.SkuId == values.SkuId);
            }

            if (!String.IsNullOrEmpty(values.WareHouseName))
            {
                ubicationList = ubicationList.Where(x => x.Whse == values.WareHouseName);
            }



            active = ubicationList.Where(x => x.PrdLvlChild == "ACTIVO").Sum(x => x.OnHandQty) ?? 0;
            reserve = ubicationList.Where(x => x.PrdLvlChild == "RESERVA").Sum(x => x.OnHandQty) ?? 0;
            notStored = ubicationList.Where(x => x.PrdLvlChild == "").Sum(x => x.OnHandQty) ?? 0;

            return new UnitsByLocationModel()
            {
                Active= active,
                Reserve= reserve,
                NotStored= notStored
            };
        }
    }
}
