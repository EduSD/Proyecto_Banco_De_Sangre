
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
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tSangreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eCronicaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D_Restantes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registrosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.banco_sangreDataSet = new Proyecto_Banco_De_Sangre.banco_sangreDataSet();
            this.registrosTableAdapter = new Proyecto_Banco_De_Sangre.banco_sangreDataSetTableAdapters.RegistrosTableAdapter();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtedad = new System.Windows.Forms.TextBox();
            this.txtsangre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtcronica = new System.Windows.Forms.ComboBox();
            this.consulta = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
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
            this.dtw_Registro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtw_Registro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.edadDataGridViewTextBoxColumn,
            this.tSangreDataGridViewTextBoxColumn,
            this.eCronicaDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.D_Restantes});
            this.dtw_Registro.DataSource = this.registrosBindingSource;
            this.dtw_Registro.Location = new System.Drawing.Point(12, 172);
            this.dtw_Registro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtw_Registro.Name = "dtw_Registro";
            this.dtw_Registro.RowHeadersWidth = 51;
            this.dtw_Registro.RowTemplate.Height = 24;
            this.dtw_Registro.Size = new System.Drawing.Size(940, 260);
            this.dtw_Registro.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
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
            // eCronicaDataGridViewTextBoxColumn
            // 
            this.eCronicaDataGridViewTextBoxColumn.DataPropertyName = "E_Cronica";
            this.eCronicaDataGridViewTextBoxColumn.HeaderText = "Enfermedad Crónica";
            this.eCronicaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.eCronicaDataGridViewTextBoxColumn.Name = "eCronicaDataGridViewTextBoxColumn";
            this.eCronicaDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.Width = 125;
            // 
            // D_Restantes
            // 
            this.D_Restantes.DataPropertyName = "ID";
            this.D_Restantes.HeaderText = "Días Restantes";
            this.D_Restantes.MinimumWidth = 6;
            this.D_Restantes.Name = "D_Restantes";
            this.D_Restantes.Width = 125;
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
            this.txtnombre.Location = new System.Drawing.Point(18, 73);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnombre.Location = new System.Drawing.Point(28, 75);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnombre.Location = new System.Drawing.Point(25, 98);
=========
            this.txtnombre.Location = new System.Drawing.Point(18, 73);
>>>>>>>>> Temporary merge branch 2
            this.txtnombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(168, 22);
            this.txtnombre.TabIndex = 2;
            // 
            // txtedad
            // 
            this.txtedad.Location = new System.Drawing.Point(232, 75);
            this.txtedad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtedad.Name = "txtedad";
            this.txtedad.Size = new System.Drawing.Size(73, 22);
            this.txtedad.TabIndex = 3;
            // 
            // txtsangre
            // 
            this.txtsangre.FormattingEnabled = true;
            this.txtsangre.Items.AddRange(new object[] {
            "A+",
            "A-",
            this.txtsangre.Location = new System.Drawing.Point(382, 71);
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"});
<<<<<<<<< Temporary merge branch 1
            this.txtsangre.Location = new System.Drawing.Point(389, 96);
=========
            this.label1.Location = new System.Drawing.Point(58, 29);
>>>>>>>>> Temporary merge branch 2
            this.txtsangre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtsangre.Name = "txtsangre";
            this.txtsangre.Size = new System.Drawing.Size(103, 24);
            this.txtsangre.TabIndex = 7;
            // 
            // label1
            // 
            this.label2.Location = new System.Drawing.Point(244, 33);
<<<<<<<<< Temporary merge branch 1
            this.label1.Location = new System.Drawing.Point(21, 58);
            this.label1.Location = new System.Drawing.Point(65, 54);
=========
            this.label1.Location = new System.Drawing.Point(58, 29);
>>>>>>>>> Temporary merge branch 2
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label3.Location = new System.Drawing.Point(382, 32);
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
<<<<<<<<< Temporary merge branch 1
            this.label2.Location = new System.Drawing.Point(251, 58);
=========
            this.label2.Location = new System.Drawing.Point(244, 33);
>>>>>>>>> Temporary merge branch 2
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Edad";
            // 
            // label3
            this.button1.Location = new System.Drawing.Point(694, 110);
            this.label3.AutoSize = true;
<<<<<<<<< Temporary merge branch 1
            this.label3.Location = new System.Drawing.Point(389, 57);
=========
            this.label3.Location = new System.Drawing.Point(382, 32);
>>>>>>>>> Temporary merge branch 2
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tipo de Sangre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.txtcronica.Location = new System.Drawing.Point(565, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Enfermedad Cronica";
            // 
            // button1
            // 
<<<<<<<<< Temporary merge branch 1
            this.button1.Location = new System.Drawing.Point(699, 151);
=========
            this.button1.Location = new System.Drawing.Point(694, 110);
>>>>>>>>> Temporary merge branch 2
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 39);
            this.button1.TabIndex = 12;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtcronica
            // 
            this.txtcronica.FormattingEnabled = true;
            this.txtcronica.Items.AddRange(new object[] {
            "Si",
            "No"});
<<<<<<<<< Temporary merge branch 1
            this.txtcronica.Location = new System.Drawing.Point(572, 98);
=========
            this.txtcronica.Location = new System.Drawing.Point(565, 73);
>>>>>>>>> Temporary merge branch 2
            this.txtcronica.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtcronica.Name = "txtcronica";
            this.txtcronica.Size = new System.Drawing.Size(134, 24);
            this.txtcronica.TabIndex = 13;
            // 
            // consulta
            // 
            this.consulta.Location = new System.Drawing.Point(854, 58);
            this.consulta.Name = "consulta";
            this.consulta.Size = new System.Drawing.Size(98, 39);
            this.consulta.TabIndex = 14;
            this.consulta.Text = "Consultar";
            this.consulta.UseVisualStyleBackColor = true;
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(812, 451);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(87, 37);
            this.btnReporte.TabIndex = 15;
            this.btnReporte.Text = "Reportes";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(851, 63);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(101, 39);
            this.btnConsultar.TabIndex = 16;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(744, 63);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(101, 39);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // Registroscs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(964, 513);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.txtcronica);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox txtcronica;
        private System.Windows.Forms.Button consulta;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn edadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tSangreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eCronicaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn D_Restantes;
        private System.Windows.Forms.Button btnEliminar;
    }
}