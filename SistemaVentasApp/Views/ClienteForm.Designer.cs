namespace SistemaVentasApp.Views
{
    partial class ClienteForm
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
            label2 = new Label();
            dgvCliente = new DataGridView();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtPNombre = new TextBox();
            txtSNombre = new TextBox();
            label3 = new Label();
            txtPApellido = new TextBox();
            label4 = new Label();
            txtSApellido = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCliente).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(323, 9);
            label1.Name = "label1";
            label1.Size = new Size(282, 38);
            label1.TabIndex = 0;
            label1.Text = "DATOS DEL CLIENTE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(51, 75);
            label2.Name = "label2";
            label2.Size = new Size(186, 28);
            label2.TabIndex = 1;
            label2.Text = "Nombre Completo";
            // 
            // dgvCliente
            // 
            dgvCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCliente.Location = new Point(47, 355);
            dgvCliente.Name = "dgvCliente";
            dgvCliente.ReadOnly = true;
            dgvCliente.RowHeadersWidth = 51;
            dgvCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCliente.Size = new Size(849, 248);
            dgvCliente.TabIndex = 17;
            dgvCliente.CellClick += dgvCliente_CellClick;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Green;
            btnAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(51, 286);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(186, 45);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "AGREGAR";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Green;
            btnUpdate.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(378, 286);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(186, 45);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "ACTUALIZAR";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Green;
            btnDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(710, 286);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(186, 45);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "ELIMINAR";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtPNombre
            // 
            txtPNombre.Location = new Point(51, 117);
            txtPNombre.Name = "txtPNombre";
            txtPNombre.Size = new Size(191, 27);
            txtPNombre.TabIndex = 2;
            // 
            // txtSNombre
            // 
            txtSNombre.Location = new Point(271, 117);
            txtSNombre.Name = "txtSNombre";
            txtSNombre.Size = new Size(191, 27);
            txtSNombre.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(51, 147);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 3;
            label3.Text = "Primer nombre";
            // 
            // txtPApellido
            // 
            txtPApellido.Location = new Point(490, 117);
            txtPApellido.Name = "txtPApellido";
            txtPApellido.Size = new Size(191, 27);
            txtPApellido.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(271, 147);
            label4.Name = "label4";
            label4.Size = new Size(124, 20);
            label4.TabIndex = 5;
            label4.Text = "Segundo nombre";
            // 
            // txtSApellido
            // 
            txtSApellido.Location = new Point(709, 117);
            txtSApellido.Name = "txtSApellido";
            txtSApellido.Size = new Size(191, 27);
            txtSApellido.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(490, 147);
            label5.Name = "label5";
            label5.Size = new Size(111, 20);
            label5.TabIndex = 7;
            label5.Text = "Primer apellido";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(709, 147);
            label6.Name = "label6";
            label6.Size = new Size(127, 20);
            label6.TabIndex = 9;
            label6.Text = "Segundo apellido";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(51, 196);
            label7.Name = "label7";
            label7.Size = new Size(187, 28);
            label7.TabIndex = 10;
            label7.Text = "Correo Electrónico";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(51, 237);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(411, 27);
            txtCorreo.TabIndex = 11;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(489, 237);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(411, 27);
            txtTelefono.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(489, 196);
            label8.Name = "label8";
            label8.Size = new Size(206, 28);
            label8.TabIndex = 12;
            label8.Text = "Número de Teléfono";
            // 
            // ClienteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondo_gris_degradado_color_suave;
            ClientSize = new Size(942, 623);
            Controls.Add(txtTelefono);
            Controls.Add(label8);
            Controls.Add(txtCorreo);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txtSApellido);
            Controls.Add(label5);
            Controls.Add(txtPApellido);
            Controls.Add(label4);
            Controls.Add(txtSNombre);
            Controls.Add(label3);
            Controls.Add(txtPNombre);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(dgvCliente);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ClienteForm";
            Text = "ClienteForm";
            Load += ClienteForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCliente).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DataGridView dgvCliente;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtPNombre;
        private TextBox txtSNombre;
        private Label label3;
        private TextBox txtPApellido;
        private Label label4;
        private TextBox txtSApellido;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtCorreo;
        private TextBox txtTelefono;
        private Label label8;
    }
}