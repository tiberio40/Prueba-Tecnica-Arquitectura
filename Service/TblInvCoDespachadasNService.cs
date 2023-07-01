using Core.Interfaces;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TblInvCoDespachadasNService : ITblInvCoDespachadasNService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TblInvCoDespachadasNService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
