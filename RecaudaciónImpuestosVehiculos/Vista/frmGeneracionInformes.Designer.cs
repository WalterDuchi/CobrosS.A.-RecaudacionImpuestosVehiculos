namespace RecaudaciónImpuestosVehiculos
{
    partial class frmGeneracionInformes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeneracionInformes));
            btnRegresar = new Button();
            label2 = new Label();
            cmbTipoInforme = new ComboBox();
            groupBox1 = new GroupBox();
            btnGenerarInforme = new Button();
            dgvDatosInforme = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatosInforme).BeginInit();
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
            btnRegresar.TabIndex = 3;
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click_1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(12, 18);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 2;
            label2.Text = "Tipo de informe";
            // 
            // cmbTipoInforme
            // 
            cmbTipoInforme.Anchor = AnchorStyles.Top;
            cmbTipoInforme.FormattingEnabled = true;
            cmbTipoInforme.Items.AddRange(new object[] { "Todos", "Pagos Realizados", "Pagos Atrasados" });
            cmbTipoInforme.Location = new Point(131, 16);
            cmbTipoInforme.Name = "cmbTipoInforme";
            cmbTipoInforme.Size = new Size(543, 23);
            cmbTipoInforme.TabIndex = 3;
            cmbTipoInforme.SelectedIndexChanged += cmbTipoInforme_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnGenerarInforme);
            groupBox1.Controls.Add(cmbTipoInforme);
            groupBox1.Location = new Point(10, 40);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(679, 116);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // btnGenerarInforme
            // 
            btnGenerarInforme.Anchor = AnchorStyles.Top;
            btnGenerarInforme.Location = new Point(280, 60);
            btnGenerarInforme.Name = "btnGenerarInforme";
            btnGenerarInforme.Size = new Size(159, 30);
            btnGenerarInforme.TabIndex = 5;
            btnGenerarInforme.Text = "Generar Informe";
            btnGenerarInforme.UseVisualStyleBackColor = true;
            btnGenerarInforme.Click += btnGenerarInforme_Click;
            // 
            // dgvDatosInforme
            // 
            dgvDatosInforme.AllowUserToAddRows = false;
            dgvDatosInforme.AllowUserToDeleteRows = false;
            dgvDatosInforme.AllowUserToResizeColumns = false;
            dgvDatosInforme.AllowUserToResizeRows = false;
            dgvDatosInforme.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDatosInforme.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            dgvDatosInforme.ColumnHeadersHeight = 29;
            dgvDatosInforme.Location = new Point(10, 162);
            dgvDatosInforme.Name = "dgvDatosInforme";
            dgvDatosInforme.ReadOnly = true;
            dgvDatosInforme.RowHeadersWidth = 51;
            dgvDatosInforme.RowTemplate.Height = 25;
            dgvDatosInforme.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatosInforme.Size = new Size(679, 166);
            dgvDatosInforme.TabIndex = 4;
            dgvDatosInforme.CellContentClick += dgvDatosInforme_CellContentClick;
            // 
            // frmGeneracionInformes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(700, 338);
            Controls.Add(dgvDatosInforme);
            Controls.Add(groupBox1);
            Controls.Add(btnRegresar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmGeneracionInformes";
            Text = "Generacion de Informes";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatosInforme).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRegresar;
        private Label label2;
        private ComboBox cmbTipoInforme;
        private GroupBox groupBox1;
        private Button btnGenerarInforme;
        private DataGridView dgvDatosInforme;
    }
}