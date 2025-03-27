
namespace Proyecto_Banco_De_Sangre
{
    partial class Informes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Informes));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtw_Informes = new System.Windows.Forms.DataGridView();
            this.sangreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.banco_sangreDataSet1 = new Proyecto_Banco_De_Sangre.banco_sangreDataSet1();
            this.bancosangreDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.banco_sangreDataSet = new Proyecto_Banco_De_Sangre.banco_sangreDataSet();
            this.registrosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.registrosTableAdapter = new Proyecto_Banco_De_Sangre.banco_sangreDataSetTableAdapters.RegistrosTableAdapter();
            this.registrosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sangreTableAdapter = new Proyecto_Banco_De_Sangre.banco_sangreDataSet1TableAdapters.SangreTableAdapter();
            this.Litrostotales = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tSangreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fRHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.litrosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtw_Informes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sangreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banco_sangreDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bancosangreDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banco_sangreDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrosBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Sangre";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"});
            this.comboBox1.Location = new System.Drawing.Point(-3, 130);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1091, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "                     ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dtw_Informes
            // 
            this.dtw_Informes.AutoGenerateColumns = false;
            this.dtw_Informes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtw_Informes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tSangreDataGridViewTextBoxColumn,
            this.fRHDataGridViewTextBoxColumn,
            this.fechaCDataGridViewTextBoxColumn,
            this.litrosDataGridViewTextBoxColumn});
            this.dtw_Informes.DataSource = this.sangreBindingSource;
            this.dtw_Informes.Location = new System.Drawing.Point(152, 301);
            this.dtw_Informes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtw_Informes.Name = "dtw_Informes";
            this.dtw_Informes.RowHeadersWidth = 51;
            this.dtw_Informes.RowTemplate.Height = 24;
            this.dtw_Informes.Size = new System.Drawing.Size(933, 319);
            this.dtw_Informes.TabIndex = 3;
            this.dtw_Informes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtw_Informes_CellContentClick);
            // 
            // sangreBindingSource
            // 
            this.sangreBindingSource.DataMember = "Sangre";
            this.sangreBindingSource.DataSource = this.banco_sangreDataSet1;
            // 
            // banco_sangreDataSet1
            // 
            this.banco_sangreDataSet1.DataSetName = "banco_sangreDataSet1";
            this.banco_sangreDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bancosangreDataSetBindingSource
            // 
            this.bancosangreDataSetBindingSource.DataSource = this.banco_sangreDataSet;
            this.bancosangreDataSetBindingSource.Position = 0;
            // 
            // banco_sangreDataSet
            // 
            this.banco_sangreDataSet.DataSetName = "banco_sangreDataSet";
            this.banco_sangreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // registrosBindingSource
            // 
            this.registrosBindingSource.DataMember = "Registros";
            this.registrosBindingSource.DataSource = this.banco_sangreDataSet;
            // 
            // registrosTableAdapter
            // 
            this.registrosTableAdapter.ClearBeforeFill = true;
            // 
            // registrosBindingSource1
            // 
            this.registrosBindingSource1.DataMember = "Registros";
            this.registrosBindingSource1.DataSource = this.banco_sangreDataSet;
            // 
            // sangreTableAdapter
            // 
            this.sangreTableAdapter.ClearBeforeFill = true;
            // 
            // Litrostotales
            // 
            this.Litrostotales.AutoSize = true;
            this.Litrostotales.Location = new System.Drawing.Point(623, 282);
            this.Litrostotales.Name = "Litrostotales";
            this.Litrostotales.Size = new System.Drawing.Size(28, 17);
            this.Litrostotales.TabIndex = 4;
            this.Litrostotales.Text = "     ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1135, 668);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 55);
            this.button1.TabIndex = 5;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tSangreDataGridViewTextBoxColumn
            // 
            this.tSangreDataGridViewTextBoxColumn.DataPropertyName = "T_Sangre";
            this.tSangreDataGridViewTextBoxColumn.HeaderText = "T_Sangre";
            this.tSangreDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tSangreDataGridViewTextBoxColumn.Name = "tSangreDataGridViewTextBoxColumn";
            this.tSangreDataGridViewTextBoxColumn.Width = 125;
            // 
            // fRHDataGridViewTextBoxColumn
            // 
            this.fRHDataGridViewTextBoxColumn.DataPropertyName = "MILILITROS_D";
            this.fRHDataGridViewTextBoxColumn.HeaderText = "Militros_D";
            this.fRHDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fRHDataGridViewTextBoxColumn.Name = "fRHDataGridViewTextBoxColumn";
            this.fRHDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaCDataGridViewTextBoxColumn
            // 
            this.fechaCDataGridViewTextBoxColumn.DataPropertyName = "FECHA_D";
            this.fechaCDataGridViewTextBoxColumn.HeaderText = "Fecha_C";
            this.fechaCDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaCDataGridViewTextBoxColumn.Name = "fechaCDataGridViewTextBoxColumn";
            this.fechaCDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fechaCDataGridViewTextBoxColumn.Width = 125;
            // 
            // litrosDataGridViewTextBoxColumn
            // 
            this.litrosDataGridViewTextBoxColumn.DataPropertyName = "ESTATUS";
            this.litrosDataGridViewTextBoxColumn.HeaderText = "Estatus";
            this.litrosDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.litrosDataGridViewTextBoxColumn.Name = "litrosDataGridViewTextBoxColumn";
            this.litrosDataGridViewTextBoxColumn.Width = 125;
            // 
            // Informes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1279, 724);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Litrostotales);
            this.Controls.Add(this.dtw_Informes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Informes";
            this.Text = "Informes";
            this.Load += new System.EventHandler(this.Informes_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dtw_Informes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sangreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banco_sangreDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bancosangreDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banco_sangreDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrosBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtw_Informes;
        private System.Windows.Forms.BindingSource bancosangreDataSetBindingSource;
        private banco_sangreDataSet banco_sangreDataSet;
        private System.Windows.Forms.BindingSource registrosBindingSource;
        private banco_sangreDataSetTableAdapters.RegistrosTableAdapter registrosTableAdapter;
        private System.Windows.Forms.BindingSource registrosBindingSource1;
        private banco_sangreDataSet1 banco_sangreDataSet1;
        private System.Windows.Forms.BindingSource sangreBindingSource;
        private banco_sangreDataSet1TableAdapters.SangreTableAdapter sangreTableAdapter;
        private System.Windows.Forms.Label Litrostotales;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tSangreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fRHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn litrosDataGridViewTextBoxColumn;
    }
}