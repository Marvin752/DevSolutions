namespace DevSolutions.Forms
{
    partial class FrmProductos
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductos));
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtSKU = new TextBox();
            cmbCategoria = new ComboBox();
            cmbBodega = new ComboBox();
            txtCostoUnitario = new TextBox();
            picImagen = new PictureBox();
            btnCargarImagen = new Button();
            btnGuardar = new Button();
            btnActualizar = new Button();
            btnLimpiar = new Button();
            dgvProductos = new DataGridView();
            btnRegresar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label8 = new Label();
            labelCateogria = new Label();
            label9 = new Label();
            checkBoxDescuento = new CheckBox();
            comboBoxTipoProducto = new ComboBox();
            label4 = new Label();
            comboBoxProveedor = new ComboBox();
            panelHeader = new Panel();
            txtId = new TextBox();
            lblTitulo = new Label();
            panelFormulario = new Panel();
            panelImagen = new Panel();
            panelBotones = new Panel();
            ((System.ComponentModel.ISupportInitialize)picImagen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panelHeader.SuspendLayout();
            panelFormulario.SuspendLayout();
            panelImagen.SuspendLayout();
            panelBotones.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.Location = new Point(260, 52);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 30);
            txtNombre.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Font = new Font("Segoe UI", 10F);
            txtDescripcion.Location = new Point(30, 122);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(530, 60);
            txtDescripcion.TabIndex = 2;
            // 
            // txtSKU
            // 
            txtSKU.Font = new Font("Segoe UI", 10F);
            txtSKU.Location = new Point(30, 52);
            txtSKU.Name = "txtSKU";
            txtSKU.Size = new Size(200, 30);
            txtSKU.TabIndex = 3;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Font = new Font("Segoe UI", 10F);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(350, 222);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(210, 31);
            cmbCategoria.TabIndex = 4;
            // 
            // cmbBodega
            // 
            cmbBodega.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBodega.Font = new Font("Segoe UI", 10F);
            cmbBodega.FormattingEnabled = true;
            cmbBodega.Location = new Point(30, 222);
            cmbBodega.Name = "cmbBodega";
            cmbBodega.Size = new Size(300, 31);
            cmbBodega.TabIndex = 5;
            cmbBodega.SelectedIndexChanged += cmbBodega_SelectedIndexChanged;
            // 
            // txtCostoUnitario
            // 
            txtCostoUnitario.Font = new Font("Segoe UI", 10F);
            txtCostoUnitario.Location = new Point(600, 52);
            txtCostoUnitario.Name = "txtCostoUnitario";
            txtCostoUnitario.Size = new Size(250, 30);
            txtCostoUnitario.TabIndex = 7;
            // 
            // picImagen
            // 
            picImagen.BorderStyle = BorderStyle.FixedSingle;
            picImagen.Location = new Point(30, 25);
            picImagen.Name = "picImagen";
            picImagen.Size = new Size(490, 180);
            picImagen.SizeMode = PictureBoxSizeMode.Zoom;
            picImagen.TabIndex = 10;
            picImagen.TabStop = false;
            // 
            // btnCargarImagen
            // 
            btnCargarImagen.BackColor = Color.FromArgb(52, 152, 219);
            btnCargarImagen.FlatAppearance.BorderSize = 0;
            btnCargarImagen.FlatStyle = FlatStyle.Flat;
            btnCargarImagen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCargarImagen.ForeColor = Color.White;
            btnCargarImagen.Location = new Point(150, 222);
            btnCargarImagen.Name = "btnCargarImagen";
            btnCargarImagen.Size = new Size(240, 45);
            btnCargarImagen.TabIndex = 11;
            btnCargarImagen.Text = "CARGAR IMAGEN";
            btnCargarImagen.UseVisualStyleBackColor = false;
            btnCargarImagen.Click += btnCargarImagen_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(46, 204, 113);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(30, 15);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(180, 50);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(52, 152, 219);
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(230, 15);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(180, 50);
            btnActualizar.TabIndex = 15;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(243, 156, 18);
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(430, 15);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(180, 50);
            btnLimpiar.TabIndex = 16;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.ColumnHeadersHeight = 40;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.FromArgb(189, 195, 199);
            dgvProductos.Location = new Point(30, 540);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.RowTemplate.Height = 35;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(1470, 350);
            dgvProductos.TabIndex = 17;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // btnRegresar
            // 
            btnRegresar.BackColor = Color.FromArgb(231, 76, 60);
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegresar.ForeColor = Color.White;
            btnRegresar.Location = new Point(690, 15);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(180, 50);
            btnRegresar.TabIndex = 18;
            btnRegresar.Text = "REGRESAR";
            btnRegresar.UseVisualStyleBackColor = false;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.FromArgb(52, 73, 94);
            label1.Location = new Point(30, 25);
            label1.Name = "label1";
            label1.Size = new Size(105, 23);
            label1.TabIndex = 19;
            label1.Text = "Código SKU:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = Color.FromArgb(52, 73, 94);
            label2.Location = new Point(260, 25);
            label2.Name = "label2";
            label2.Size = new Size(180, 23);
            label2.TabIndex = 20;
            label2.Text = "Nombre del Producto:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.FromArgb(52, 73, 94);
            label3.Location = new Point(30, 95);
            label3.Name = "label3";
            label3.Size = new Size(102, 23);
            label3.TabIndex = 21;
            label3.Text = "Descripción:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = Color.FromArgb(52, 73, 94);
            label5.Location = new Point(600, 25);
            label5.Name = "label5";
            label5.Size = new Size(122, 23);
            label5.TabIndex = 23;
            label5.Text = "Costo unitario:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.ForeColor = Color.FromArgb(52, 73, 94);
            label8.Location = new Point(30, 195);
            label8.Name = "label8";
            label8.Size = new Size(155, 23);
            label8.TabIndex = 26;
            label8.Text = "Unidad de medida:";
            // 
            // labelCateogria
            // 
            labelCateogria.AutoSize = true;
            labelCateogria.Font = new Font("Segoe UI", 10F);
            labelCateogria.ForeColor = Color.FromArgb(52, 73, 94);
            labelCateogria.Location = new Point(350, 195);
            labelCateogria.Name = "labelCateogria";
            labelCateogria.Size = new Size(88, 23);
            labelCateogria.TabIndex = 27;
            labelCateogria.Text = "Categoría:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.ForeColor = Color.FromArgb(52, 73, 94);
            label9.Location = new Point(30, 265);
            label9.Name = "label9";
            label9.Size = new Size(150, 23);
            label9.TabIndex = 29;
            label9.Text = "Tipo del Producto:";
            // 
            // checkBoxDescuento
            // 
            checkBoxDescuento.AutoSize = true;
            checkBoxDescuento.Font = new Font("Segoe UI", 10F);
            checkBoxDescuento.ForeColor = Color.FromArgb(52, 73, 94);
            checkBoxDescuento.Location = new Point(600, 95);
            checkBoxDescuento.Name = "checkBoxDescuento";
            checkBoxDescuento.Size = new Size(159, 27);
            checkBoxDescuento.TabIndex = 30;
            checkBoxDescuento.Text = "Tiene Descuento";
            checkBoxDescuento.UseVisualStyleBackColor = true;
            // 
            // comboBoxTipoProducto
            // 
            comboBoxTipoProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoProducto.Font = new Font("Segoe UI", 10F);
            comboBoxTipoProducto.FormattingEnabled = true;
            comboBoxTipoProducto.Location = new Point(190, 262);
            comboBoxTipoProducto.Name = "comboBoxTipoProducto";
            comboBoxTipoProducto.Size = new Size(280, 31);
            comboBoxTipoProducto.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.FromArgb(52, 73, 94);
            label4.Location = new Point(490, 265);
            label4.Name = "label4";
            label4.Size = new Size(92, 23);
            label4.TabIndex = 32;
            label4.Text = "Proveedor:";
            // 
            // comboBoxProveedor
            // 
            comboBoxProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProveedor.Font = new Font("Segoe UI", 10F);
            comboBoxProveedor.FormattingEnabled = true;
            comboBoxProveedor.Location = new Point(590, 262);
            comboBoxProveedor.Name = "comboBoxProveedor";
            comboBoxProveedor.Size = new Size(260, 31);
            comboBoxProveedor.TabIndex = 33;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(txtId);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1532, 80);
            panelHeader.TabIndex = 34;
            // 
            // txtId
            // 
            txtId.Location = new Point(1400, 50);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 27);
            txtId.TabIndex = 20;
            txtId.Visible = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(30, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(318, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Productos";
            // 
            // panelFormulario
            // 
            panelFormulario.BackColor = Color.White;
            panelFormulario.BorderStyle = BorderStyle.FixedSingle;
            panelFormulario.Controls.Add(label1);
            panelFormulario.Controls.Add(txtSKU);
            panelFormulario.Controls.Add(label2);
            panelFormulario.Controls.Add(txtNombre);
            panelFormulario.Controls.Add(label3);
            panelFormulario.Controls.Add(txtDescripcion);
            panelFormulario.Controls.Add(label5);
            panelFormulario.Controls.Add(txtCostoUnitario);
            panelFormulario.Controls.Add(label8);
            panelFormulario.Controls.Add(cmbBodega);
            panelFormulario.Controls.Add(labelCateogria);
            panelFormulario.Controls.Add(cmbCategoria);
            panelFormulario.Controls.Add(checkBoxDescuento);
            panelFormulario.Controls.Add(label9);
            panelFormulario.Controls.Add(comboBoxTipoProducto);
            panelFormulario.Controls.Add(label4);
            panelFormulario.Controls.Add(comboBoxProveedor);
            panelFormulario.Location = new Point(30, 100);
            panelFormulario.Name = "panelFormulario";
            panelFormulario.Size = new Size(900, 320);
            panelFormulario.TabIndex = 35;
            // 
            // panelImagen
            // 
            panelImagen.BackColor = Color.White;
            panelImagen.BorderStyle = BorderStyle.FixedSingle;
            panelImagen.Controls.Add(picImagen);
            panelImagen.Controls.Add(btnCargarImagen);
            panelImagen.Location = new Point(950, 100);
            panelImagen.Name = "panelImagen";
            panelImagen.Size = new Size(550, 320);
            panelImagen.TabIndex = 36;
            // 
            // panelBotones
            // 
            panelBotones.BackColor = Color.White;
            panelBotones.BorderStyle = BorderStyle.FixedSingle;
            panelBotones.Controls.Add(btnGuardar);
            panelBotones.Controls.Add(btnActualizar);
            panelBotones.Controls.Add(btnLimpiar);
            panelBotones.Controls.Add(btnRegresar);
            panelBotones.Location = new Point(30, 440);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(900, 80);
            panelBotones.TabIndex = 37;
            // 
            // FrmProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1532, 908);
            Controls.Add(dgvProductos);
            Controls.Add(panelBotones);
            Controls.Add(panelImagen);
            Controls.Add(panelFormulario);
            Controls.Add(panelHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DevSolutions - Gestión de Productos";
            Load += FrmProductos_Load;
            ((System.ComponentModel.ISupportInitialize)picImagen).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFormulario.ResumeLayout(false);
            panelFormulario.PerformLayout();
            panelImagen.ResumeLayout(false);
            panelBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtSKU;
        private ComboBox cmbCategoria;
        private ComboBox cmbBodega;
        private TextBox txtCostoUnitario;
        private PictureBox picImagen;
        private Button btnCargarImagen;
        private Button btnGuardar;
        private Button btnActualizar;
        private Button btnLimpiar;
        private DataGridView dgvProductos;
        private Button btnRegresar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label8;
        private Label labelCateogria;
        private Label label9;
        private CheckBox checkBoxDescuento;
        private ComboBox comboBoxTipoProducto;
        private Label label4;
        private ComboBox comboBoxProveedor;
        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelFormulario;
        private Panel panelImagen;
        private Panel panelBotones;
        private TextBox txtId;
    }
}