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
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreDonante = txtnombre.Text;
                int litrosDonados = int.Parse(txtlitros2.Text);
                // Aquí validamos los "litros" a donar
                if (litrosDonados > 0.5)
                {
                    MessageBox.Show("Recuerda que los pacientes n puedes donar más de 0.5 litros de sangre por donación. Por favor, verifica la cantidad ingresada.");
                    return;
                }
                // Validación del sistema, en busca de donaciones previas
                if (!PuedeDonar(nombreDonante))
                {
                    return;
                }
                // Si pasa las validaciones anteriores en este punto, procede a agregar el registro
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    string query = "INSERT INTO Registros (ID, Nombre, Edad, T_Sangre, E_Cronica, Fecha, Litros, Estado, S_Caducidad) VALUES (@ID, @Nombre, @Edad, @Sangre, @Cronica, @Fecha, @Litros, @Estado, @S_Caducidad)";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@ID", id++);
                        cmd.Parameters.AddWithValue("@Nombre", nombreDonante);
                        cmd.Parameters.AddWithValue("@Edad", int.Parse(txtedad.Text));
                        cmd.Parameters.AddWithValue("@Sangre", txtsangre.Text);
                        cmd.Parameters.AddWithValue("@Cronica", txtcronica.Text);
                        cmd.Parameters.AddWithValue("@Fecha", DateTime.Today);
                        cmd.Parameters.AddWithValue("@Litros", litrosDonados);
                        cmd.Parameters.AddWithValue("@Estado", "Donado");
                        cmd.Parameters.AddWithValue("@S_Caducidad", DateTime.Today.AddDays(42));
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarDatos();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos en los campos de Edad y Litros. Asegúrate de que no haya letras o símbolos.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al registrar la donación. Por favor, verifica la conexión a la base de datos o contacta al administrador.\nDetalles del error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado al procesar la donación. Por favor, intenta nuevamente o contacta al administrador.\nDetalles del error: {ex.Message}");
            }
        }
        private bool PuedeDonar(string nombreDonante)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    string query = "SELECT MAX(Fecha) FROM Registros WHERE Nombre = @Nombre";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombreDonante);
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != DBNull.Value && resultado != null)
                        {
                            DateTime ultimaDonacion = Convert.ToDateTime(resultado);
                            DateTime proximaDonacionPermitida = ultimaDonacion.AddDays(56);
                            if (DateTime.Today < proximaDonacionPermitida)
                            {
                                TimeSpan tiempoRestante = proximaDonacionPermitida - DateTime.Today;
                                MessageBox.Show($"El paciente aún no puede donar. Debe esperar {tiempoRestante.Days} días para que su cuerpo se recupere completamente.");
                                return false;
                            }
                        }
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al verificar donaciones previas. Por favor, verifica la conexión a la base de datos o contacta al administrador de TI.\nDetalles del error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado al verificar donaciones previas. Por favor, contacta al administrador de TI.\nDetalles del error: {ex.Message}");
                return false;
            }
        }
        private void btnReportes_Click(object sender, EventArgs e)
        {
            Informes frm = new Informes(); // Cambiar a form de Informes
            frm.Show();
            this.Hide();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtw_Registro.SelectedRows.Count > 0)
                {
                    int idRegistro = Convert.ToInt32(dtw_Registro.SelectedRows[0].Cells["Nombre"].Value);

                    // Mensaje de confirmación para evitar pérdidas de registros NO planeadas
                    DialogResult resultado = MessageBox.Show(
                        "Espera ¿Estás seguro de que deseas eliminar este registro? Recuerda que esta acción no se puede deshacer.",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
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
                        CargarDatos();
                        MessageBox.Show("Registro eliminado correctamente. Gracias por tu atención.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un registro para eliminar.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al eliminar el registro. Por favor, contacta al administrador.\nDetalles del error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado al eliminar el registro. Por favor, intenta nuevamente o contacta al administrador.\nDetalles del error: {ex.Message}");
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
                string cronica = txtcronica.Text;
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
                if (!string.IsNullOrEmpty(cronica))
                {
                    query += " AND E_Cronica LIKE @Cronica"; // Cambio a LIKE para búsqueda parcial
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
                        if (!string.IsNullOrEmpty(cronica))
                        {
                            cmd.Parameters.AddWithValue("@Cronica", "%" + cronica + "%"); // Usamos LIKE para búsqueda parcial
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