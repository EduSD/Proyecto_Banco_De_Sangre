
namespace Proyecto_Banco_De_Sangre
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lblusuario = new System.Windows.Forms.Label();
            this.lbltitulo = new System.Windows.Forms.Label();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.btnentrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.QR = new System.Windows.Forms.PictureBox();
            this.lblInvitación = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.QR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.Color.Transparent;
            this.lblusuario.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblusuario.Location = new System.Drawing.Point(374, 187);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(267, 23);
            this.lblusuario.TabIndex = 0;
            this.lblusuario.Text = "Escriba su código de usuario";
            this.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.BackColor = System.Drawing.Color.Transparent;
            this.lbltitulo.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbltitulo.Location = new System.Drawing.Point(144, 76);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(927, 73);
            this.lbltitulo.TabIndex = 1;
            this.lbltitulo.Text = "Banco de Sangre \"La Merced\"";
            this.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtcode
            // 
            this.txtcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcode.Location = new System.Drawing.Point(405, 242);
            this.txtcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtcode.Name = "txtcode";
            this.txtcode.PasswordChar = '*';
            this.txtcode.Size = new System.Drawing.Size(204, 27);
            this.txtcode.TabIndex = 2;
            this.txtcode.TextChanged += new System.EventHandler(this.txtcode_TextChanged);
            // 
            // btnentrar
            // 
            this.btnentrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnentrar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnentrar.FlatAppearance.BorderSize = 15;
            this.btnentrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnentrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnentrar.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnentrar.Image = global::Proyecto_Banco_De_Sangre.Properties.Resources._146805;
            this.btnentrar.ImageKey = "(ninguno)";
            this.btnentrar.Location = new System.Drawing.Point(454, 307);
            this.btnentrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnentrar.Name = "btnentrar";
            this.btnentrar.Size = new System.Drawing.Size(107, 36);
            this.btnentrar.TabIndex = 3;
            this.btnentrar.Text = "Entrar";
            this.btnentrar.UseVisualStyleBackColor = false;
            this.btnentrar.Click += new System.EventHandler(this.btnentrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 18F);
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(355, 572);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 37);
            this.label1.TabIndex = 4;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QR
            // 
            this.QR.Image = ((System.Drawing.Image)(resources.GetObject("QR.Image")));
            this.QR.Location = new System.Drawing.Point(932, 407);
            this.QR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.QR.Name = "QR";
            this.QR.Size = new System.Drawing.Size(139, 137);
            this.QR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.QR.TabIndex = 5;
            this.QR.TabStop = false;
            // 
            // lblInvitación
            // 
            this.lblInvitación.AutoSize = true;
            this.lblInvitación.BackColor = System.Drawing.Color.Transparent;
            this.lblInvitación.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvitación.Location = new System.Drawing.Point(778, 452);
            this.lblInvitación.Name = "lblInvitación";
            this.lblInvitación.Size = new System.Drawing.Size(149, 50);
            this.lblInvitación.TabIndex = 6;
            this.lblInvitación.Text = "¿Quieres invitar\r\na alguien?";
            this.lblInvitación.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1097, 547);
            this.Controls.Add(this.lblInvitación);
            this.Controls.Add(this.QR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnentrar);
            this.Controls.Add(this.txtcode);
            this.Controls.Add(this.lbltitulo);
            this.Controls.Add(this.lblusuario);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesión";
            this.Load += new System.EventHandler(this.Login_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.QR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.Button btnentrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox QR;
        private System.Windows.Forms.Label lblInvitación;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

