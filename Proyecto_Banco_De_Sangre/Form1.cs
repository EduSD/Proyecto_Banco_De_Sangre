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
        private const string codigoCorrecto = "1234"; // No se me ocurrió otra, como no tenemos base de momento así csm xd

        public Form1()
        {
            InitializeComponent();
            btnentrar.Enabled = false;
            txtcode.TextChanged += txtcode_TextChanged;
            btnentrar.Click += btnentrar_Click;
        }

        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            btnentrar.Enabled = !string.IsNullOrWhiteSpace(txtcode.Text);
        }

        private void btnentrar_Click(object sender, EventArgs e)
        {
            if (txtcode.Text == codigoCorrecto)
            {
                MessageBox.Show("¡Bienvenido estimado usuario!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                intentos++;
                if (intentos >= maxIntentos)
                {
                    MessageBox.Show("Has excedido el número de intentos. Ni modo xD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Código incorrecto. Te quedan {maxIntentos - intentos} intentos. Sino recuerda su código vaya a RH por su carta de renuncia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}