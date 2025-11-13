using Microsoft.Data.SqlClient;
using SistemaVentasAPI.DAO.Interfaces;
using SistemaVentasAPI.Data;
using SistemaVentasAPI.Dto;
using SistemaVentasAPI.Models;
using System.Data;

namespace SistemaVentasAPI.DAO
{
    public class ClienteDAO : RepositoryBase<Cliente>, IRepository<Cliente>
    {
        public ClienteDAO(ConexionDB conexion) : base(conexion) { }

        public override async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            var lista = new List<Cliente>();

            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_LISTAR_CLIENTES, cn)
            { CommandType = CommandType.StoredProcedure };

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var c = new Cliente
                {
                    IdCliente = Convert.ToInt32(reader["id_cliente"]),
                    PNombre = reader["p_nombre"].ToString() ?? "",
                    SNombre = reader["s_nombre"].ToString() ?? "",
                    PApellido = reader["p_apellido"].ToString() ?? "",
                    SApellido = reader["s_apellido"].ToString() ?? "",
                    Correo = reader["correo"].ToString() ?? "",
                    Telefono = reader["telefono"] == DBNull.Value ? null : reader["telefono"].ToString(),
                };
                if (reader.GetSchemaTable()?.Columns.Contains("fecha_registro") == true && reader["fecha_registro"] != DBNull.Value)
                    c.FechaRegistro = Convert.ToDateTime(reader["fecha_registro"]);
                lista.Add(c);
            }

            return lista;
        }

        public override async Task<Cliente?> GetByIdAsync(int id)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_OBTENER_CLIENTE_POR_ID, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@id_cliente", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var cliente = new Cliente
                {
                    IdCliente = Convert.ToInt32(reader["id_cliente"]),
                    PNombre = reader["p_nombre"].ToString() ?? "",
                    SNombre = reader["s_nombre"] == DBNull.Value ? null : reader["s_nombre"].ToString(),
                    PApellido = reader["p_apellido"].ToString() ?? "",
                    SApellido = reader["s_apellido"] == DBNull.Value ? null : reader["s_apellido"].ToString(),
                    Correo = reader["correo"].ToString() ?? "",
                    Telefono = reader["telefono"] == DBNull.Value ? null : reader["telefono"].ToString(),
                };

                if (reader.GetSchemaTable()?.Columns.Contains("fecha_registro") == true && reader["fecha_registro"] != DBNull.Value)
                    cliente.FechaRegistro = Convert.ToDateTime(reader["fecha_registro"]);

                return cliente;
            }

            return null; // Cliente no encontrado
        }

        public override async Task<int> CreateAsync(Cliente c)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_INSERTAR_CLIENTE, cn)
            { CommandType = CommandType.StoredProcedure };


            cmd.Parameters.AddWithValue("@p_nombre", c.PNombre);
            cmd.Parameters.AddWithValue("@s_nombre", (object?)c.SNombre ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@p_apellido", c.PApellido);
            cmd.Parameters.AddWithValue("@s_apellido", (object?)c.SApellido ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@correo", c.Correo);
            cmd.Parameters.AddWithValue("@telefono", (object?)c.Telefono ?? DBNull.Value);

            // Si tu stored procedure devuelve el ID nuevo, usa ExecuteScalarAsync
            var result = await cmd.ExecuteScalarAsync();

            // Asignar el ID a la entidad Cliente
            if (result != null)
            {
                c.IdCliente = Convert.ToInt32(result);
                return c.IdCliente;
            }

            return 0;
        }

        public override async Task<bool> UpdateAsync(Cliente c)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_ACTUALIZAR_CLIENTE, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@id_cliente", c.IdCliente);
            cmd.Parameters.AddWithValue("@p_nombre", c.PNombre);
            cmd.Parameters.AddWithValue("@s_nombre", (object?)c.SNombre ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@p_apellido", c.PApellido);
            cmd.Parameters.AddWithValue("@s_apellido", (object?)c.SApellido ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@correo", c.Correo);
            cmd.Parameters.AddWithValue("@telefono", (object?)c.Telefono ?? DBNull.Value);

            var result = await cmd.ExecuteScalarAsync();
            return result != null && Convert.ToInt32(result) == 1;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_ELIMINAR_CLIENTE, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@id_cliente", id);

            var result = await cmd.ExecuteScalarAsync();
            return result != null && Convert.ToInt32(result) == 1;
        }
    }
}
