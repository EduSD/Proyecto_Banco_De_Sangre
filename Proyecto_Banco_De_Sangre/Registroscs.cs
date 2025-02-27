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

namespace Proyecto_Banco_De_Sangre
{
    public partial class Registroscs : Form
    {
        DataTable dt = new DataTable();
        int id = 2;
        string conexionString = "Server=DESKTOP-NC4SAIF\\SQÑEXPRESS;Database=banco_sangre;Trusted_Connection=True;";

        public Registroscs()
        {
            InitializeComponent();
          
        }
        private void CargarDatos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                string query = "SELECT * FROM Registros";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conexion))
                {
                    da.Fill(dt);
                }
            }

            dtw_Registro.DataSource = dt;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Registroscs_Load(object sender, EventArgs e)
        {/*
            // TODO: esta línea de código carga datos en la tabla 'banco_sangreDataSet.Registros' Puede moverla o quitarla según sea necesario.
            this.registrosTableAdapter.Fill(this.banco_sangreDataSet.Registros);
            // TODO: esta línea de código carga datos en la tabla 'dATOSDataSet.ALUMNOS' Puede moverla o quitarla según sea necesario.
            this.aLUMNOSTableAdapter.Fill(this.dATOSDataSet.ALUMNOS);*/

            dt.Columns.Add("ID");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Edad");
            dt.Columns.Add("Sangre");
            dt.Columns.Add("Crónica");

            dtw_Registro.DataSource = dt;

            CargarDatos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                string query = "INSERT INTO Registros (ID,Nombre, Edad, T_Sangre, E_Cronica,Fecha) VALUES (@ID,@Nombre, @Edad, @Sangre, @Cronica,@Fecha)";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@ID", id++);
                    cmd.Parameters.AddWithValue("@Nombre", txtnombre.Text);
                    cmd.Parameters.AddWithValue("@Edad", int.Parse(txtedad.Text));
                    cmd.Parameters.AddWithValue("@Sangre", txtsangre.Text);
                    cmd.Parameters.AddWithValue("@Cronica", txtcronica.Text);
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Today);


                    cmd.ExecuteNonQuery();
                }
            }

            // Actualizar el DataGridView
            CargarDatos();
        }
    }
}
