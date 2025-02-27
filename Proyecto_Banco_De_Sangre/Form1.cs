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
    public partial class Form1 : Form
    {
        private int intentos = 0;
        private const int maxIntentos = 4;
        

        public Form1()
        {
            InitializeComponent();
            btnentrar.Enabled = false;
            txtcode.TextChanged += txtcode_TextChanged;
           
        }

        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            btnentrar.Enabled = !string.IsNullOrWhiteSpace(txtcode.Text);
        }

        private void btnentrar_Click(object sender, EventArgs e)
        {
            if (txtcode.Text == "1234") //validacion para ingreso de usuario
            {
                MessageBox.Show("¡Bienvenido estimado usuario!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Registroscs frm = new Registroscs();
                frm.Show();
                this.Hide();
            }

            else //Negativa  en caso de la contraseña estar mal
            {
                intentos++;
                if (intentos >= maxIntentos) // validacion para determinar una cantidad de intentos 
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
    }
}