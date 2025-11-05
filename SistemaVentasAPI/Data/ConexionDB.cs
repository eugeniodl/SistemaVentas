using Microsoft.Data.SqlClient;

namespace SistemaVentasAPI.Data
{
    public class ConexionDB
    {
        private readonly string _cadenaSQL;

        public ConexionDB(IConfiguration configuration)
        {
            _cadenaSQL = configuration.GetConnectionString("CadenaSQL")!;
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadenaSQL);
        }
    }
}
