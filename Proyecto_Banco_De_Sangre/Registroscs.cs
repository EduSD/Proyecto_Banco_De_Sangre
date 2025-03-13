﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Banco_De_Sangre
{
    public partial class Registroscs : Form
    {
        DataTable dt = new DataTable();
        int id = 2;
        string conexionString = "Server=DESKTOP-NC4SAIF\\SQÑEXPRESS;Database=banco_sangre;Trusted_Connection=True;";
        //string conexionString = "Server=YAKUGAMER732\\SQLEXPRESS;Database=banco_sangre;Trusted_Connection=True;";


        public Registroscs()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
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

        private void Registroscs_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("ID");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Edad");
            dt.Columns.Add("Sangre");
            dt.Columns.Add("Crónica");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Estado");
            dt.Columns.Add("DiasRestantes");

            dtw_Registro.DataSource = dt;

            CargarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                string query = "INSERT INTO Registros (ID, Nombre, Edad, T_Sangre, E_Cronica, Fecha) VALUES (@ID, @Nombre, @Edad, @Sangre, @Cronica, @Fecha)";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@ID", id++);
                    cmd.Parameters.AddWithValue("@Nombre", txtnombre.Text);
                    cmd.Parameters.AddWithValue("@Edad", int.Parse(txtedad.Text));
                    cmd.Parameters.AddWithValue("@Sangre", txtsangre.Text);
                    cmd.Parameters.AddWithValue("@Cronica", txtcronica.Text);
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Today.ToString("dd/MM/yyyy"));
                    

                    cmd.ExecuteNonQuery();
                }
            }

            // Actualizar la tabla 
            CargarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Informes frm = new Informes(); // Cambiado a Informes
            frm.Show();
            this.Hide();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtw_Registro.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dtw_Registro.SelectedRows[0].Index;
                int id = Convert.ToInt32(dtw_Registro.Rows[selectedRowIndex].Cells["ID"].Value);

                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    string query = "DELETE FROM Registros WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Actualizar la tabla 
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }
        }
    }
}