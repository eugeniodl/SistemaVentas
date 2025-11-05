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
            using var cn = _conexion.ObtenerConexion();
            await cn.OpenAsync();

            using var cmd = new SqlCommand(Procedimientos.SP_VALIDAR_USUARIO, cn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@NombreUsuario", nombre);
            cmd.Parameters.AddWithValue("@Contrasena", contrasena);

            using var dr = await cmd.ExecuteReaderAsync();
            if (await dr.ReadAsync())
            {
                return new Usuario
                {
                    Id = Convert.ToInt32(dr["IdUsuario"]),
                    NombreUsuario = dr["NombreUsuario"].ToString()!,
                    Rol = dr["NombreRol"].ToString()!
                };
            }

            return null;
        }
    }
}
