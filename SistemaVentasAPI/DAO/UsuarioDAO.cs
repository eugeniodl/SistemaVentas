using Microsoft.Data.SqlClient;
using SistemaVentasAPI.Data;
using SistemaVentasAPI.Models;
using System.Data;

namespace SistemaVentasAPI.DAO
{
    public class UsuarioDAO
    {
        private readonly ConexionDB _conexion;

        public UsuarioDAO(ConexionDB conexion)
        {
            _conexion = conexion;
        }

        public async Task<Usuario?> ValidarUsuarioAsync(string nombre, string contrasena)
        {
            using var conn = _conexion.ObtenerConexion();
            await conn.OpenAsync();

            using var cmd = new SqlCommand(Procedimientos.SP_VALIDAR_USUARIO, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@NombreUsuario", nombre);
            cmd.Parameters.AddWithValue("@Contrasena", contrasena);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Usuario
                {
                    Id = Convert.ToInt32(reader["IdUsuario"]),
                    NombreUsuario = reader["NombreUsuario"].ToString()!,
                    Rol = reader["NombreRol"].ToString()!
                };
            }

            return null;
        }
    }
}
