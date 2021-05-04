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
    public partial class Bajas : Form
    {
        ConexionSQLServer derivado;
        public Bajas(ConexionSQLServer ObjC)
        {
            InitializeComponent();
            derivado = ObjC;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                derivado.AbrirConexion();
                string cod = txtCodigo.Text;
                string cadena = "select descripcion,precio from Articulos where codigo=" + cod;
                SqlCommand comando = new SqlCommand(cadena, derivado.Conexion);
                SqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    lblDescripcion.Text = registro["descripcion"].ToString();
                    lblPrecio.Text = registro["precio"].ToString();
                }
                else
                {
                    MessageBox.Show("No existe un Articulo con el Codigo Ingresado", "Error:");
                }
            }
            catch (Exception d)
            {

                MessageBox.Show(d.Message);
            }
            derivado.CerrarConexion();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                derivado.AbrirConexion();
                string cod = txtCodigo.Text;
                string cadena = "delete from Articulos where Codigo=" + cod;
                SqlCommand comando = new SqlCommand(cadena, derivado.Conexion);
                int cant;
                cant = comando.ExecuteNonQuery();
                if (cant == 1)
                {
                    lblDescripcion.Text = "---------";
                    lblPrecio.Text = "---------";
                    MessageBox.Show("Se Borro el Registro.", "Mensaje:");
                }
                else
                {
                    MessageBox.Show("No Existe Articulo con el Codigo Ingresado.", "Error:");
                }
            }
            catch (Exception d)
            {

                MessageBox.Show(d.Message);
            }
            if (derivado.Conexion.State == ConnectionState.Open)
            {
                derivado.CerrarConexion();
            }
        }
    }
}
