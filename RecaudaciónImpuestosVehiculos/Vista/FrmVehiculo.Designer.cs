namespace RecaudaciónImpuestosVehiculos.Vista
{
    partial class FrmVehiculos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVehiculos));
            btnGuardarVehiculo = new Button();
            ValorLabel = new Label();
            AñoLabel = new Label();
            CilindradaLabel = new Label();
            ModeloLabel = new Label();
            PlacaLabel = new Label();
            DNIPersonaLabel = new Label();
            ValorTextBox = new TextBox();
            AñoTextBox = new TextBox();
            CilindradaTextBox = new TextBox();
            PlacaTextBox = new TextBox();
            DNIPersonaTextBox = new TextBox();
            label1 = new Label();
            btnRegresar = new Button();
            ModeloTextBox = new TextBox();
            SuspendLayout();
            // 
            // btnGuardarVehiculo
            // 
            btnGuardarVehiculo.Anchor = AnchorStyles.Bottom;
            btnGuardarVehiculo.BackColor = SystemColors.Control;
            btnGuardarVehiculo.Location = new Point(335, 381);
            btnGuardarVehiculo.Margin = new Padding(3, 4, 3, 4);
            btnGuardarVehiculo.Name = "btnGuardarVehiculo";
            btnGuardarVehiculo.Size = new Size(187, 52);
            btnGuardarVehiculo.TabIndex = 0;
            btnGuardarVehiculo.Text = "Guardar Vehiculo";
            btnGuardarVehiculo.UseVisualStyleBackColor = false;
            btnGuardarVehiculo.Click += btnGuardarVehiculo_Click;
            // 
            // ValorLabel
            // 
            ValorLabel.Anchor = AnchorStyles.None;
            ValorLabel.AutoSize = true;
            ValorLabel.Location = new Point(89, 151);
            ValorLabel.Name = "ValorLabel";
            ValorLabel.Size = new Size(43, 20);
            ValorLabel.TabIndex = 1;
            ValorLabel.Text = "Valor";
            // 
            // AñoLabel
            // 
            AñoLabel.Anchor = AnchorStyles.None;
            AñoLabel.AutoSize = true;
            AñoLabel.Location = new Point(94, 224);
            AñoLabel.Name = "AñoLabel";
            AñoLabel.Size = new Size(36, 20);
            AñoLabel.TabIndex = 2;
            AñoLabel.Text = "Año";
            // 
            // CilindradaLabel
            // 
            CilindradaLabel.Anchor = AnchorStyles.None;
            CilindradaLabel.AutoSize = true;
            CilindradaLabel.Location = new Point(77, 292);
            CilindradaLabel.Name = "CilindradaLabel";
            CilindradaLabel.Size = new Size(77, 20);
            CilindradaLabel.TabIndex = 3;
            CilindradaLabel.Text = "Cilindrada";
            // 
            // ModeloLabel
            // 
            ModeloLabel.Anchor = AnchorStyles.None;
            ModeloLabel.AutoSize = true;
            ModeloLabel.Location = new Point(521, 151);
            ModeloLabel.Name = "ModeloLabel";
            ModeloLabel.Size = new Size(61, 20);
            ModeloLabel.TabIndex = 4;
            ModeloLabel.Text = "Modelo";
            // 
            // PlacaLabel
            // 
            PlacaLabel.Anchor = AnchorStyles.None;
            PlacaLabel.AutoSize = true;
            PlacaLabel.Location = new Point(521, 223);
            PlacaLabel.Name = "PlacaLabel";
            PlacaLabel.Size = new Size(44, 20);
            PlacaLabel.TabIndex = 5;
            PlacaLabel.Text = "Placa";
            // 
            // DNIPersonaLabel
            // 
            DNIPersonaLabel.Anchor = AnchorStyles.None;
            DNIPersonaLabel.AutoSize = true;
            DNIPersonaLabel.Location = new Point(528, 292);
            DNIPersonaLabel.Name = "DNIPersonaLabel";
            DNIPersonaLabel.Size = new Size(35, 20);
            DNIPersonaLabel.TabIndex = 6;
            DNIPersonaLabel.Text = "DNI";
            // 
            // ValorTextBox
            // 
            ValorTextBox.Anchor = AnchorStyles.None;
            ValorTextBox.Location = new Point(175, 147);
            ValorTextBox.Margin = new Padding(3, 4, 3, 4);
            ValorTextBox.Name = "ValorTextBox";
            ValorTextBox.Size = new Size(146, 27);
            ValorTextBox.TabIndex = 7;
            // 
            // AñoTextBox
            // 
            AñoTextBox.Anchor = AnchorStyles.None;
            AñoTextBox.Location = new Point(175, 220);
            AñoTextBox.Margin = new Padding(3, 4, 3, 4);
            AñoTextBox.Name = "AñoTextBox";
            AñoTextBox.Size = new Size(146, 27);
            AñoTextBox.TabIndex = 8;
            // 
            // CilindradaTextBox
            // 
            CilindradaTextBox.Anchor = AnchorStyles.None;
            CilindradaTextBox.Location = new Point(175, 288);
            CilindradaTextBox.Margin = new Padding(3, 4, 3, 4);
            CilindradaTextBox.Name = "CilindradaTextBox";
            CilindradaTextBox.Size = new Size(146, 27);
            CilindradaTextBox.TabIndex = 9;
            // 
            // PlacaTextBox
            // 
            PlacaTextBox.Anchor = AnchorStyles.None;
            PlacaTextBox.Location = new Point(602, 221);
            PlacaTextBox.Margin = new Padding(3, 4, 3, 4);
            PlacaTextBox.Name = "PlacaTextBox";
            PlacaTextBox.Size = new Size(142, 27);
            PlacaTextBox.TabIndex = 11;
            // 
            // DNIPersonaTextBox
            // 
            DNIPersonaTextBox.Anchor = AnchorStyles.None;
            DNIPersonaTextBox.Location = new Point(602, 289);
            DNIPersonaTextBox.Margin = new Padding(3, 4, 3, 4);
            DNIPersonaTextBox.Name = "DNIPersonaTextBox";
            DNIPersonaTextBox.Size = new Size(142, 27);
            DNIPersonaTextBox.TabIndex = 12;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Heading", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(89, 41);
            label1.Name = "label1";
            label1.Size = new Size(387, 39);
            label1.TabIndex = 13;
            label1.Text = "Ingresar los Datos del Vehiculo";
            // 
            // btnRegresar
            // 
            btnRegresar.Image = (Image)resources.GetObject("btnRegresar.Image");
            btnRegresar.Location = new Point(0, 0);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(55, 55);
            btnRegresar.TabIndex = 14;
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // ModeloTextBox
            // 
            ModeloTextBox.Anchor = AnchorStyles.None;
            ModeloTextBox.Location = new Point(602, 148);
            ModeloTextBox.Margin = new Padding(3, 4, 3, 4);
            ModeloTextBox.Multiline = true;
            ModeloTextBox.Name = "ModeloTextBox";
            ModeloTextBox.Size = new Size(142, 27);
            ModeloTextBox.TabIndex = 10;
            // 
            // FrmVehiculos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(914, 600);
            Controls.Add(btnRegresar);
            Controls.Add(label1);
            Controls.Add(DNIPersonaTextBox);
            Controls.Add(PlacaTextBox);
            Controls.Add(ModeloTextBox);
            Controls.Add(CilindradaTextBox);
            Controls.Add(AñoTextBox);
            Controls.Add(ValorTextBox);
            Controls.Add(DNIPersonaLabel);
            Controls.Add(PlacaLabel);
            Controls.Add(ModeloLabel);
            Controls.Add(CilindradaLabel);
            Controls.Add(AñoLabel);
            Controls.Add(ValorLabel);
            Controls.Add(btnGuardarVehiculo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmVehiculos";
            Text = "Vehiculos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardarVehiculo;
        private Label ValorLabel;
        private Label AñoLabel;
        private Label CilindradaLabel;
        private Label ModeloLabel;
        private Label PlacaLabel;
        private Label DNIPersonaLabel;
        private TextBox ValorTextBox;
        private TextBox AñoTextBox;
        private TextBox CilindradaTextBox;
        private TextBox PlacaTextBox;
        private TextBox DNIPersonaTextBox;
        private Label label1;
        private Button btnRegresar;
        private TextBox ModeloTextBox;
        private ComboBox comboBox1;
    }
}