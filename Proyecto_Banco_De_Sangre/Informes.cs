
using System;
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
using System.Windows.Forms.DataVisualization.Charting; // Asegúrate de que esta referencia esté bien
using System.IO;


namespace Proyecto_Banco_De_Sangre
{
    public partial class Informes : Form
    {
        // No necesitas un DataTable global 'dt' si cada método de carga crea uno nuevo.
        // Lo dejo aquí si lo usas para otros fines que no se muestran.
        DataTable dt = new DataTable();
        string conexionString = "Server=DESKTOP-NC4SAIF\\SQÑEXPRESS;Database=banco_sangre;Trusted_Connection=True;";
        //string conexionString = "Server=L402-M6;Database=banco_sangre;Trusted_Connection=True;";


        public Informes()
        {
            InitializeComponent();
            InitializeCustomComponents(); // Llama a esto para configurar el chart al inicio
        }

        // Método para cargar datos en el DataGridView
        private void CargarDatos()
        {
            DataTable dtLocal = new DataTable(); // Usa un DataTable local para esta operación
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    string query = "Select T_SANGRE, FECHA_D, MILILITROS_D, ESTATUS from Sangre"; // Asegúrate de usar los nombres de columna correctos
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conexion))
                    {
                        da.Fill(dtLocal);
                    }
                }
                dtw_Informes.DataSource = dtLocal;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al cargar los datos para el DataGridView: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al cargar los datos para el DataGridView: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar datos en el Chart
        private void CargarGraficoTiposSangre()
        {
            grafica.Series.Clear(); // Limpiar las series existentes
            // Configura el título del área del gráfico si lo deseas aquí o en InitializeCustomComponents
            // grafica.ChartAreas[0].AxisX.Title = "Tipo de Sangre";
            // grafica.ChartAreas[0].AxisY.Title = "Mililitros (ml)";

            // Añadir una nueva serie. Puedes nombrarla como quieras.
            Series serieSangre = grafica.Series.Add("Mililitros por Tipo");
            serieSangre.ChartType = SeriesChartType.Column; // Puedes cambiar a Bar, Pie, Doughnut, etc.
            serieSangre.IsValueShownAsLabel = true; // Muestra el valor en la columna/rebanada

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    // Consulta para sumar los mililitros por cada tipo de sangre
                    string query = "SELECT T_SANGRE, SUM(MILILITROS_D) AS TotalMililitros FROM Sangre GROUP BY T_SANGRE";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows) // Verifica si hay datos antes de leer
                            {
                                MessageBox.Show("No se encontraron datos de sangre para la gráfica.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            while (reader.Read())
                            {
                                string tipoSangre = reader["T_SANGRE"].ToString();
                                int totalMililitros = Convert.ToInt32(reader["TotalMililitros"]);
                                serieSangre.Points.AddXY(tipoSangre, totalMililitros);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al cargar los datos para el gráfico: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al cargar los datos para el gráfico: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este método configura la apariencia inicial del Chart
        private void InitializeCustomComponents()
        {
            // Asegúrate de que el control 'grafica' esté inicializado en el diseñador
            // y que haya al menos un ChartArea.

            // Limpiar títulos existentes antes de añadir uno nuevo
            grafica.Titles.Clear();
            grafica.Titles.Add("Cantidad de Mililitros por Tipo de Sangre");

            // Configura los ejes del primer ChartArea (generalmente hay solo uno por defecto)
            if (grafica.ChartAreas.Any()) // Verifica si hay al menos un ChartArea
            {
                grafica.ChartAreas[0].AxisX.Title = "Tipo de Sangre";
                grafica.ChartAreas[0].AxisY.Title = "Mililitros (ml)";
            }

            grafica.Palette = ChartColorPalette.Pastel; // O la paleta que prefieras
        }

        // Aquí tienes dos métodos Informes_Load.
        // DEBES ELEGIR SOLO UNO y eliminar el otro, o asegurarte de que solo uno esté suscrito al evento Load.
        // El diseñador de Visual Studio generalmente vincula el evento Load al método 'Informes_Load_1' si lo creaste con doble click.

        // OPCION A: Usar este como el único manejador de eventos Load (recomendado)
        private void Informes_Load(object sender, EventArgs e)
        {
            // Ya no necesitas dt.Columns.Add si CargarDatos() llena el DataGridView desde la BD.
            // Si el DataGridView se autogenera columnas, esto podría ser redundante o causar problemas.
            // dtw_Informes.DataSource = dt; // Esto puede vaciarlo si 'dt' global no está siendo llenado

            CargarDatos();               // Carga los datos en el DataGridView
            CargarGraficoTiposSangre();  // Carga los datos en el Chart
            label2.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        // OPCION B: Si 'Informes_Load_1' es el que está REALMENTE suscrito al evento Load en tu diseñador,
        // entonces elimina el método 'Informes_Load' de arriba y modifica este:
        /*
        private void Informes_Load_1(object sender, EventArgs e)
        {
            CargarDatos();
            CargarGraficoTiposSangre(); // Asegúrate de llamar a este método aquí
            label2.Text = DateTime.Now.ToString("dd/MM/yyyy");
            // Elimina el otro Informes_Load de tu código.
        }
        */

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    try
                    {
                        conexion.Open();
                        string query = "SELECT SUM(MILILITROS_D) FROM Sangre WHERE T_SANGRE = @TipoSangre"; // Asegúrate de que T_SANGRE sea el nombre correcto de la columna
                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@TipoSangre", comboBox1.Text);

                            object resultado = cmd.ExecuteScalar();

                            if (resultado != DBNull.Value && resultado != null)
                            {
                                int totalMililitros = Convert.ToInt32(resultado);
                                label3.Text = "La cantidad de Mililitros total es de: " + totalMililitros.ToString();

                                // **** ATENCIÓN AQUÍ ****
                                // Parece que 'grafic' es un Label que usabas para una representación de texto.
                                // Ya no lo necesitas si estás usando el Chart.
                                // Si 'grafic' es el Chart, entonces su nombre está mal escrito aquí.
                                // Asumo que quieres actualizar la gráfica 'grafica' con el tipo seleccionado.
                                // Por favor, verifica el nombre de tu control Label o elimina estas líneas si 'grafic' no existe o no es necesario.
                                if (grafica != null) // Solo si 'grafic' es un Label que aún quieres usar
                                {
                                    grafica.Text = ""; // Limpia el Label
                                    // Esta lógica es para un Label que simula barras, no para el control Chart.
                                    // for (int i = 1; i <= totalMililitros / 50; i++)
                                    // {
                                    //     grafic.Text += "│ ";
                                    // }
                                }
                            }
                            else
                            {
                                label3.Text = "No se tiene Sangre de este tipo de sangre";
                                if (grafica != null) grafica.Text = ""; // Limpiar el Label de texto
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Error al consultar tipo de sangre: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inesperado al seleccionar tipo de sangre: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Actualizar el DataGridView con los datos filtrados
                CargarDatosFiltrados(comboBox1.Text);
                // Cargar el gráfico para mostrar solo el tipo de sangre seleccionado:
                CargarGraficoTipoSangreUnico(comboBox1.Text);
            }
            else
            {
                label3.Text = "";
                // Si el ComboBox se vacía, vuelve a cargar todos los datos en DataGridView y Chart
                CargarDatos();
                CargarGraficoTiposSangre();
            }
        }

        private void CargarDatosFiltrados(string tipoSangre)
        {
            DataTable dtLocal = new DataTable();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    string query = "SELECT T_SANGRE, FECHA_D, MILILITROS_D, ESTATUS FROM Sangre WHERE T_SANGRE = @TipoSangre";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@TipoSangre", tipoSangre);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtLocal);
                        }
                    }
                }
                dtw_Informes.DataSource = dtLocal;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al cargar datos filtrados para el DataGridView: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al cargar datos filtrados para el DataGridView: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGraficoTipoSangreUnico(string tipoSangre)
        {
            grafica.Series.Clear();
            Series serieUnica = grafica.Series.Add("Mililitros de " + tipoSangre);
            serieUnica.ChartType = SeriesChartType.Column;
            serieUnica.IsValueShownAsLabel = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    string query = "SELECT SUM(MILILITROS_D) AS TotalMililitros FROM Sangre WHERE T_SANGRE = @TipoSangre GROUP BY T_SANGRE";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@TipoSangre", tipoSangre);
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != DBNull.Value && resultado != null)
                        {
                            int totalMililitros = Convert.ToInt32(resultado);
                            serieUnica.Points.AddXY(tipoSangre, totalMililitros);
                        }
                        else
                        {
                            //   MessageBox.Show($"No hay datos de donación para el tipo de sangre {tipoSangre}.", "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al cargar el gráfico para el tipo de sangre único: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al cargar el gráfico para el tipo de sangre único: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Clases de informes (no relacionadas directamente con la gráfica pero parte de tu código)
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

                return registros.Where(r => r.Fecha >= startDate && r.Fecha <= endDate).ToList();
            }
        }

        private void dtw_Informes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evento para el DataGridView, puedes dejarlo vacío si no haces nada aquí
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registroscs frm = new Registroscs();
            frm.Show();
            this.Hide();
        }

        private void grafic_Click(object sender, EventArgs e)
        {
            // Este es el manejador de eventos para el click de tu Label 'grafic', NO de tu Chart 'grafica'.
            // Si no usas este Label como una gráfica de texto, puedes eliminar este evento y el Label 'grafic'.
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Puedes dejarlo vacío o eliminarlo si no lo usas
        }

        private void GenerateReport(DateTime selectedDate, string range)
        {
            // Este método parece estar incompleto o es un placeholder
            // Asegúrate de que este método sea llamado desde algún control (botón, etc.)
            // si quieres que genere un informe.
        }

        private void MostrarRegistrosEnInforme(List<Registro> registros)
        {
            // Puedes dejarlo vacío o eliminarlo si no lo usas
        }

       

        


        private void button3_Click_1(object sender, EventArgs e)
        {

            // Verificar si hay datos en el DataGridView
            if (dtw_Informes.Rows.Count == 0) // Cambiado de dtw_Registro a dtw_Informes
            {
                MessageBox.Show("No hay datos para exportar en el DataGridView.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*";
            saveFileDialog.FileName = "InformesDeSangre.csv"; // Nombre de archivo por defecto (cambiado para reflejar Informes)

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8)) // 'false' para sobrescribir
                    {
                        // 1. Escribir encabezados de columna
                        for (int i = 0; i < dtw_Informes.Columns.Count; i++) // Cambiado de dtw_Registro a dtw_Informes
                        {
                            sw.Write(EscapeCsvField(dtw_Informes.Columns[i].HeaderText)); // Cambiado de dtw_Registro a dtw_Informes
                            if (i < dtw_Informes.Columns.Count - 1) // Cambiado de dtw_Registro a dtw_Informes
                            {
                                sw.Write(",");
                            }
                        }
                        sw.WriteLine(); // Nueva línea después de los encabezados

                        // 2. Escribir filas de datos
                        foreach (DataGridViewRow row in dtw_Informes.Rows) // Cambiado de dtw_Registro a dtw_Informes
                        {
                            // Ignorar la fila "nueva fila" si existe y no está comprometida
                            if (row.IsNewRow) continue;

                            for (int i = 0; i < dtw_Informes.Columns.Count; i++) // Cambiado de dtw_Registro a dtw_Informes
                            {
                                object cellValue = row.Cells[i].Value;
                                string cellText = (cellValue == null) ? "" : cellValue.ToString();

                                sw.Write(EscapeCsvField(cellText));
                                if (i < dtw_Informes.Columns.Count - 1) // Cambiado de dtw_Registro a dtw_Informes
                                {
                                    sw.Write(",");
                                }
                            }
                            sw.WriteLine(); // Nueva línea después de cada fila de datos
                        }
                    }

                    MessageBox.Show($"Datos exportados exitosamente a:\n{filePath}", "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al exportar los datos: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método auxiliar para escapar campos CSV (necesario si vas a exportar a CSV)
        private string EscapeCsvField(string field)
        {
            if (field == null) return "";
            // Si el campo contiene coma, comillas o nueva línea, encuéntralo entre comillas y escapa las comillas internas.
            if (field.Contains(",") || field.Contains("\"") || field.Contains(Environment.NewLine))
            {
                return $"\"{field.Replace("\"", "\"\"")}\"";
            }
            return field;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarDatos();
            CargarGraficoTiposSangre();
        }

        private void grafica_Click(object sender, EventArgs e)
        {

        }
    }
}

