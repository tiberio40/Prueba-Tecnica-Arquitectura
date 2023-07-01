using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITblInvCoDespachadasNRepository tblInvCoDespachadasNRepository { get; }
        ITblInvNpComprometidasNRepository tblInvNpComprometidasNRepository { get; }
        ITblInvUbicacionesNRepository tblInvUbicacionesNRepository { get; }        

        Task<int> CommitAsync();
    }
}
