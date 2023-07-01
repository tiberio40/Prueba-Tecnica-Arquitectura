using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TblInvUbicacionesNRepository : BaseRepository<TblInvUbicacionesN>, ITblInvUbicacionesNRepository
    {
        public TblInvUbicacionesNRepository(InventarioBodegaContext context) : base(context)
        {

        }
    }
}
