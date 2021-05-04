using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABCTIENDA
{
    public partial class Menu : Form
    {
        ConexionSQLServer ObjC = new ConexionSQLServer("server=LAPTOP-65JMS50O\\SQLEXPRESS01;database=basetienda;integrated security=true");
        public Menu()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAltas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aqui puedes dar de Alta un Registro.", "Mensage:");
            Form Form = new Form1();
            Form.Show();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aqui Puedes Consultar Todos los Registros.", "Mensage:");
            if (ObjC.Conexion.State != ConnectionState.Closed)
            {
                ObjC.CerrarConexion();
            }
            Mostrar forma = new Mostrar(ObjC);
            forma.ShowDialog();
        }

        private void btnBajas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aqui Puedes Consultar Registros por Codigo  y Eliminarlos.","Mensage:");
            if (ObjC.Conexion.State != ConnectionState.Closed)
            {
                ObjC.CerrarConexion();
            }
            Bajas forma = new Bajas(ObjC);
            forma.ShowDialog();
        }

        private void btnCambios_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Proximamente.","Aviso:");
            btnCambios.Enabled = false;
        }
    }
}
