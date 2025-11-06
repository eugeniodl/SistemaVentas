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

        public async Task<Usuario?> ValidarUsuarioAsync(string nombreUsuario, string contrasena)
        {
            using var conn = _conexion.ObtenerConexion();
            await conn.OpenAsync();

            using var cmd = new SqlCommand(Procedimientos.SP_VALIDAR_USUARIO, conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            
            cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
            cmd.Parameters.AddWithValue("@Contrasena", contrasena);

            using var resultado = await cmd.ExecuteReaderAsync();
            if (await resultado.ReadAsync())
            {
                return new Usuario
                {
                    IdUsuario = Convert.ToInt32(resultado["IdUsuario"]),
                    NombreUsuario = resultado["NombreUsuario"].ToString()!,
                    Rol = resultado["NombreRol"].ToString()!
                };
            }

            return null;
        }
    }
}
