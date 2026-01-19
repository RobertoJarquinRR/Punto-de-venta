using Core.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositorios
{
    public abstract class RepositorioBase<T> : IRepositorio<T>
        where T : class, IidentidaID
    {
        protected readonly PuntoVentaContex _context;
        protected readonly DbSet<T> _dbSet;

        protected RepositorioBase(PuntoVentaContex context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public Task<List<T>> GetAllAsync(CancellationToken ct = default)
            => _dbSet.AsNoTracking().ToListAsync(ct);

        public Task<T?> GetByIdAsync(int id, CancellationToken ct = default)
            => _dbSet.FindAsync(new object[] { id }, ct).AsTask();

        public async Task AddAsync(T entity, CancellationToken ct = default)
            => await _dbSet.AddAsync(entity, ct);

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var existing = await _dbSet.FindAsync(new object[] { id }, ct);
            if (existing != null)
                _dbSet.Remove(existing);
        }

        public async Task UpdateAsync(T entity, CancellationToken ct = default)
        {
            var existing = await _dbSet.FindAsync(new object[] { entity.Id }, ct);
            if (existing != null)
                MapearCambios(existing, entity);
        }

        protected abstract void MapearCambios(T existingEntity, T newEntity);
    }
}
