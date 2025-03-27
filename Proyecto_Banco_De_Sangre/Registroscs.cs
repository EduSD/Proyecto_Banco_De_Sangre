using System;
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
        //string conexionString = "Server=L402-M6;Database=banco_sangre;Trusted_Connection=True;";
        //string conexionString = "Server=YAKUGAMER732\\SQLEXPRESS;Database=banco_sangre;Trusted_Connection=True;";
        string conexionString = "Server=DESKTOP-NC4SAIF\\SQÑEXPRESS;Database=banco_sangre;Trusted_Connection=True;";
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
            dt.Columns.Add("NOMBRE_D");
            dt.Columns.Add("EDAD");
            dt.Columns.Add("T_SANGRE");
            dt.Columns.Add("MILILITROS_D");
            dt.Columns.Add("FECHA_D");
            dtw_Registro.DataSource = dt;
            CargarDatos();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreDonante = txtnombre.Text;
                int litrosDonados = int.Parse(txtlitros2.Text);

                // Validación de cantidad de litros donados
                if (litrosDonados > 450)
                {
                    MessageBox.Show("No puedes donar más de 450 Mililitros.");
                    return;
                }

                // Validación del tiempo entre donaciones
            

                DateTime fechaDonacion = DateTime.Today;

                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();

                    // Insertar en la tabla Registros
                    string queryInsertRegistros = "INSERT INTO Registros(NOMBRE_C, EDAD, T_SANGRE, MILILITROS_D, FECHA_D) VALUES(@NOMBRE_C, @EDAD, @T_SANGRE, @MILILITROS_D, @FECHA_D)";
                    using (SqlCommand cmd = new SqlCommand(queryInsertRegistros, conexion))
                    {
                        cmd.Parameters.AddWithValue("@NOMBRE_C", nombreDonante);
                        cmd.Parameters.AddWithValue("@EDAD", int.Parse(txtedad.Text));
                        cmd.Parameters.AddWithValue("@T_SANGRE", txtsangre.Text);
                        cmd.Parameters.AddWithValue("@MILILITROS_D", litrosDonados);
                        cmd.Parameters.AddWithValue("@FECHA_D", DateTime.Now.Date);
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
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese valores numéricos en Edad y Litros.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error en la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }

            txtedad.Text = " ";
            txtlitros2.Text = " ";
            txtnombre.Text = " ";
            txtsangre.Text = "";
        }
        private void btnReportes_Click(object sender, EventArgs e)
        {
            Informes frm = new Informes(); // Cambiar a formulario de Informes
            frm.Show();
            this.Hide();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtw_Registro.SelectedRows.Count > 0)
                {
                    int idRegistro = Convert.ToInt32(dtw_Registro.SelectedRows[0].Cells["ID"].Value);

                    // Confirmación antes de eliminar
                    DialogResult resultado = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar este registro? Esta acción no se puede deshacer.",
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
                                cmd.ExecuteNonQuery();
                            }
                        }
                        CargarDatos(); // Recargar los datos para actualizar la tabla
                        MessageBox.Show("Registro eliminado correctamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un registro para eliminar.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al eliminar el registro: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }
        // Nos daban algunos errores en el codigo por eso el catch para excepciones
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtw_Registro.SelectedRows.Count > 0)
                {
                    int idRegistro = Convert.ToInt32(dtw_Registro.SelectedRows[0].Cells["ID"].Value);
                    // Mensaje de confirmación para que el enfermero que capture CONFIRME y no se equivoque
                    DialogResult resultado = MessageBox.Show(
                        "¿Desea guardar los cambios realizados en el registro seleccionado?",
                        "Confirmar modificación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (resultado == DialogResult.Yes)
                    {
                        // Deshabilitar edición mientras se guarda, porque de lo contrario colapsa
                        dtw_Registro.ReadOnly = true;
                        // Obtener los valores modificados del DataGridView para que podamos guardarlo correctamente
                        DataGridViewRow filaSeleccionada = dtw_Registro.SelectedRows[0];
                        string nombre = filaSeleccionada.Cells["Nombre"].Value.ToString();
                        int edad = Convert.ToInt32(filaSeleccionada.Cells["Edad"].Value);
                        string sangre = filaSeleccionada.Cells["Sangre"].Value.ToString();
                        string cronica = filaSeleccionada.Cells["Crónica"].Value.ToString();
                        DateTime fecha = Convert.ToDateTime(filaSeleccionada.Cells["Fecha"].Value); // Obtener la fecha modificada
                        string estado = filaSeleccionada.Cells["Estado"].Value.ToString();
                        int diasRestantes = Convert.ToInt32(filaSeleccionada.Cells["DiasRestantes"].Value);
                        // Actualizar la base de datos
                        using (SqlConnection conexion = new SqlConnection(conexionString))
                        {
                            conexion.Open();
                            string query = "UPDATE Registros SET Nombre = @Nombre, Edad = @Edad, T_Sangre = @Sangre, E_Cronica = @Cronica, Fecha = @Fecha, Estado = @Estado, DiasRestantes = @DiasRestantes WHERE ID = @ID";

                            using (SqlCommand cmd = new SqlCommand(query, conexion))
                            {
                                cmd.Parameters.AddWithValue("@ID", idRegistro);
                                cmd.Parameters.AddWithValue("@Nombre", nombre);
                                cmd.Parameters.AddWithValue("@Edad", edad);
                                cmd.Parameters.AddWithValue("@Sangre", sangre);
                                cmd.Parameters.AddWithValue("@Cronica", cronica);
                                cmd.Parameters.AddWithValue("@Fecha", fecha); // Usar la fecha modificada
                                cmd.Parameters.AddWithValue("@Estado", estado);
                                cmd.Parameters.AddWithValue("@DiasRestantes", diasRestantes);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        // Habilitar edición y actualizar DataGridView con nuestro método
                        dtw_Registro.ReadOnly = false;
                        CargarDatos();
                        MessageBox.Show("¡Excelente! La información del paciente ha sido actualizada correctamente. Gracias por su valioso trabajo.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un registro para modificar.");
                }
            // Los catch son porque en algunas ocasiones los equipos colapsaban
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, asegúrese de que los campos numéricos (Edad, DiasRestantes) contengan valores válidos.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ha ocurrido un error al intentar modificar la información. Por favor, contacte al administrador.\nDetalles: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error inesperado. Por favor, contacte al administrador.\nDetalles: {ex.Message}");
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                // Traemos los valores de los TextBox
                string nombre = txtnombre.Text;
                string edad = txtedad.Text;
                string sangre = txtsangre.Text;
                string litros = txtlitros2.Text;
                // Crear la consulta SQL dinámica
                string query = "SELECT * FROM Registros WHERE 1 = 1";
                if (!string.IsNullOrEmpty(nombre))
                {
                    query += " AND Nombre LIKE @Nombre";
                }
                if (!string.IsNullOrEmpty(edad))
                {
                    query += " AND Edad = @Edad";
                }
                if (!string.IsNullOrEmpty(sangre))
                {
                    query += " AND T_Sangre LIKE @Sangre"; // Cambio a LIKE para búsqueda parcial
                }
              
                if (!string.IsNullOrEmpty(litros))
                {
                    query += " AND Litros = @Litros";
                }
                // Ejecutar la consulta y cargar los datos en el DataGridView
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        // Agregar parámetros a la consulta
                        if (!string.IsNullOrEmpty(nombre))
                        {
                            cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                        }
                        if (!string.IsNullOrEmpty(edad))
                        {
                            cmd.Parameters.AddWithValue("@Edad", edad);
                        }
                        if (!string.IsNullOrEmpty(sangre))
                        {
                            cmd.Parameters.AddWithValue("@Sangre", "%" + sangre + "%"); // Usamos LIKE para búsqueda parcial
                        }
                      
                        if (!string.IsNullOrEmpty(litros))
                        {
                            cmd.Parameters.AddWithValue("@Litros", litros);
                        }
                        // Crear un DataTable para almacenar los resultados
                        DataTable dtConsulta = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtConsulta);
                        }
                        // Asignar el DataTable al DataGridView
                        dtw_Registro.DataSource = dtConsulta;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ha ocurrido un error al realizar la consulta. Por favor, contacte al administrador.\nDetalles: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error inesperado. Por favor, contacte al administrador.\nDetalles: {ex.Message}");
            }
        }
    }
           
}