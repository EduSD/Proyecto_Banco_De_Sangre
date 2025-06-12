
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;

namespace Proyecto_Banco_De_Sangre
{
    public partial class Registroscs : Form
    {
        DataTable dt = new DataTable();
        string conexionString = "Server=DESKTOP-NC4SAIF\\SQÑEXPRESS;Database=banco_sangre;Trusted_Connection=True;";

        public Registroscs()
        {
            InitializeComponent();

            // Configuración inicial de los TextBox
            txtnombre.MaxLength = 100;
            txtsangre.MaxLength = 0;
            txtedad.KeyPress += new KeyPressEventHandler(txtedad_KeyPress);
            txtlitros2.KeyPress += new KeyPressEventHandler(txtlitros2_KeyPress);
        }

        // Método para limpiar los campos de texto
        private void limpiar()
        {
            // ... (Tu código existente para limpiar los TextBoxes y ErrorProviders) ...
            txtnombre.Text = " ";
            txtedad.Text = " ";
            txtlitros2.Text = " ";
            txtsangre.Text = " ";
            txtID.Text = " ";

            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();

            // *** AÑADIR ESTAS LÍNEAS para restablecer el mensaje de estado ***
           // lblMensajeEstado.Text = "Campos listos para nuevo registro.";
            lblMensajeEstado.BackColor = System.Drawing.SystemColors.Control; // Color de fondo por defecto
        }

        private void CargarDatos()
        {
            dt.Clear();

            try
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
                // *** AÑADIR ESTAS LÍNEAS para actualizar el mensaje de estado al cargar datos ***
                lblMensajeEstado.Text = $"Datos cargados correctamente. Se encontraron {dt.Rows.Count} registros.";
                lblMensajeEstado.BackColor = System.Drawing.Color.LightGreen; // Verde para éxito de carga
            }
            catch (SqlException ex)
            {
                // *** MODIFICAR ESTAS LÍNEAS para actualizar el mensaje de estado en caso de error ***
                lblMensajeEstado.Text = $"Error de BD al cargar datos: {ex.Message}";
                lblMensajeEstado.BackColor = System.Drawing.Color.LightCoral; // Rojo para error
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // *** MODIFICAR ESTAS LÍNEAS para actualizar el mensaje de estado en caso de error ***
                lblMensajeEstado.Text = $"Error inesperado al cargar datos: {ex.Message}";
                lblMensajeEstado.BackColor = System.Drawing.Color.LightCoral; // Rojo para error
                MessageBox.Show($"Error inesperado al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Registroscs_Load_1(object sender, EventArgs e)
        {
            CargarDatos();

            lblMensajeEstado.Text = "Aplicación iniciada. Lista para operar.";
            lblMensajeEstado.BackColor = System.Drawing.SystemColors.Control; 

      
        }


        // Evento Click del botón Agregar
        private void btnAgregar_Click(object sender, EventArgs e)

        {

            
                // Limpiar errores previos
                errorProvider1.Clear();
                errorProvider2.Clear();
                errorProvider3.Clear();
                errorProvider4.Clear();
                errorProvider5.Clear();

                // Validar campos vacíos ANTES de procesar
                if (string.IsNullOrWhiteSpace(txtnombre.Text))
                {
                    errorProvider1.SetError(txtnombre, "El nombre no puede estar vacío");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtsangre.Text))
                {
                    errorProvider2.SetError(txtsangre, "Seleccione un tipo de sangre");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtedad.Text))
                {
                    errorProvider4.SetError(txtedad, "La edad no puede estar vacía");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtlitros2.Text))
                {
                    errorProvider5.SetError(txtlitros2, "Ingrese los mililitros donados");
                    return;
                }

