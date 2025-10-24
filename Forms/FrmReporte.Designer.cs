namespace DevSolutions.Forms
{
    partial class FrmReporte
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
            panelHeader = new Panel();
            lblTitulo = new Label();
            panelFormulario = new Panel();
            label2 = new Label();
            cmbTipoReporte = new ComboBox();
            panelBotones = new Panel();
            btnGenerarPDF = new Button();
            btnVistaPrevia = new Button();
            panelHeader.SuspendLayout();
            panelFormulario.SuspendLayout();
            panelBotones.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 80);
            panelHeader.TabIndex = 0;
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
            lblTitulo.Text = "Generación de Reportes";
            // 
            // panelFormulario
            // 
            panelFormulario.BackColor = Color.White;
            panelFormulario.BorderStyle = BorderStyle.FixedSingle;
            panelFormulario.Controls.Add(label2);
            panelFormulario.Controls.Add(cmbTipoReporte);
            panelFormulario.Location = new Point(50, 120);
            panelFormulario.Name = "panelFormulario";
            panelFormulario.Size = new Size(800, 120);
            panelFormulario.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(52, 73, 94);
            label2.Location = new Point(30, 25);
            label2.Name = "label2";
            label2.Size = new Size(210, 28);
            label2.TabIndex = 1;
            label2.Text = "Tipo de Reporte";
            // 
            // cmbTipoReporte
            // 
            cmbTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoReporte.Font = new Font("Segoe UI", 11F);
            cmbTipoReporte.FormattingEnabled = true;
            cmbTipoReporte.Location = new Point(30, 60);
            cmbTipoReporte.Name = "cmbTipoReporte";
            cmbTipoReporte.Size = new Size(740, 33);
            cmbTipoReporte.TabIndex = 0;
            // 
            // panelBotones
            // 
            panelBotones.BackColor = Color.White;
            panelBotones.BorderStyle = BorderStyle.FixedSingle;
            panelBotones.Controls.Add(btnGenerarPDF);
            panelBotones.Controls.Add(btnVistaPrevia);
            panelBotones.Location = new Point(50, 260);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(800, 180);
            panelBotones.TabIndex = 2;
            // 
            // btnGenerarPDF
            // 
            btnGenerarPDF.BackColor = Color.FromArgb(46, 204, 113);
            btnGenerarPDF.FlatAppearance.BorderSize = 0;
            btnGenerarPDF.FlatStyle = FlatStyle.Flat;
            btnGenerarPDF.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenerarPDF.ForeColor = Color.White;
            btnGenerarPDF.Location = new Point(100, 50);
            btnGenerarPDF.Name = "btnGenerarPDF";
            btnGenerarPDF.Size = new Size(250, 80);
            btnGenerarPDF.TabIndex = 0;
            btnGenerarPDF.Text = "📄 GENERAR PDF";
            btnGenerarPDF.UseVisualStyleBackColor = false;
            btnGenerarPDF.Click += btnGenerarPDF_Click;
            // 
            // btnVistaPrevia
            // 
            btnVistaPrevia.BackColor = Color.FromArgb(52, 152, 219);
            btnVistaPrevia.FlatAppearance.BorderSize = 0;
            btnVistaPrevia.FlatStyle = FlatStyle.Flat;
            btnVistaPrevia.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnVistaPrevia.ForeColor = Color.White;
            btnVistaPrevia.Location = new Point(450, 50);
            btnVistaPrevia.Name = "btnVistaPrevia";
            btnVistaPrevia.Size = new Size(250, 80);
            btnVistaPrevia.TabIndex = 1;
            btnVistaPrevia.Text = "👁 VISTA PREVIA";
            btnVistaPrevia.UseVisualStyleBackColor = false;
            btnVistaPrevia.Click += btnVistaPrevia_Click;
            // 
            // FrmReporte
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(900, 500);
            Controls.Add(panelBotones);
            Controls.Add(panelFormulario);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmReporte";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DevSolutions - Generación de Reportes";
            Load += FrmReporte_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFormulario.ResumeLayout(false);
            panelFormulario.PerformLayout();
            panelBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelFormulario;
        private Label label2;
        private ComboBox cmbTipoReporte;
        private Panel panelBotones;
        private Button btnGenerarPDF;
        private Button btnVistaPrevia;
    }
}