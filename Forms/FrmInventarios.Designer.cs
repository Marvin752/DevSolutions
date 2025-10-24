namespace DevSolutions.Forms
{
    partial class FrmInventarios
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnAgregar = new Button();
            btnLimpiar = new Button();
            btnRegresar = new Button();
            btnActualizar = new Button();
            cmbProducto = new ComboBox();
            txtCantidad = new TextBox();
            txtPrecioVenta = new TextBox();
            dgvInventarios = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            textBoxDescuento = new TextBox();
            Cantidad = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBoxEstanterias = new ComboBox();
            txtInventarioId = new TextBox();
            panelHeader = new Panel();
            lblTitulo = new Label();
            panelFormulario = new Panel();
            panelBotones = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvInventarios).BeginInit();
            panelHeader.SuspendLayout();
            panelFormulario.SuspendLayout();
            panelBotones.SuspendLayout();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(46, 204, 113);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(25, 15);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(145, 50);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(243, 156, 18);
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(25, 80);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(145, 50);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnRegresar
            // 
            btnRegresar.BackColor = Color.FromArgb(231, 76, 60);
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegresar.ForeColor = Color.White;
            btnRegresar.Location = new Point(180, 80);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(145, 50);
            btnRegresar.TabIndex = 9;
            btnRegresar.Text = "REGRESAR";
            btnRegresar.UseVisualStyleBackColor = false;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(52, 152, 219);
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(180, 15);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(145, 50);
            btnActualizar.TabIndex = 7;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // cmbProducto
            // 
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.Font = new Font("Segoe UI", 10F);
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(30, 52);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(330, 31);
            cmbProducto.TabIndex = 0;
            cmbProducto.SelectedIndexChanged += cmbProducto_SelectedIndexChanged;
            // 
            // txtCantidad
            // 
            txtCantidad.Font = new Font("Segoe UI", 10F);
            txtCantidad.Location = new Point(210, 127);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(150, 30);
            txtCantidad.TabIndex = 2;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Font = new Font("Segoe UI", 10F);
            txtPrecioVenta.Location = new Point(390, 52);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(180, 30);
            txtPrecioVenta.TabIndex = 3;
            // 
            // dgvInventarios
            // 
            dgvInventarios.AllowUserToAddRows = false;
            dgvInventarios.AllowUserToDeleteRows = false;
            dgvInventarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventarios.BackgroundColor = Color.White;
            dgvInventarios.BorderStyle = BorderStyle.None;
            dgvInventarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvInventarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvInventarios.ColumnHeadersHeight = 40;
            dgvInventarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvInventarios.EnableHeadersVisualStyles = false;
            dgvInventarios.GridColor = Color.FromArgb(189, 195, 199);
            dgvInventarios.Location = new Point(30, 300);
            dgvInventarios.Name = "dgvInventarios";
            dgvInventarios.ReadOnly = true;
            dgvInventarios.RowHeadersVisible = false;
            dgvInventarios.RowHeadersWidth = 51;
            dgvInventarios.RowTemplate.Height = 35;
            dgvInventarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventarios.Size = new Size(1170, 500);
            dgvInventarios.TabIndex = 10;
            dgvInventarios.CellContentClick += dgvInventarios_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.FromArgb(52, 73, 94);
            label1.Location = new Point(30, 25);
            label1.Name = "label1";
            label1.Size = new Size(80, 23);
            label1.TabIndex = 12;
            label1.Text = "Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = Color.FromArgb(52, 73, 94);
            label2.Location = new Point(30, 100);
            label2.Name = "label2";
            label2.Size = new Size(91, 23);
            label2.TabIndex = 13;
            label2.Text = "Descuento";
            // 
            // textBoxDescuento
            // 
            textBoxDescuento.Font = new Font("Segoe UI", 10F);
            textBoxDescuento.Location = new Point(30, 127);
            textBoxDescuento.Name = "textBoxDescuento";
            textBoxDescuento.Size = new Size(150, 30);
            textBoxDescuento.TabIndex = 1;
            textBoxDescuento.Text = "0";
            // 
            // Cantidad
            // 
            Cantidad.AutoSize = true;
            Cantidad.Font = new Font("Segoe UI", 10F);
            Cantidad.ForeColor = Color.FromArgb(52, 73, 94);
            Cantidad.Location = new Point(210, 100);
            Cantidad.Name = "Cantidad";
            Cantidad.Size = new Size(79, 23);
            Cantidad.TabIndex = 15;
            Cantidad.Text = "Cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.FromArgb(52, 73, 94);
            label3.Location = new Point(390, 25);
            label3.Name = "label3";
            label3.Size = new Size(130, 23);
            label3.TabIndex = 16;
            label3.Text = "Precio de Venta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.FromArgb(52, 73, 94);
            label4.Location = new Point(390, 100);
            label4.Name = "label4";
            label4.Size = new Size(85, 23);
            label4.TabIndex = 17;
            label4.Text = "Estantería";
            // 
            // comboBoxEstanterias
            // 
            comboBoxEstanterias.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstanterias.Font = new Font("Segoe UI", 10F);
            comboBoxEstanterias.FormattingEnabled = true;
            comboBoxEstanterias.Location = new Point(390, 127);
            comboBoxEstanterias.Name = "comboBoxEstanterias";
            comboBoxEstanterias.Size = new Size(180, 31);
            comboBoxEstanterias.TabIndex = 4;
            // 
            // txtInventarioId
            // 
            txtInventarioId.Location = new Point(1100, 50);
            txtInventarioId.Name = "txtInventarioId";
            txtInventarioId.ReadOnly = true;
            txtInventarioId.Size = new Size(100, 27);
            txtInventarioId.TabIndex = 19;
            txtInventarioId.Visible = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(txtInventarioId);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1228, 80);
            panelHeader.TabIndex = 20;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(30, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(334, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Inventarios";
            // 
            // panelFormulario
            // 
            panelFormulario.BackColor = Color.White;
            panelFormulario.BorderStyle = BorderStyle.FixedSingle;
            panelFormulario.Controls.Add(label1);
            panelFormulario.Controls.Add(cmbProducto);
            panelFormulario.Controls.Add(label2);
            panelFormulario.Controls.Add(textBoxDescuento);
            panelFormulario.Controls.Add(Cantidad);
            panelFormulario.Controls.Add(txtCantidad);
            panelFormulario.Controls.Add(label3);
            panelFormulario.Controls.Add(txtPrecioVenta);
            panelFormulario.Controls.Add(label4);
            panelFormulario.Controls.Add(comboBoxEstanterias);
            panelFormulario.Location = new Point(30, 100);
            panelFormulario.Name = "panelFormulario";
            panelFormulario.Size = new Size(800, 180);
            panelFormulario.TabIndex = 21;
            // 
            // panelBotones
            // 
            panelBotones.BackColor = Color.White;
            panelBotones.BorderStyle = BorderStyle.FixedSingle;
            panelBotones.Controls.Add(btnAgregar);
            panelBotones.Controls.Add(btnActualizar);
            panelBotones.Controls.Add(btnLimpiar);
            panelBotones.Controls.Add(btnRegresar);
            panelBotones.Location = new Point(850, 100);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(350, 180);
            panelBotones.TabIndex = 22;
            // 
            // FrmInventarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1228, 821);
            Controls.Add(panelBotones);
            Controls.Add(panelFormulario);
            Controls.Add(panelHeader);
            Controls.Add(dgvInventarios);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmInventarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DevSolutions - Gestión de Inventarios";
            Load += FrmInventarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInventarios).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFormulario.ResumeLayout(false);
            panelFormulario.PerformLayout();
            panelBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnAgregar;
        private Button btnLimpiar;
        private Button btnRegresar;
        private Button btnActualizar;
        private ComboBox cmbProducto;
        private TextBox txtCantidad;
        private TextBox txtPrecioVenta;
        private DataGridView dgvInventarios;
        private Label label1;
        private Label label2;
        private TextBox textBoxDescuento;
        private Label Cantidad;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxEstanterias;
        private TextBox txtInventarioId;
        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelFormulario;
        private Panel panelBotones;
    }
}