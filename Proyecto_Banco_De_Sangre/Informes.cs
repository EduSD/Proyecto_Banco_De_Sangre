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
    public partial class Informes : Form
    {
        DataTable dt = new DataTable();
        string conexionString = "Server=DESKTOP-NC4SAIF\\SQÑEXPRESS;Database=banco_sangre;Trusted_Connection=True;";

        public Informes()
        {
            InitializeComponent();
            InitializeCustomComponents();

        }

        //carag en la base de datos
        

        private void CargarDatos()
        {
            
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                string query = "INSERT INTO Sangre (T_Sangre, F_RH, Fecha_C, Litros) " +
               "SELECT T_Sangre,FROM Registros";


                using (SqlDataAdapter da = new SqlDataAdapter(query, conexion))
                {
                    da.Fill(dt);
                }
            }



            dtw_Informes.DataSource = dt;
        }

        private void InitializeCustomComponents()
        {
            // Agregar DateTimePicker
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Location = new Point(10, 10); // Ajusta la ubicación según sea necesario
            dateTimePicker.Format = DateTimePickerFormat.Short; // Formato de fecha corto
            this.Controls.Add(dateTimePicker);

            // Agregar ComboBox para seleccionar el rango de días
            ComboBox comboBox = new ComboBox();
            comboBox.Items.Add("Últimos 7 días");
            comboBox.Items.Add("Últimos 15 días");
            comboBox.Items.Add("Últimos 30 días");
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList; // Esto asegura que solo se pueda seleccionar una opción
            comboBox.Location = new Point(10, 50); // Ajusta la ubicación según sea necesario
            comboBox.SelectedIndexChanged += (sender, e) => GenerateReport(dateTimePicker.Value, comboBox.SelectedItem.ToString());
            this.Controls.Add(comboBox);

            label2.Text = DateTime.Today.ToString("dd/MM/yyyy");

        }

        private void GenerateReport(DateTime selectedDate, string range)
        {
            DateTime startDate = selectedDate;
            DateTime endDate = DateTime.Now;

            switch (range)
            {
                case "Últimos 7 días":
                    startDate = selectedDate.AddDays(-7);
                    break;
                case "Últimos 15 días":
                    startDate = selectedDate.AddDays(-15);
                    break;
                case "Últimos 30 días":
                    startDate = selectedDate.AddDays(-30);
                    break;
            }

            // Obtener registros y mostrar en el informe
            InformeManager informeManager = new InformeManager();
            List<Registro> registros = informeManager.ObtenerRegistros(startDate, endDate);
            MostrarRegistrosEnInforme(registros);
        }

        private void MostrarRegistrosEnInforme(List<Registro> registros)
        {
            StringBuilder informe = new StringBuilder();
            foreach (var registro in registros)
            {
                informe.AppendLine($"{registro.Fecha.ToShortDateString()}: {registro.Detalle}");
            }
            MessageBox.Show(informe.ToString(), "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //declaracion delas columnas de la tabla
        private void Informes_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("T_Sangre");
            dt.Columns.Add("F_RH");
            dt.Columns.Add("Fecha_C");
            dt.Columns.Add("Litros");

            dtw_Informes.DataSource = dt;

            CargarDatos();

        }

        private void Informes_Load_1(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'banco_sangreDataSet1.Sangre' Puede moverla o quitarla según sea necesario.
            this.sangreTableAdapter.Fill(this.banco_sangreDataSet1.Sangre);
            // TODO: esta línea de código carga datos en la tabla 'banco_sangreDataSet.Registros' Puede moverla o quitarla según sea necesario.
            this.registrosTableAdapter.Fill(this.banco_sangreDataSet.Registros);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("A+"))
            {
                DataTable dt = new DataTable();
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    string query = "SELECT * FROM Sangre WHERE T_Sangre LIKE @T_Sangre";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@T_Sangre", "%" + comboBox1.Text + "%"); // Búsqueda flexible

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                dtw_Informes.DataSource = dt; // Muestra los resultados en el DataGridView
            }
            else if (comboBox1.Text.Equals("A-"))
            {
                DataTable dt = new DataTable();
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    string query = "SELECT * FROM Sangre WHERE T_Sangre LIKE @T_Sangre";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@T_Sangre", "%" + comboBox1.Text + "%"); // Búsqueda flexible

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                dtw_Informes.DataSource = dt; // Muestra los resultados en el DataGridView

            }

        }

        // Aqui no se como quieres mostrar el informe con sangre de grupos compartidos o 1x1
        public class Registro
        {
            public DateTime Fecha { get; set; }
            public string Detalle { get; set; }
        }

        public class InformeManager
        {
            public List<Registro> ObtenerRegistros(DateTime startDate, DateTime endDate)
            {
                // Datos falsos xd
                List<Registro> registros = new List<Registro>
            {
                new Registro { Fecha = DateTime.Now.AddDays(-1), Detalle = "Donación de sangre A+" },
                new Registro { Fecha = DateTime.Now.AddDays(-5), Detalle = "Donación de sangre O-" },
                new Registro { Fecha = DateTime.Now.AddDays(-10), Detalle = "Donación de sangre B+" },
                new Registro { Fecha = DateTime.Now.AddDays(-20), Detalle = "Donación de sangre AB-" }
            };

                // Filtrar registros por rango de fechas pero se platica después serian 7 dias, 15 dias o 30 dias por ejemplo
                return registros.Where(r => r.Fecha >= startDate && r.Fecha <= endDate).ToList();
            }
        }
    }
} 