namespace RecaudaciónImpuestosVehiculos
{
    partial class frmSeguimientoPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeguimientoPagos));
            btnRegresar = new Button();
            txtNombrePropietario = new TextBox();
            groupBox1 = new GroupBox();
            DatosInforme = new DataGridView();
            label2 = new Label();
            btnGuardarPDF = new Button();
            btnConsultarPagos = new Button();
            label1 = new Label();
            cmbTipoPago = new ComboBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DatosInforme).BeginInit();
            SuspendLayout();
            // 
            // btnRegresar
            // 
            btnRegresar.BackgroundImage = (Image)resources.GetObject("btnRegresar.BackgroundImage");
            btnRegresar.ForeColor = Color.White;
            btnRegresar.Location = new Point(0, 0);
            btnRegresar.Margin = new Padding(3, 2, 3, 2);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(48, 41);
            btnRegresar.TabIndex = 1;
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // txtNombrePropietario
            // 
            txtNombrePropietario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNombrePropietario.Location = new Point(274, 89);
            txtNombrePropietario.Name = "txtNombrePropietario";
            txtNombrePropietario.Size = new Size(424, 23);
            txtNombrePropietario.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(DatosInforme);
            groupBox1.Location = new Point(12, 182);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(833, 320);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registro de Informes";
            // 
            // DatosInforme
            // 
            DatosInforme.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DatosInforme.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DatosInforme.Location = new Point(5, 20);
            DatosInforme.Margin = new Padding(3, 2, 3, 2);
            DatosInforme.Name = "DatosInforme";
            DatosInforme.RowHeadersWidth = 51;
            DatosInforme.RowTemplate.Height = 25;
            DatosInforme.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DatosInforme.Size = new Size(822, 296);
            DatosInforme.TabIndex = 3;
            DatosInforme.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(123, 91);
            label2.Name = "label2";
            label2.Size = new Size(132, 15);
            label2.TabIndex = 8;
            label2.Text = "Propietario de Vehiculo:";
            // 
            // btnGuardarPDF
            // 
            btnGuardarPDF.Anchor = AnchorStyles.Top;
            btnGuardarPDF.BackColor = Color.Transparent;
            btnGuardarPDF.BackgroundImage = (Image)resources.GetObject("btnGuardarPDF.BackgroundImage");
            btnGuardarPDF.Location = new Point(398, 114);
            btnGuardarPDF.Margin = new Padding(3, 2, 3, 2);
            btnGuardarPDF.Name = "btnGuardarPDF";
            btnGuardarPDF.Size = new Size(72, 60);
            btnGuardarPDF.TabIndex = 10;
            btnGuardarPDF.UseVisualStyleBackColor = false;
            btnGuardarPDF.Click += btnGuardarPDF_Click;
            // 
            // btnConsultarPagos
            // 
            btnConsultarPagos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConsultarPagos.BackColor = Color.Transparent;
            btnConsultarPagos.BackgroundImage = (Image)resources.GetObject("btnConsultarPagos.BackgroundImage");
            btnConsultarPagos.Location = new Point(703, 78);
            btnConsultarPagos.Margin = new Padding(3, 2, 3, 2);
            btnConsultarPagos.Name = "btnConsultarPagos";
            btnConsultarPagos.Size = new Size(48, 41);
            btnConsultarPagos.TabIndex = 9;
            btnConsultarPagos.UseVisualStyleBackColor = false;
            btnConsultarPagos.Click += btnConsultarPagos_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(123, 46);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 11;
            label1.Text = "Tipo de dato";
            // 
            // cmbTipoPago
            // 
            cmbTipoPago.FormattingEnabled = true;
            cmbTipoPago.Items.AddRange(new object[] { "DNI", "Matrícula", "Nombre del Dueño" });
            cmbTipoPago.Location = new Point(274, 46);
            cmbTipoPago.Name = "cmbTipoPago";
            cmbTipoPago.Size = new Size(121, 23);
            cmbTipoPago.TabIndex = 12;
            // 
            // frmSeguimientoPagos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(844, 504);
            Controls.Add(cmbTipoPago);
            Controls.Add(label1);
            Controls.Add(btnGuardarPDF);
            Controls.Add(btnConsultarPagos);
            Controls.Add(label2);
            Controls.Add(txtNombrePropietario);
            Controls.Add(groupBox1);
            Controls.Add(btnRegresar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmSeguimientoPagos";
            Text = "Seguimiento de Pagos";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DatosInforme).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegresar;
        private TextBox txtNombrePropietario;
        private GroupBox groupBox1;
        private DataGridView DatosInforme;
        private Label label2;
        private Button btnGuardarPDF;
        private Button btnConsultarPagos;
        private Label label1;
        private ComboBox cmbTipoPago;
    }
}