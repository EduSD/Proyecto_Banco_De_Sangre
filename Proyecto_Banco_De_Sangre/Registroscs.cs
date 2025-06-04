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

        // Cadena de conexión a la base de datos
       
        string conexionString = "Server=DESKTOP-NC4SAIF\\SQÑEXPRESS;Database=banco_sangre;Trusted_Connection=True;";

        public Registroscs()
        {
            InitializeComponent();
        }

        // Método para limpiar los campos de texto
        private void limpiar()
        {
            txtnombre.Text = " "; 
            txtedad.Text = " ";   
            txtlitros2.Text = " ";
            txtsangre.Text = " "; 
            txtID.Text = " ";     

            // Limpiar los ErrorProviders
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();
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
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Registroscs_Load_1(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("dd/MM/yyyy");


            CargarDatos(); // Cargar los datos iniciales al iniciar el formulario
        }

        // Evento Click del botón Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreDonante = txtnombre.Text.Trim();
                int litrosDonados = int.Parse(txtlitros2.Text.Trim());
                DateTime fechaDonacion = DateTime.Today;
                int edad = int.Parse(txtedad.Text.Trim());
                string sangre = txtsangre.Text.Trim();

               
                if (edad < 17) // Si 'edad' es la edad actual
                {
                    errorProvider4.SetError(txtedad, "No puedes donar si tienes menos de 17 años");
                    return; 
                }
                else
                {
                    errorProvider4.Clear();
                }

                // Validación de cantidad de litros donados
                if (litrosDonados > 450)
                {
                    errorProvider3.SetError(txtlitros2, "El paciente no puede donar mas de 450 mililitros de sangre");
                    return;
                }
                else
                {
                    errorProvider3.Clear(); 
                }

                // Validación del tiempo entre donaciones
                if (!PuedeDonar(nombreDonante, fechaDonacion))
                {
                    MessageBox.Show("No puedes donar sangre hasta que hayan pasado 64 días desde tu última donación.");
                    return;
                }

                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();

                    // Insertar en la tabla Registros
                    string queryInsertRegistros = "INSERT INTO Registros(NOMBRE_C, EDAD, T_SANGRE, MILILITROS_D, FECHA_D) VALUES(@NOMBRE_C, @EDAD, @T_SANGRE, @MILILITROS_D, @FECHA_D)";
                    using (SqlCommand cmd = new SqlCommand(queryInsertRegistros, conexion))
                    {
                        cmd.Parameters.AddWithValue("@NOMBRE_C", nombreDonante); 
                        cmd.Parameters.AddWithValue("@EDAD", edad);             
                        cmd.Parameters.AddWithValue("@T_SANGRE", sangre);       
                        cmd.Parameters.AddWithValue("@MILILITROS_D", litrosDonados);
                        cmd.Parameters.AddWithValue("@FECHA_D", fechaDonacion);
                        cmd.ExecuteNonQuery();
                    }

                    // Insertar en la tabla Sangre desde Registros
                    string queryInsertSangre = @"
                        INSERT INTO Sangre (T_SANGRE, MILILITROS_D, FECHA_D, ESTATUS)
                        SELECT T_SANGRE, MILILITROS_D, FECHA_D,
                            CASE
                                WHEN DATEDIFF(DAY, FECHA_D, GETDATE()) > 42 THEN 'Caducada'
                                ELSE 'Disponible'
                            END
                        FROM Registros
                        WHERE NOMBRE_C = @NOMBRE_C AND FECHA_D = @FECHA_D"; 
                                                                            

                    using (SqlCommand cmdSangre = new SqlCommand(queryInsertSangre, conexion))
                    {
                        cmdSangre.Parameters.AddWithValue("@NOMBRE_C", nombreDonante);
                        cmdSangre.Parameters.AddWithValue("@FECHA_D", fechaDonacion);
                        cmdSangre.ExecuteNonQuery();
                    }
                }

                CargarDatos(); 
                errorProvider1.Clear(); 
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error en la base de datos al agregar: {ex.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException) // Captura específica si la conversión a int falla
            {
                MessageBox.Show("Por favor, introduce valores numéricos válidos en Edad y Litros Donados.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Aquí puedes poner SetError para cada campo numérico si quieres
                if (string.IsNullOrWhiteSpace(txtedad.Text)) errorProvider4.SetError(txtedad, "La edad es obligatoria.");
                if (string.IsNullOrWhiteSpace(txtlitros2.Text)) errorProvider5.SetError(txtlitros2, "Los litros son obligatorios.");
            }
            catch (Exception ex)
            {
                
                
                if (txtnombre.Text == " ") errorProvider1.SetError(txtnombre, "El campo Nombre no debe permanecer vacío");
                else errorProvider1.Clear(); 

                if (txtsangre.Text == " ") errorProvider2.SetError(txtsangre, "Favor de seleccionar un tipo de sangre de las opciones presentadas");
                else errorProvider2.Clear(); 

                if (txtedad.Text == " ") errorProvider4.SetError(txtedad, "Favor de no dejar el campo vacío");
                else errorProvider4.Clear(); 

                if (txtlitros2.Text == " ") errorProvider5.SetError(txtlitros2, "Favor de llenar el campo");
                else errorProvider5.Clear(); 

                MessageBox.Show($"Ha ocurrido un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            if (txtnombre.Text != " " && txtedad.Text != " " && txtsangre.Text != " " && txtlitros2.Text != " ")
            {
                limpiar();
            }
        }

        // Método para verificar si el donante puede donar según el tiempo transcurrido
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

        // Botón para ir a Reportes/Informes
        private void btnReportes_Click(object sender, EventArgs e)
        {
            Informes frm = new Informes();
            frm.Show();
            this.Hide();
        }

      


        // Evento Click del botón Modificar (Parece ser para habilitar campos de búsqueda/eliminar)
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
            }
       
            CargarDatos();
        }

        // Evento Click del botón Consultar (btnConsultar_Click_1 es el que está suscrito)
        private void btnConsultar_Click_1(object sender, EventArgs e)
        {
            dt.Clear();

            try
            {
                

                string nombre = txtnombre.Text.Trim();
                string edad = txtedad.Text.Trim();
                string sangre = txtsangre.Text.Trim(); 
                string litros = txtlitros2.Text.Trim();

                // Crear la base de la consulta SQL dinámica
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
                            query += " AND EDAD = @Edad"; // Comparación exacta
                            cmd.Parameters.AddWithValue("@Edad", edad);
                        }

                        if (!string.IsNullOrEmpty(sangre))
                        {
                            query += " AND T_SANGRE LIKE @Sangre"; // Usa LIKE si quieres búsqueda parcial como en tu original
                            cmd.Parameters.AddWithValue("@Sangre", "%" + sangre + "%");
                        }

                        if (!string.IsNullOrEmpty(litros))
                        {
                            query += " AND MILILITROS_D = @Litros"; // Comparación exacta
                            cmd.Parameters.AddWithValue("@Litros", litros);
                        }

                        // Actualizar la propiedad CommandText del SqlCommand con la query construida
                        cmd.CommandText = query;

                        // Crear un SqlDataAdapter para llenar el DataTable global
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt); // Llenar el DataTable global 'dt'
                        }
                        // Asignar el DataTable lleno al DataGridView
                        dtw_Registro.DataSource = dt;

                        // Mensaje si no se encontraron resultados
                        if (dt.Rows.Count == 0 && string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(edad) && string.IsNullOrEmpty(sangre) && string.IsNullOrEmpty(litros))
                        {
                            MessageBox.Show("No se encontraron registros que coincidan con los criterios de búsqueda.", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ha ocurrido un error al realizar la consulta. Por favor, contacte al administrador.\nDetalles: {ex.Message}", "Error de Consulta SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error inesperado. Por favor, contacte al administrador.\nDetalles: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Siempre restablece el estado de los controles y limpia los campos después de la consulta
                txtID.Enabled = false;
                btnConsultar.Enabled = false;
                btnEliminar.Enabled = false;

                txtedad.Enabled = true;
                txtsangre.Enabled = true;
                txtlitros2.Enabled = true;
                btnAgregar.Enabled = true;

                limpiar(); // Limpiar los campos de entrada
            }
        }

        // Evento Click del botón Eliminar (btnEliminar_Click_1 es el que está suscrito)
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID del TextBox
                if (int.TryParse(txtID.Text.Trim(), out int idRegistro)) // Usar .Trim()
                {
                    // Confirmación antes de eliminar
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
                                    MessageBox.Show("Registro eliminado correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró ningún registro con el ID especificado.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa un ID válido para eliminar.", "ID Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
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

                limpiar(); // Limpiar los campos de entrada
            }
        }

        // Botón para recargar todos los datos (útil para ver todos los registros de nuevo)
        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        // Otro botón para ir a Informes (parece duplicado de btnReportes_Click)
        private void button2_Click(object sender, EventArgs e)
        {
            Informes frm = new Informes();
            frm.Show();
            this.Hide();
        }

        // Botón para exportar datos a CSV
        private void button3_Click(object sender, EventArgs e)
        {
            if (dtw_Registro.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar en el DataGridView.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        // Escribir encabezados de columna
                        for (int i = 0; i < dtw_Registro.Columns.Count; i++)
                        {
                            sw.Write(EscapeCsvField(dtw_Registro.Columns[i].HeaderText));
                            if (i < dtw_Registro.Columns.Count - 1)
                            {
                                sw.Write(",");
                            }
                        }
                        sw.WriteLine();

                        // Escribir filas de datos
                        foreach (DataGridViewRow row in dtw_Registro.Rows)
                        {
                            if (row.IsNewRow) continue; // Ignorar la fila de inserción nueva

                            for (int i = 0; i < dtw_Registro.Columns.Count; i++)
                            {
                                object cellValue = row.Cells[i].Value;
                                string cellText = (cellValue == null) ? "" : cellValue.ToString(); // Usar "" en lugar de " "
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al exportar los datos: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método auxiliar para escapar campos CSV
        private string EscapeCsvField(string field)
        {
            if (field == null) return "";

            if (field.Contains(",") || field.Contains("\"") || field.Contains(Environment.NewLine))
            {
                return $"\"{field.Replace("\"", "\"\"")}\"";
            }
            return field;
        }
    }
}