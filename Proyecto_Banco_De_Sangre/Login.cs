using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Banco_De_Sangre
{
   public partial class Login : Form
    {
        private int intentos = 0;
        private const int maxIntentos = 4;

        // Variable privada para almacenar el usuario
        private string _usuario;

        // Propiedad pública para acceder al valor del TextBox
        public string Usuario
        {
            get { return _usuario ?? txtcode.Text; }
            set { _usuario = value; }
        }

        public Login()
        {
            InitializeComponent();
            btnentrar.Enabled = false;
            txtcode.TextChanged += txtcode_TextChanged;

            // Actualizar la variable cuando cambie el texto
            txtcode.TextChanged += (sender, e) => Usuario = txtcode.Text;
        }

        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            btnentrar.Enabled = !string.IsNullOrWhiteSpace(txtcode.Text);
        }

        private void btnentrar_Click(object sender, EventArgs e)
        {


          

            // Usando la variable Usuario en lugar de txtcode.Text
            if (Usuario == "1234")
            {
                MessageBox.Show("¡Bienvenido estimado usuario!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Registroscs frm = new Registroscs();
                frm.Show();
                this.Hide();
            }
            else
            {
                intentos++;
                if (intentos >= maxIntentos)
                {
                    MessageBox.Show("Has excedido el número de intentos.\n Favor de llamar a un supervisor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Estimado usuario, su código es incorrecto. Te quedan {maxIntentos - intentos} intentos. Sino recuerda su código vaya a RH por soporte para su código", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }

}