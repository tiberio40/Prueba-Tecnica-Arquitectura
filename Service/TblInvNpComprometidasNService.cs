using Core.Interfaces.Services;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Service
{
    public class TblInvNpComprometidasNService : ITblInvNpComprometidasNService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TblInvNpComprometidasNService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TblInvNpComprometidasN>> GetAll()
        {
            return await _unitOfWork.tblInvNpComprometidasNRepository.GetAllAsync();
        }
    }
}
