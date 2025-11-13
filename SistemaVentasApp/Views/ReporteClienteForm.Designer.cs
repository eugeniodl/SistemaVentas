namespace SistemaVentasApp.Views
{
    partial class ReporteClienteForm
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
            label1 = new Label();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            label2 = new Label();
            btnBuscar = new Button();
            btnDescargarExcel = new Button();
            dgvReporte = new DataGridView();
            formsPlot1 = new ScottPlot.FormsPlot();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(39, 92);
            label1.Name = "label1";
            label1.Size = new Size(158, 28);
            label1.TabIndex = 0;
            label1.Text = "Fecha de inicio:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(198, 95);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(121, 27);
            dtpFechaInicio.TabIndex = 1;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(447, 93);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(121, 27);
            dtpFechaFin.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(338, 92);
            label2.Name = "label2";
            label2.Size = new Size(103, 28);
            label2.TabIndex = 2;
            label2.Text = "Fecha fin:";
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.Green;
            btnBuscar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(584, 85);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(186, 45);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnDescargarExcel
            // 
            btnDescargarExcel.BackColor = Color.Green;
            btnDescargarExcel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnDescargarExcel.ForeColor = Color.White;
            btnDescargarExcel.Location = new Point(779, 85);
            btnDescargarExcel.Name = "btnDescargarExcel";
            btnDescargarExcel.Size = new Size(186, 45);
            btnDescargarExcel.TabIndex = 5;
            btnDescargarExcel.Text = "DESCARGAR EXCEL";
            btnDescargarExcel.UseVisualStyleBackColor = false;
            btnDescargarExcel.Click += btnDescargarExcel_Click;
            // 
            // dgvReporte
            // 
            dgvReporte.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(39, 147);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.ReadOnly = true;
            dgvReporte.RowHeadersWidth = 51;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.Size = new Size(926, 188);
            dgvReporte.TabIndex = 6;
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(127, 342);
            formsPlot1.Margin = new Padding(5, 4, 5, 4);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(767, 446);
            formsPlot1.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(351, 27);
            label3.Name = "label3";
            label3.Size = new Size(312, 38);
            label3.TabIndex = 8;
            label3.Text = "REPORTE DE CLIENTES";
            // 
            // ReporteClienteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondo_gris_degradado_color_suave;
            ClientSize = new Size(993, 807);
            Controls.Add(label3);
            Controls.Add(formsPlot1);
            Controls.Add(dgvReporte);
            Controls.Add(btnDescargarExcel);
            Controls.Add(btnBuscar);
            Controls.Add(dtpFechaFin);
            Controls.Add(label2);
            Controls.Add(dtpFechaInicio);
            Controls.Add(label1);
            Name = "ReporteClienteForm";
            Text = "ReporteClienteForm";
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Label label2;
        private Button btnBuscar;
        private Button btnDescargarExcel;
        private DataGridView dgvReporte;
        private ScottPlot.FormsPlot formsPlot1;
        private Label label3;
    }
}