                // Validaciones de formato y lógica
                try
                {
                    string nombreDonante = txtnombre.Text;
                    int litrosDonados = int.Parse(txtlitros2.Text);
                    int edad = int.Parse(txtedad.Text);
                    string sangre = txtsangre.Text;
                    DateTime fechaDonacion = DateTime.Today;

                    // Validar edad mínima (17 años)
                    int añoNacimiento = int.Parse(txtedad.Text);
                    int añoActual = DateTime.Now.Year;
                    int edadCalculada = añoActual - añoNacimiento;

                    if (edadCalculada < 17)
                    {
                        errorProvider4.SetError(txtedad, "No puedes donar si tienes menos de 17 años");
                        return;
                    }

                    // Validar litros máximos (450 ml)
                    if (litrosDonados > 450)
                    {
                        errorProvider3.SetError(txtlitros2, "No se pueden donar más de 450 ml");
                        return;
                    }

                    // Validar tiempo entre donaciones
                    if (!PuedeDonar(nombreDonante, fechaDonacion))
                    {
                        MessageBox.Show("Deben pasar 64 días desde tu última donación.");
                        return;
                    }

                    // Insertar en la base de datos (solo si todas las validaciones pasan)
                    using (SqlConnection conexion = new SqlConnection(conexionString))
                    {
                        conexion.Open();

                        // Insertar en Registros
                        string queryRegistros = @"INSERT INTO Registros(NOMBRE_C, EDAD, T_SANGRE, MILILITROS_D, FECHA_D) 
                                    VALUES(@NOMBRE_C, @EDAD, @T_SANGRE, @MILILITROS_D, @FECHA_D)";
                        using (SqlCommand cmd = new SqlCommand(queryRegistros, conexion))
                        {
                            cmd.Parameters.AddWithValue("@NOMBRE_C", nombreDonante);
                            cmd.Parameters.AddWithValue("@EDAD", edad);
                            cmd.Parameters.AddWithValue("@T_SANGRE", sangre);
                            cmd.Parameters.AddWithValue("@MILILITROS_D", litrosDonados);
                            cmd.Parameters.AddWithValue("@FECHA_D", fechaDonacion);
                            cmd.ExecuteNonQuery();
                        }

                        // Insertar en Sangre
                        string querySangre = @"INSERT INTO Sangre (T_SANGRE, MILILITROS_D, FECHA_D, ESTATUS)
                                SELECT T_SANGRE, MILILITROS_D, FECHA_D, 
                                    CASE 
                                        WHEN DATEDIFF(DAY, FECHA_D, GETDATE()) > 42 THEN 'Caducada'
                                        ELSE 'Disponible'
                                    END 
                                FROM Registros 
                                WHERE NOMBRE_C = @NOMBRE_C AND FECHA_D = @FECHA_D";
                        using (SqlCommand cmdSangre = new SqlCommand(querySangre, conexion))
                        {
                            cmdSangre.Parameters.AddWithValue("@NOMBRE_C", nombreDonante);
                            cmdSangre.Parameters.AddWithValue("@FECHA_D", fechaDonacion);
                            cmdSangre.ExecuteNonQuery();
                        }
                    }

                    // Limpiar campos y actualizar datos
                    limpiar();
                    CargarDatos();
                    MessageBox.Show("Registro agregado exitosamente.");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Verifica que los campos numéricos (edad/litros) contengan valores válidos.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error de base de datos: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inesperado: {ex.Message}");
                }
            




        }





