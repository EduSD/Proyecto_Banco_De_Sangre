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
using System.Windows.Forms.DataVisualization.Charting; // Agregar esta línea

namespace Proyecto_Banco_De_Sangre
{
    public partial class Informes : Form
    {
        DataTable dt = new DataTable();
        string conexionString = "Server=DESKTOP-NC4SAIF\\SQLEXPRESS;Database=banco_sangre;Trusted_Connection=True;";
        private Chart chartSangre; // Declarar el objeto Chart

        public Informes()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Crear el Chart dinámicamente
            chartSangre = new Chart();
            chartSangre.Location = new Point(300, 50); // Posición del gráfico
            chartSangre.Size = new Size(600, 300); // Tamaño del gráfico
            Controls.Add(chartSangre);

            // Configurar el Chart
            chartSangre.ChartAreas.Add(new ChartArea("SangreArea"));
            chartSangre.Series.Add(new Series("Mililitros"));
            chartSangre.Series["Mililitros"].ChartType = SeriesChartType.Column;
            chartSangre.Series["Mililitros"].XValueMember = "T_Sangre";
            chartSangre.Series["Mililitros"].YValueMembers = "MILILITROS_D";
            chartSangre.Series["Mililitros"].IsValueShownAsLabel = true;
        }

        private void CargarDatos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                string query = "Select * from Sangre";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conexion))
                {
                    da.Fill(dt);
                }
            }
            dtw_Informes.DataSource = dt;
        }

        private void Informes_Load_1(object sender, EventArgs e)
        {
            CargarDatos();
            label2.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    string query = "SELECT SUM(MILILITROS_D) FROM Sangre WHERE T_Sangre = @TipoSangre";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@TipoSangre", comboBox1.Text);
                        object resultado = cmd.ExecuteScalar();
                        if (resultado != DBNull.Value && resultado != null)
                        {
                            int totalMililitros = Convert.ToInt32(resultado);
                            label3.Text = "La cantidad de Mililitros total es de: " + totalMililitros.ToString();
                        }
                        else
                        {
                            label3.Text = "No se tiene Sangre de este tipo de sangre";
                        }
                    }
                }
                CargarDatosFiltrados(comboBox1.Text);
                ActualizarGrafico(comboBox1.Text);
            }
            else
            {
                label3.Text = "";
                CargarDatos();
                ActualizarGrafico("");
            }
        }

        private void CargarDatosFiltrados(string tipoSangre)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                string query = "SELECT * FROM Sangre WHERE T_Sangre = @TipoSangre";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@TipoSangre", tipoSangre);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            dtw_Informes.DataSource = dt;
        }

        private void ActualizarGrafico(string tipoSangre)
        {
            DataTable dtGrafico = new DataTable();
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                string query;
                if (string.IsNullOrEmpty(tipoSangre))
                {
                    query = "SELECT T_Sangre, SUM(MILILITROS_D) AS MILILITROS_D FROM Sangre GROUP BY T_Sangre";
                }
                else
                {
                    query = "SELECT T_Sangre, SUM(MILILITROS_D) AS MILILITROS_D FROM Sangre WHERE T_Sangre = @TipoSangre GROUP BY T_Sangre";
                }
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    if (!string.IsNullOrEmpty(tipoSangre))
                    {
                        cmd.Parameters.AddWithValue("@TipoSangre", tipoSangre);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dtGrafico);
                    }
                }
            }
            chartSangre.DataSource = dtGrafico;
            chartSangre.DataBind();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registroscs frm = new Registroscs();
            frm.Show();
            this.Hide();
        }
    }
}