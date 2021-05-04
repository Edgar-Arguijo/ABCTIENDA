using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;

namespace ABCTIENDA
{
    public class ConexionSQLServer
    {
        private SqlConnection conexion;
        public SqlConnection Conexion { get => conexion; set => conexion = value; }

        public ConexionSQLServer(string CadenaConexion)
        {
            conexion = new SqlConnection(CadenaConexion);
        }

        public void AbrirConexion()
        {
            conexion.Open();
        }

        public void CerrarConexion()
        {
            conexion.Close();
        }
    }
}
