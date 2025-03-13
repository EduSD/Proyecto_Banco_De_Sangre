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
                int litrosDonados = int.Parse(txtlitros.Text);
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
                                MessageBox.Show($"Aún no puedes donar. Debes esperar {tiempoRestante.Days} días para que tu cuerpo se recupere completamente.");
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
                    int idRegistro = Convert.ToInt32(dtw_Registro.SelectedRows[0].Cells["ID"].Value);

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
                    MessageBox.Show("Registro eliminado correctamente.");
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
    }
}