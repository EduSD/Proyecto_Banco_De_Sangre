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
            try
            {
                // Limpiar el DataTable antes de volver a llenarlo
                dt.Clear();

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
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
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
            CargarDatos();

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
                // Obtener el ID del TextBox
                if (int.TryParse(txtID.Text, out int idRegistro))
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
                                    CargarDatos(); // Recargar los datos para actualizar la tabla
                                    MessageBox.Show("Registro eliminado correctamente.");
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró ningún registro con el ID especificado.");
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa un ID válido.");
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
            CargarDatos();


            txtID.Enabled = false;
            btnConsultar.Enabled = false;
            btnEliminar.Enabled = false;

            txtnombre.Enabled = true;
            txtedad.Enabled = true;
            txtsangre.Enabled = true;
            txtlitros2.Enabled = true;

        }
        // Nos daban algunos errores en el codigo por eso el catch para excepciones
        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtID.Enabled=true;
            btnConsultar.Enabled = true;
            btnEliminar.Enabled = true;

            txtnombre.Enabled = false;
            txtedad.Enabled = false;
            txtsangre.Enabled = false;
            txtlitros2.Enabled = false;

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            
             

                try
                {
                    // Traemos los valores de los TextBox
                    string id = txtID.Text; // TextBox para el ID
                    string nombre = txtnombre.Text;
                    string edad = txtedad.Text;
                    string sangre = txtsangre.Text;
                    string litros = txtlitros2.Text;

                    // Crear la consulta SQL dinámica
                    string query = "SELECT * FROM Registros WHERE 1 = 1";

                    if (!string.IsNullOrEmpty(id))
                    {
                        query += " AND ID = @ID";
                    }

                    if (!string.IsNullOrEmpty(nombre))
                    {
                        query += " AND NOMBRE_C LIKE @Nombre";
                    }
                    if (!string.IsNullOrEmpty(edad))
                    {
                        query += " AND EDAD = @Edad";
                    }
                    if (!string.IsNullOrEmpty(sangre))
                    {
                        query += " AND T_SANGRE LIKE @Sangre";
                    }
                    if (!string.IsNullOrEmpty(litros))
                    {
                        query += " AND MILILITROS_D = @Litros";
                    }

                    // Ejecutar la consulta y cargar los datos en el DataGridView
                    using (SqlConnection conexion = new SqlConnection(conexionString))
                    {
                        conexion.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            // Agregar parámetros a la consulta
                            if (!string.IsNullOrEmpty(id))
                            {
                                cmd.Parameters.AddWithValue("@ID", id);
                            }
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
                                cmd.Parameters.AddWithValue("@Sangre", "%" + sangre + "%");
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

            txtID.Enabled = false;
            btnConsultar.Enabled = false;
            btnEliminar.Enabled = false;

            txtnombre.Enabled = true;
            txtedad.Enabled = true;
            txtsangre.Enabled = true;
            txtlitros2.Enabled = true;



        }



    }
           
}