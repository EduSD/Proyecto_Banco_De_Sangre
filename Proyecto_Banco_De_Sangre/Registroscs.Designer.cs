
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
            this.dATOSDataSet = new Proyecto_Banco_De_Sangre.DATOSDataSet();
            this.aLUMNOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aLUMNOSTableAdapter = new Proyecto_Banco_De_Sangre.DATOSDataSetTableAdapters.ALUMNOSTableAdapter();
            this.dtw_Registro = new System.Windows.Forms.DataGridView();
            this.registrosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.banco_sangreDataSet = new Proyecto_Banco_De_Sangre.banco_sangreDataSet();
            this.registrosTableAdapter = new Proyecto_Banco_De_Sangre.banco_sangreDataSetTableAdapters.RegistrosTableAdapter();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtedad = new System.Windows.Forms.TextBox();
            this.txtsangre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtlitros = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtlitros2 = new System.Windows.Forms.TextBox();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tSangreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MILILITROS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dATOSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLUMNOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtw_Registro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banco_sangreDataSet)).BeginInit();
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
            this.dtw_Registro.ColumnHeadersHeight = 29;
            this.dtw_Registro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.edadDataGridViewTextBoxColumn,
            this.tSangreDataGridViewTextBoxColumn,
            this.MILILITROS,
            this.fechaDataGridViewTextBoxColumn});
            this.dtw_Registro.DataSource = this.registrosBindingSource;
            this.dtw_Registro.Location = new System.Drawing.Point(12, 223);
            this.dtw_Registro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtw_Registro.Name = "dtw_Registro";
            this.dtw_Registro.RowHeadersWidth = 51;
            this.dtw_Registro.RowTemplate.Height = 24;
            this.dtw_Registro.Size = new System.Drawing.Size(1142, 260);
            this.dtw_Registro.TabIndex = 0;
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
            this.txtnombre.Location = new System.Drawing.Point(26, 157);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(197, 22);
            this.txtnombre.TabIndex = 2;
            // 
            // txtedad
            // 
            this.txtedad.Location = new System.Drawing.Point(252, 157);
            this.txtedad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtedad.Name = "txtedad";
            this.txtedad.Size = new System.Drawing.Size(39, 22);
            this.txtedad.TabIndex = 3;
            // 
            // txtsangre
            // 
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
            this.txtsangre.Location = new System.Drawing.Point(308, 157);
            this.txtsangre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtsangre.Name = "txtsangre";
            this.txtsangre.Size = new System.Drawing.Size(103, 24);
            this.txtsangre.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre Completo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Edad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tipo de Sangre";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(580, 149);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(77, 39);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(993, 149);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(77, 39);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1051, 505);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 52);
            this.button2.TabIndex = 15;
            this.button2.Text = "Reportes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // txtlitros
            // 
            this.txtlitros.AutoSize = true;
            this.txtlitros.Location = new System.Drawing.Point(476, 108);
            this.txtlitros.Name = "txtlitros";
            this.txtlitros.Size = new System.Drawing.Size(58, 17);
            this.txtlitros.TabIndex = 16;
            this.txtlitros.Text = "Mililitros";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Enabled = false;
            this.btnConsultar.Location = new System.Drawing.Point(867, 149);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(77, 39);
            this.btnConsultar.TabIndex = 18;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(724, 65);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(77, 39);
            this.btnModificar.TabIndex = 19;
            this.btnModificar.Text = "Habilitar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtlitros2
            // 
            this.txtlitros2.Location = new System.Drawing.Point(473, 157);
            this.txtlitros2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtlitros2.Name = "txtlitros2";
            this.txtlitros2.Size = new System.Drawing.Size(47, 22);
            this.txtlitros2.TabIndex = 20;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre_C";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre_C";
            this.nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.Width = 125;
            // 
            // edadDataGridViewTextBoxColumn
            // 
            this.edadDataGridViewTextBoxColumn.DataPropertyName = "Edad";
            this.edadDataGridViewTextBoxColumn.HeaderText = "Edad";
            this.edadDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.edadDataGridViewTextBoxColumn.Name = "edadDataGridViewTextBoxColumn";
            this.edadDataGridViewTextBoxColumn.Width = 125;
            // 
            // tSangreDataGridViewTextBoxColumn
            // 
            this.tSangreDataGridViewTextBoxColumn.DataPropertyName = "T_Sangre";
            this.tSangreDataGridViewTextBoxColumn.HeaderText = "Tipo de Sangre";
            this.tSangreDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tSangreDataGridViewTextBoxColumn.Name = "tSangreDataGridViewTextBoxColumn";
            this.tSangreDataGridViewTextBoxColumn.Width = 125;
            // 
            // MILILITROS
            // 
            this.MILILITROS.DataPropertyName = "MILILITROS_D";
            this.MILILITROS.HeaderText = "Mililitros";
            this.MILILITROS.MinimumWidth = 6;
            this.MILILITROS.Name = "MILILITROS";
            this.MILILITROS.Width = 125;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha_D";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha_D";
            this.fechaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.Width = 125;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(908, 82);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 22);
            this.txtID.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Agrege el ID";
            // 
            // Registroscs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 568);
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
            this.Text = "Registroscs";
            this.Load += new System.EventHandler(this.Registroscs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dATOSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLUMNOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtw_Registro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banco_sangreDataSet)).EndInit();
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
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label txtlitros;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtlitros2;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn edadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tSangreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MILILITROS;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label4;
    }
}