        private bool PuedeDonar(string nombreDonante, DateTime fechaDonacion)
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                string query = "SELECT MAX(FECHA_D) FROM Registros WHERE NOMBRE_C = @Nombre";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombreDonante);
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != DBNull.Value && resultado != null)
                    {
                        DateTime ultimaDonacion = Convert.ToDateTime(resultado);
                        TimeSpan diferencia = fechaDonacion - ultimaDonacion;
                        return diferencia.TotalDays >= 64;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Informes frm = new Informes();
            frm.Show();
            this.Hide();
            lblMensajeEstado.Text = "Abriendo formulario de reportes.";
            lblMensajeEstado.BackColor = System.Drawing.SystemColors.Control; // Restablecer color
        
    }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            string validiar = Interaction.InputBox("Ingrese el codigo necesario:", "InputBox");

            if (validiar == "1982")
            {
                txtID.Enabled = true;
                btnConsultar.Enabled = true;
                btnEliminar.Enabled = true;

                txtedad.Enabled = false;
                txtlitros2.Enabled = false;
                btnAgregar.Enabled = false;

                lblMensajeEstado.Text = "Modo de consulta/eliminación activado. Ingrese ID o criterios de búsqueda.";
                lblMensajeEstado.BackColor = System.Drawing.Color.LightBlue; // Azul claro para modo especial
            }
            else
            {
                lblMensajeEstado.Text = "Código de validación incorrecto.";
                lblMensajeEstado.BackColor = System.Drawing.Color.OrangeRed; // Rojo para código incorrecto
            }
            CargarDatos();
        }

        private void btnConsultar_Click_1(object sender, EventArgs e)
        {
            dt.Clear();

            try
            {
                string nombre = txtnombre.Text.Trim();
                string edad = txtedad.Text.Trim();
                string sangre = txtsangre.Text.Trim();
                string litros = txtlitros2.Text.Trim();

                string query = "SELECT * FROM Registros WHERE 1 = 1";

                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        if (!string.IsNullOrEmpty(nombre))
                        {
                            query += " AND NOMBRE_C LIKE @Nombre";
                            cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                        }

                        if (!string.IsNullOrEmpty(edad))
                        {
                            query += " AND EDAD = @Edad";
                            cmd.Parameters.AddWithValue("@Edad", edad);
                        }

                        if (!string.IsNullOrEmpty(sangre))
                        {
                            query += " AND T_SANGRE LIKE @Sangre";
                            cmd.Parameters.AddWithValue("@Sangre", "%" + sangre + "%");
                        }

                        if (!string.IsNullOrEmpty(litros))
                        {
                            query += " AND MILILITROS_D = @Litros";
                            cmd.Parameters.AddWithValue("@Litros", litros);
                        }

                        cmd.CommandText = query;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        dtw_Registro.DataSource = dt;

                        if (dt.Rows.Count > 0)
                        {
                            lblbajo.Text = $"Consulta realizada. Se encontraron {dt.Rows.Count} registros.";
                            lblbajo.BackColor = System.Drawing.Color.LightGreen;
                        }
                        else
                        {
                            lblbajo.Text = "No se encontraron registros que coincidan con los criterios de búsqueda.";
                            lblbajo.BackColor = System.Drawing.Color.Orange;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                lblbajo.Text = $"Error SQL al consultar: {ex.Message}";
                lblbajo.BackColor = System.Drawing.Color.LightCoral;
                MessageBox.Show($"Ha ocurrido un error al realizar la consulta. Por favor, contacte al administrador.\nDetalles: {ex.Message}", "Error de Consulta SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblbajo.Text = $"Error inesperado al consultar: {ex.Message}";
                lblbajo.BackColor = System.Drawing.Color.LightCoral;
                MessageBox.Show($"Ha ocurrido un error inesperado. Por favor, contacte al administrador.\nDetalles: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtID.Enabled = false;
                btnConsultar.Enabled = false;
                btnEliminar.Enabled = false;

                txtedad.Enabled = true;
                txtsangre.Enabled = true;
                txtlitros2.Enabled = true;
                btnAgregar.Enabled = true;

                limpiar();
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtID.Text.Trim(), out int idRegistro))
                {
                    DialogResult resultado = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar el registro con ID " + idRegistro + "? Esta acción no se puede deshacer.",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        using (SqlConnection conexion = new SqlConnection(conexionString))
                        {
                            conexion.Open();
                            string query = "DELETE FROM Registros WHERE ID = @ID";

                            using (SqlCommand cmd = new SqlCommand(query, conexion))
                            {
                                cmd.Parameters.AddWithValue("@ID", idRegistro);
                                int filasAfectadas = cmd.ExecuteNonQuery();

                                if (filasAfectadas > 0)
                                {
                                   // MessageBox.Show("Registro eliminado correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lblMensajeEstado.Text = $"Registro con ID {idRegistro} eliminado exitosamente.";
                                    lblMensajeEstado.BackColor = System.Drawing.Color.LightGreen; 
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró ningún registro con el ID especificado.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lblMensajeEstado.Text = $"Advertencia: No se encontró registro con ID {idRegistro}.";
                                    lblMensajeEstado.BackColor = System.Drawing.Color.Orange; 
                                }
                            }
                        }
                    }
                    else
                    {
                        lblMensajeEstado.Text = "Eliminación cancelada por el usuario.";
                        lblMensajeEstado.BackColor = System.Drawing.SystemColors.Control; 
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa un ID válido para eliminar.", "ID Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblMensajeEstado.Text = "Error: ID de registro inválido.";
                    lblMensajeEstado.BackColor = System.Drawing.Color.OrangeRed; 
                }
            }
            catch (SqlException ex)
            {
                lblMensajeEstado.Text = $"Error SQL al eliminar registro: {ex.Message}";
                lblMensajeEstado.BackColor = System.Drawing.Color.LightCoral; 
                MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblMensajeEstado.Text = $"Error inesperado al eliminar: {ex.Message}";
                lblMensajeEstado.BackColor = System.Drawing.Color.LightCoral; 
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CargarDatos();
                txtID.Enabled = false;
                btnConsultar.Enabled = false;
                btnEliminar.Enabled = false;

                txtedad.Enabled = true;
                txtsangre.Enabled = true;
                txtlitros2.Enabled = true;
                btnAgregar.Enabled = true;

                limpiar(); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
            lblMensajeEstado.Text = "Datos recargados.";
            lblMensajeEstado.BackColor = System.Drawing.SystemColors.Control; // Restablecer color
        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            Informes frm = new Informes();
            frm.Show();
            this.Hide();
        lblMensajeEstado.Text = "Abriendo formulario de informes.";
        lblMensajeEstado.BackColor = System.Drawing.SystemColors.Control;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dtw_Registro.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar en el DataGridView.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblMensajeEstado.Text = "Advertencia: No hay datos para exportar.";
                lblMensajeEstado.BackColor = System.Drawing.Color.Orange;
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*";
            saveFileDialog.FileName = "RegistrosDonaciones.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        for (int i = 0; i < dtw_Registro.Columns.Count; i++)
                        {
                            sw.Write(EscapeCsvField(dtw_Registro.Columns[i].HeaderText));
                            if (i < dtw_Registro.Columns.Count - 1)
                            {
                                sw.Write(",");
                            }
                        }
                        sw.WriteLine();

                        foreach (DataGridViewRow row in dtw_Registro.Rows)
                        {
                            if (row.IsNewRow) continue;

                            for (int i = 0; i < dtw_Registro.Columns.Count; i++)
                            {
                                object cellValue = row.Cells[i].Value;
                                string cellText = (cellValue == null) ? "" : cellValue.ToString();
                                sw.Write(EscapeCsvField(cellText));
                                if (i < dtw_Registro.Columns.Count - 1)
                                {
                                    sw.Write(",");
                                }
                            }
                            sw.WriteLine();
                        }
                    }
                    MessageBox.Show($"Datos exportados exitosamente a:\n{filePath}", "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblMensajeEstado.Text = $"Datos exportados a: {Path.GetFileName(filePath)}";
                    lblMensajeEstado.BackColor = System.Drawing.Color.LightGreen;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al exportar los datos: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblMensajeEstado.Text = $"Error al exportar datos: {ex.Message}";
                    lblMensajeEstado.BackColor = System.Drawing.Color.LightCoral;
                }
            }
            else
            {
                lblMensajeEstado.Text = "Exportación de datos cancelada.";
                lblMensajeEstado.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        private string EscapeCsvField(string field)
        {
            if (field == null) return "";

            if (field.Contains(",") || field.Contains("\"") || field.Contains(Environment.NewLine))
            {
                return $"\"{field.Replace("\"", "\"\"")}\"";
            }
            return field;
        }

        // Métodos KeyPress para validar entrada numérica
        private void txtedad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtlitros2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtedad_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void txtedad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
  
            if (!string.IsNullOrEmpty(txtedad.Text.Trim()) && !int.TryParse(txtedad.Text.Trim(), out int edad))
            {
                errorProvider4.SetError(txtedad, "Por favor, introduce solo números en este campo.");
                lblbajo.Text = "Error de validación: La edad debe ser numérica.";
                lblbajo.BackColor = System.Drawing.Color.OrangeRed;
                e.Cancel = true; // Impide que el foco se mueva si la validación falla
            }
            else
            {
                errorProvider4.Clear();
               
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void txtsangre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}