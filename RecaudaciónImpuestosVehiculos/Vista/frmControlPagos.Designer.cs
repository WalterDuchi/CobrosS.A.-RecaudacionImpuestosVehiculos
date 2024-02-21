namespace RecaudaciónImpuestosVehiculos
{
    partial class frmControlPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlPagos));
            btnRegresar = new Button();
            panel1 = new Panel();
            btnRegistrarPago = new Button();
            txtID_Deuda = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            cmbTipoDePago = new ComboBox();
            label5 = new Label();
            label2 = new Label();
            dtpFechaPago = new DateTimePicker();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnRegresar
            // 
            btnRegresar.BackgroundImage = (Image)resources.GetObject("btnRegresar.BackgroundImage");
            btnRegresar.ForeColor = Color.White;
            btnRegresar.Location = new Point(0, 0);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(55, 55);
            btnRegresar.TabIndex = 2;
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(btnRegistrarPago);
            panel1.Location = new Point(61, 376);
            panel1.Name = "panel1";
            panel1.Size = new Size(685, 62);
            panel1.TabIndex = 9;
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.Anchor = AnchorStyles.None;
            btnRegistrarPago.Location = new Point(275, 18);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(154, 29);
            btnRegistrarPago.TabIndex = 7;
            btnRegistrarPago.Text = "Registrar Pago";
            btnRegistrarPago.UseVisualStyleBackColor = true;
            btnRegistrarPago.Click += btnRegistrarPago_Click;
            // 
            // txtID_Deuda
            // 
            txtID_Deuda.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtID_Deuda.Location = new Point(275, 123);
            txtID_Deuda.Name = "txtID_Deuda";
            txtID_Deuda.Size = new Size(333, 27);
            txtID_Deuda.TabIndex = 4;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(133, 59);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 6;
            label1.Text = "Fecha de Pago:";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.Controls.Add(cmbTipoDePago);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dtpFechaPago);
            groupBox1.Controls.Add(txtID_Deuda);
            groupBox1.Location = new Point(61, 54);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(685, 316);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingreso de datos";
            // 
            // cmbTipoDePago
            // 
            cmbTipoDePago.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbTipoDePago.FormattingEnabled = true;
            cmbTipoDePago.Items.AddRange(new object[] { "1. Pago realizado en ventanilla", "2. Pago mediante deposito bancario (domiciliado)" });
            cmbTipoDePago.Location = new Point(275, 196);
            cmbTipoDePago.Name = "cmbTipoDePago";
            cmbTipoDePago.Size = new Size(333, 28);
            cmbTipoDePago.TabIndex = 12;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(141, 199);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 11;
            label5.Text = "Tipo de Pago:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(100, 126);
            label2.Name = "label2";
            label2.Size = new Size(149, 20);
            label2.TabIndex = 7;
            label2.Text = "Número de la deuda:";
            // 
            // dtpFechaPago
            // 
            dtpFechaPago.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtpFechaPago.Location = new Point(275, 54);
            dtpFechaPago.Name = "dtpFechaPago";
            dtpFechaPago.Size = new Size(333, 27);
            dtpFechaPago.TabIndex = 3;
            dtpFechaPago.Value = new DateTime(2023, 12, 13, 14, 29, 39, 0);
            // 
            // frmControlPagos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(btnRegresar);
            Name = "frmControlPagos";
            Text = "Asignar Pagos";
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRegresar;
        private Panel panel1;
        private Button btnRegistrarPago;
        private TextBox txtID_Deuda;
        private Label label1;
        private GroupBox groupBox1;
        private ComboBox cmbTipoDePago;
        private Label label5;
        private Label label2;
        private DateTimePicker dtpFechaPago;
    }
}