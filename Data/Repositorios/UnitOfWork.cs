using Core.interfaces;

namespace Data
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly PuntoVentaContex _context;

        public UnitOfWork(PuntoVentaContex context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
            => _context.SaveChangesAsync(ct);
    }
}
