using SistemaVentasAPI.DAO.Interfaces;
using SistemaVentasAPI.Services.Interfaces;

namespace SistemaVentasAPI.Services
{
    public abstract class ServiceBase<T> : IService<T> where T : class
    {
        protected readonly IRepository<T> _repository;

        public ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<(bool ok, string error)> CrearAsync(T entity)
        {
            var id = await _repository.CreateAsync(entity);
            return id > 0 ? (true, string.Empty) : (false, "No se pudo insertar el registro.");
        }

        public virtual async Task<IEnumerable<T>> ListarAsync()
            => await _repository.GetAllAsync();

        public virtual async Task<T?> ObtenerPorIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        public virtual async Task<(bool ok, string error)> ActualizarAsync(T entity)
        {
            var ok = await _repository.UpdateAsync(entity);
            return ok ? (true, string.Empty) : (false, "No se pudo actualizar el registro.");
        }

        public virtual async Task<(bool ok, string error)> EliminarAsync(int id)
        {
            var ok = await _repository.DeleteAsync(id);
            return ok ? (true, string.Empty) : (false, "No se pudo eliminar el registro.");
        }
    }
}
