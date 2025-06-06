
namespace Proyecto_Banco_De_Sangre
{
    partial class Registroscs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registroscs));
            this.dATOSDataSet = new Proyecto_Banco_De_Sangre.DATOSDataSet();
            this.aLUMNOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aLUMNOSTableAdapter = new Proyecto_Banco_De_Sangre.DATOSDataSetTableAdapters.ALUMNOSTableAdapter();
            this.dtw_Registro = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tSangreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MILILITROS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registrosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.banco_sangreDataSet = new Proyecto_Banco_De_Sangre.banco_sangreDataSet();
            this.registrosTableAdapter = new Proyecto_Banco_De_Sangre.banco_sangreDataSetTableAdapters.RegistrosTableAdapter();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtedad = new System.Windows.Forms.TextBox();
            this.txtsangre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtlitros = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtlitros2 = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider4 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider5 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lblbajo = new System.Windows.Forms.StatusStrip();
            this.lblMensajeEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFechaHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dATOSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLUMNOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtw_Registro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banco_sangreDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).BeginInit();
            this.lblbajo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dATOSDataSet
            // 
            this.dATOSDataSet.DataSetName = "DATOSDataSet";
            this.dATOSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aLUMNOSBindingSource
            // 
            this.aLUMNOSBindingSource.DataMember = "ALUMNOS";
            this.aLUMNOSBindingSource.DataSource = this.dATOSDataSet;
            // 
            // aLUMNOSTableAdapter
            // 
            this.aLUMNOSTableAdapter.ClearBeforeFill = true;
            // 
            // dtw_Registro
            // 
            this.dtw_Registro.AllowUserToOrderColumns = true;
            this.dtw_Registro.AutoGenerateColumns = false;
            this.dtw_Registro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtw_Registro.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtw_Registro.BackgroundColor = System.Drawing.Color.Azure;
            this.dtw_Registro.ColumnHeadersHeight = 29;
            this.dtw_Registro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.NOMBRE_C,
            this.edadDataGridViewTextBoxColumn,
            this.tSangreDataGridViewTextBoxColumn,
            this.MILILITROS,
            this.FECHA_D});
            this.dtw_Registro.DataSource = this.registrosBindingSource;
            this.dtw_Registro.Location = new System.Drawing.Point(12, 186);
            this.dtw_Registro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtw_Registro.Name = "dtw_Registro";
            this.dtw_Registro.RowHeadersWidth = 51;
            this.dtw_Registro.RowTemplate.Height = 24;
            this.dtw_Registro.Size = new System.Drawing.Size(959, 269);
            this.dtw_Registro.StandardTab = true;
            this.dtw_Registro.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 50;
            // 
            // NOMBRE_C
            // 
            this.NOMBRE_C.DataPropertyName = "NOMBRE_C";
            this.NOMBRE_C.HeaderText = "Nombre";
            this.NOMBRE_C.MinimumWidth = 6;
            this.NOMBRE_C.Name = "NOMBRE_C";
            this.NOMBRE_C.Width = 87;
            // 
            // edadDataGridViewTextBoxColumn
            // 
            this.edadDataGridViewTextBoxColumn.DataPropertyName = "Edad";
            this.edadDataGridViewTextBoxColumn.HeaderText = "Año de Nacimiento";
            this.edadDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.edadDataGridViewTextBoxColumn.Name = "edadDataGridViewTextBoxColumn";
            this.edadDataGridViewTextBoxColumn.Width = 156;
            // 
            // tSangreDataGridViewTextBoxColumn
            // 
            this.tSangreDataGridViewTextBoxColumn.DataPropertyName = "T_Sangre";
            this.tSangreDataGridViewTextBoxColumn.HeaderText = "Tipo de Sangre";
            this.tSangreDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tSangreDataGridViewTextBoxColumn.Name = "tSangreDataGridViewTextBoxColumn";
            this.tSangreDataGridViewTextBoxColumn.Width = 135;
            // 
            // MILILITROS
            // 
            this.MILILITROS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MILILITROS.DataPropertyName = "MILILITROS_D";
            this.MILILITROS.HeaderText = "Cantidad Donada (ml)";
            this.MILILITROS.MinimumWidth = 6;
            this.MILILITROS.Name = "MILILITROS";
            this.MILILITROS.Width = 175;
            // 
            // FECHA_D
            // 
            this.FECHA_D.DataPropertyName = "FECHA_D";
            this.FECHA_D.HeaderText = "Fecha de Donaciòn";
            this.FECHA_D.MinimumWidth = 6;
            this.FECHA_D.Name = "FECHA_D";
            this.FECHA_D.Width = 160;
            // 
            // registrosBindingSource
            // 
            this.registrosBindingSource.DataMember = "Registros";
            this.registrosBindingSource.DataSource = this.banco_sangreDataSet;
            // 
            // banco_sangreDataSet
            // 
            this.banco_sangreDataSet.DataSetName = "banco_sangreDataSet";
            this.banco_sangreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // registrosTableAdapter
            // 
            this.registrosTableAdapter.ClearBeforeFill = true;
            // 
            // txtnombre
            // 
            this.txtnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombre.Location = new System.Drawing.Point(29, 62);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(287, 27);
            this.txtnombre.TabIndex = 2;
            // 
            // txtedad
            // 
            this.txtedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtedad.Location = new System.Drawing.Point(347, 62);
            this.txtedad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtedad.MaxLength = 4;
            this.txtedad.Name = "txtedad";
            this.txtedad.Size = new System.Drawing.Size(103, 27);
            this.txtedad.TabIndex = 0;
            this.txtedad.TextChanged += new System.EventHandler(this.txtedad_TextChanged);
            this.txtedad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtedad_KeyPress);
            // 
            // txtsangre
            // 
            this.txtsangre.BackColor = System.Drawing.Color.White;
            this.txtsangre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsangre.FormattingEnabled = true;
            this.txtsangre.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"});
            this.txtsangre.Location = new System.Drawing.Point(529, 61);
            this.txtsangre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtsangre.Name = "txtsangre";
            this.txtsangre.Size = new System.Drawing.Size(113, 28);
            this.txtsangre.TabIndex = 7;
            this.txtsangre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsangre_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre Completo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(323, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Año de Nacimiento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(524, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tipo de Sangre";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Aquamarine;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEliminar.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(1068, 165);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(117, 63);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGray;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1144, 475);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 47);
            this.button2.TabIndex = 15;
            this.button2.Text = "Ventana Reportes";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtlitros
            // 
            this.txtlitros.AutoSize = true;
            this.txtlitros.BackColor = System.Drawing.Color.Transparent;
            this.txtlitros.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlitros.Location = new System.Drawing.Point(695, 28);
            this.txtlitros.Name = "txtlitros";
            this.txtlitros.Size = new System.Drawing.Size(80, 20);
            this.txtlitros.TabIndex = 16;
            this.txtlitros.Text = "Mililitros";
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.Aquamarine;
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.Enabled = false;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConsultar.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Location = new System.Drawing.Point(1068, 245);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(117, 63);
            this.btnConsultar.TabIndex = 18;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click_1);
            // 
            // txtlitros2
            // 
            this.txtlitros2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlitros2.Location = new System.Drawing.Point(691, 62);
            this.txtlitros2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtlitros2.Name = "txtlitros2";
            this.txtlitros2.Size = new System.Drawing.Size(76, 27);
            this.txtlitros2.TabIndex = 3;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(1052, 123);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(148, 27);
            this.txtID.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1071, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Agregue el ID";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Aquamarine;
            this.button1.BackgroundImage = global::Proyecto_Banco_De_Sangre.Properties.Resources.WhatsApp_Image_2025_05_04_at_8_21_48_PM;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Proyecto_Banco_De_Sangre.Properties.Resources.WhatsApp_Image_2025_05_04_at_8_21_48_PM;
            this.button1.Location = new System.Drawing.Point(12, 475);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 47);
            this.button1.TabIndex = 24;
            this.button1.Text = "Actualizar Tabla";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Aquamarine;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1068, 322);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 63);
            this.button3.TabIndex = 25;
            this.button3.Text = "Generar Reporte";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // errorProvider4
            // 
            this.errorProvider4.ContainerControl = this;
            // 
            // errorProvider5
            // 
            this.errorProvider5.ContainerControl = this;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAgregar.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(658, 116);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(109, 42);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Aquamarine;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnModificar.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(909, 116);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(115, 39);
            this.btnModificar.TabIndex = 19;
            this.btnModificar.Text = "Habilitar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click_1);
            // 
            // lblbajo
            // 
            this.lblbajo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.lblbajo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensajeEstado,
            this.lblFechaHora});
            this.lblbajo.Location = new System.Drawing.Point(0, 570);
            this.lblbajo.Name = "lblbajo";
            this.lblbajo.Size = new System.Drawing.Size(1273, 26);
            this.lblbajo.TabIndex = 26;
            this.lblbajo.Text = "Listo";
            // 
            // lblMensajeEstado
            // 
            this.lblMensajeEstado.Name = "lblMensajeEstado";
            this.lblMensajeEstado.Size = new System.Drawing.Size(37, 20);
            this.lblMensajeEstado.Text = "listo";
            this.lblMensajeEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(151, 20);
            this.lblFechaHora.Text = "toolStripStatusLabel3";
            this.lblFechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Registroscs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1273, 596);
            this.Controls.Add(this.lblbajo);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtlitros2);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.txtlitros);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtsangre);
            this.Controls.Add(this.txtedad);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.dtw_Registro);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Registroscs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registroscs";
            this.Load += new System.EventHandler(this.Registroscs_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dATOSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLUMNOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtw_Registro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banco_sangreDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).EndInit();
            this.lblbajo.ResumeLayout(false);
            this.lblbajo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DATOSDataSet dATOSDataSet;
        private System.Windows.Forms.BindingSource aLUMNOSBindingSource;
        private DATOSDataSetTableAdapters.ALUMNOSTableAdapter aLUMNOSTableAdapter;
        private System.Windows.Forms.DataGridView dtw_Registro;
        private banco_sangreDataSet banco_sangreDataSet;
        private System.Windows.Forms.BindingSource registrosBindingSource;
        private banco_sangreDataSetTableAdapters.RegistrosTableAdapter registrosTableAdapter;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtedad;
        private System.Windows.Forms.ComboBox txtsangre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label txtlitros;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtlitros2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Windows.Forms.ErrorProvider errorProvider4;
        private System.Windows.Forms.ErrorProvider errorProvider5;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn edadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tSangreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MILILITROS;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_D;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.StatusStrip lblbajo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel lblMensajeEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblFechaHora;
    }
}