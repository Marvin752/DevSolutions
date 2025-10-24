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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtInventarioId = new System.Windows.Forms.TextBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.dtpFechaActualizacion = new System.Windows.Forms.DateTimePicker();
            this.txtEstanteriaId = new System.Windows.Forms.TextBox();
            this.dgvInventarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarios)).BeginInit();
         
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(888, 117);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(135, 38);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(888, 243);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(135, 45);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(875, 322);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(135, 49);
            this.btnRegresar.TabIndex = 2;
            this.btnRegresar.Text = "regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(888, 171);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(135, 48);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtInventarioId
            // 
            this.txtInventarioId.Location = new System.Drawing.Point(278, 77);
            this.txtInventarioId.Name = "txtInventarioId";
            this.txtInventarioId.Size = new System.Drawing.Size(186, 22);
            this.txtInventarioId.TabIndex = 4;
            this.txtInventarioId.Text = "ID (solo lectura)";
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(278, 125);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(186, 24);
            this.cmbProducto.TabIndex = 5;
            this.cmbProducto.Text = "Producto";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(278, 184);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(151, 22);
            this.txtCantidad.TabIndex = 6;
            this.txtCantidad.Text = "Cantidad";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(278, 283);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(151, 22);
            this.txtDescuento.TabIndex = 7;
            this.txtDescuento.Text = "Descuento";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(278, 234);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(151, 22);
            this.txtPrecioVenta.TabIndex = 8;
            this.txtPrecioVenta.Text = "Precio de venta";
            // 
            // dtpFechaActualizacion
            // 
            this.dtpFechaActualizacion.Location = new System.Drawing.Point(278, 322);
            this.dtpFechaActualizacion.Name = "dtpFechaActualizacion";
            this.dtpFechaActualizacion.Size = new System.Drawing.Size(280, 22);
            this.dtpFechaActualizacion.TabIndex = 9;
            // 
            // txtEstanteriaId
            // 
            this.txtEstanteriaId.Location = new System.Drawing.Point(278, 374);
            this.txtEstanteriaId.Name = "txtEstanteriaId";
            this.txtEstanteriaId.Size = new System.Drawing.Size(105, 22);
            this.txtEstanteriaId.TabIndex = 10;
            this.txtEstanteriaId.Text = "Estantería Id";
            // 
            // dgvInventarios
            // 
            this.dgvInventarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventarios.Location = new System.Drawing.Point(104, 446);
            this.dgvInventarios.Name = "dgvInventarios";
            this.dgvInventarios.RowHeadersWidth = 51;
            this.dgvInventarios.RowTemplate.Height = 24;
            this.dgvInventarios.Size = new System.Drawing.Size(1061, 180);
            this.dgvInventarios.TabIndex = 11;
            this.dgvInventarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventarios_CellContentClick);
            // 
            // FrmInventarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 657);
            this.Controls.Add(this.dgvInventarios);
            this.Controls.Add(this.txtEstanteriaId);
            this.Controls.Add(this.dtpFechaActualizacion);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.txtInventarioId);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAgregar);
            this.Name = "FrmInventarios";
            this.Text = "FrmInventarios";
            this.Load += new System.EventHandler(this.FrmInventarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtInventarioId;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.DateTimePicker dtpFechaActualizacion;
        private System.Windows.Forms.TextBox txtEstanteriaId;
        private System.Windows.Forms.DataGridView dgvInventarios;
    }
}