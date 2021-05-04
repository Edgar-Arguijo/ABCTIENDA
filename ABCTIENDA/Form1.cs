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
    public partial class Form1 : Form
    {
        ConexionSQLServer ObjC = new ConexionSQLServer("server=LAPTOP-65JMS50O\\SQLEXPRESS01;database=basetienda;integrated security=true");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ObjC.AbrirConexion();
                string descripcion = txtDesArt.Text;
                string precio = txtPrecio.Text;
                string cadena = "insert into Articulos (descripcion,precio) values('" + descripcion + "'," + precio + ")";
                SqlCommand comando = new SqlCommand(cadena,ObjC.Conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Los Datos se Guardaron Corrrectamente.", "Mensage:");
                txtDesArt.Text = "";
                txtPrecio.Text = "";
            }
            catch (Exception d)
            {
                MessageBox.Show(d.Message);
            }
            if (ObjC.Conexion.State==ConnectionState.Open)
            {
                ObjC.CerrarConexion();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
