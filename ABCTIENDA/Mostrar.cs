using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ABCTIENDA
{
    public partial class Mostrar : Form
    {
        ConexionSQLServer derivada;

        public Mostrar(ConexionSQLServer ObjC)
        {
            InitializeComponent();
            derivada = ObjC;
        }
        public Mostrar()
        {
            InitializeComponent();
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                derivada.AbrirConexion();
                string cadena = "select codigo, descripcion,precio from articulos";
                SqlCommand comando = new SqlCommand(cadena, derivada.Conexion);
                SqlDataReader registros = comando.ExecuteReader();

                while (registros.Read())
                {
                    txtMostrar.AppendText(registros["codigo"].ToString());
                    txtMostrar.AppendText(" - ");
                    txtMostrar.AppendText(registros["descripcion"].ToString());
                    txtMostrar.AppendText(" - $");
                    txtMostrar.AppendText(registros["precio"].ToString());
                    txtMostrar.AppendText(Environment.NewLine);

                }

                derivada.Conexion.Close();
            }
            catch (Exception d)
            {
                MessageBox.Show(d.Message);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
