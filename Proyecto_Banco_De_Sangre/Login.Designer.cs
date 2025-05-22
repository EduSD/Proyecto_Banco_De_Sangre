
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
            this.lblusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblusuario.Location = new System.Drawing.Point(405, 236);
            this.lblusuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(212, 20);
            this.lblusuario.TabIndex = 0;
            this.lblusuario.Text = "Escriba su código de usuario";
            this.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.BackColor = System.Drawing.Color.Transparent;
            this.lbltitulo.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbltitulo.Location = new System.Drawing.Point(218, 145);
            this.lbltitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(601, 60);
            this.lbltitulo.TabIndex = 1;
            this.lbltitulo.Text = "Banco de Sangre \"La Merced\"";
            this.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtcode
            // 
            this.txtcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcode.Location = new System.Drawing.Point(421, 280);
            this.txtcode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtcode.Name = "txtcode";
            this.txtcode.PasswordChar = '*';
            this.txtcode.Size = new System.Drawing.Size(154, 23);
            this.txtcode.TabIndex = 2;
            this.txtcode.TextChanged += new System.EventHandler(this.txtcode_TextChanged);
            // 
            // btnentrar
            // 
            this.btnentrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnentrar.Location = new System.Drawing.Point(469, 335);
            this.btnentrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnentrar.Name = "btnentrar";
            this.btnentrar.Size = new System.Drawing.Size(56, 29);
            this.btnentrar.TabIndex = 3;
            this.btnentrar.Text = "Entrar";
            this.btnentrar.UseVisualStyleBackColor = true;
            this.btnentrar.Click += new System.EventHandler(this.btnentrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 18F);
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(266, 465);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 4;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QR
            // 
            this.QR.Image = ((System.Drawing.Image)(resources.GetObject("QR.Image")));
            this.QR.Location = new System.Drawing.Point(898, 465);
            this.QR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.QR.Name = "QR";
            this.QR.Size = new System.Drawing.Size(104, 111);
            this.QR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.QR.TabIndex = 5;
            this.QR.TabStop = false;
            // 
            // lblInvitación
            // 
            this.lblInvitación.AutoSize = true;
            this.lblInvitación.BackColor = System.Drawing.Color.Transparent;
            this.lblInvitación.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvitación.Location = new System.Drawing.Point(782, 501);
            this.lblInvitación.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInvitación.Name = "lblInvitación";
            this.lblInvitación.Size = new System.Drawing.Size(118, 40);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1011, 586);
            this.Controls.Add(this.lblInvitación);
            this.Controls.Add(this.QR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnentrar);
            this.Controls.Add(this.txtcode);
            this.Controls.Add(this.lbltitulo);
            this.Controls.Add(this.lblusuario);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Login";
            this.Text = "Inicio de Sesión";
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

