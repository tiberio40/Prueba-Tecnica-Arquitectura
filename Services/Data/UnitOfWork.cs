using Core.Interfaces;
using Core.Interfaces.Repositories;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventarioBodegaContext _context;
        private TblInvCoDespachadasNRepository _tblInvCoDespachadasNRepository;
        private TblInvNpComprometidasNRepository _tblInvNpComprometidasNRepository;
        private TblInvUbicacionesNRepository _tblInvUbicacionesNRepository;

        public UnitOfWork(InventarioBodegaContext context) { 
            _context = context;
        }

        public ITblInvCoDespachadasNRepository tblInvCoDespachadasNRepository => _tblInvCoDespachadasNRepository ??= new TblInvCoDespachadasNRepository(_context);

        public ITblInvNpComprometidasNRepository tblInvNpComprometidasNRepository => _tblInvNpComprometidasNRepository ??= new TblInvNpComprometidasNRepository(_context);

        public ITblInvUbicacionesNRepository tblInvUbicacionesNRepository => _tblInvUbicacionesNRepository ??= new TblInvUbicacionesNRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
