using Microsoft.Data.SqlClient;
using SistemaVentasAPI.DAO.Interfaces;
using SistemaVentasAPI.Data;

namespace SistemaVentasAPI.DAO
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly ConexionDB _conexion;

        public RepositoryBase(ConexionDB conexion)
        {
            _conexion = conexion;
        }

        // Métodos abstractos que deben implementarse en las clases derivadas
        public abstract Task<IEnumerable<T>> GetAllAsync();
        public abstract Task<T?> GetByIdAsync(int id);
        public abstract Task<int> CreateAsync(T entity);
        public abstract Task<bool> UpdateAsync(T entity);
        public abstract Task<bool> DeleteAsync(int id);

        // Método helper opcional para abrir conexión
        protected async Task<SqlConnection> GetOpenConnectionAsync()
        {
            var cn = _conexion.ObtenerConexion();
            await cn.OpenAsync();
            return cn;
        }
    }
}

