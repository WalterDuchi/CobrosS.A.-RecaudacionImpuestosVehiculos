namespace RecaudaciónImpuestosVehiculos.Vista
{
    partial class frmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarios));
            GuardarUsuarioButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            NombresTextBox = new TextBox();
            ApellidosTextBox = new TextBox();
            CorreoElectronicoTextBox = new TextBox();
            TelefonoTextBox = new TextBox();
            DireccionTextBox = new TextBox();
            DNITextBox = new TextBox();
            btnRegresar = new Button();
            label7 = new Label();
            SuspendLayout();
            // 
            // GuardarUsuarioButton
            // 
            GuardarUsuarioButton.Anchor = AnchorStyles.Bottom;
            GuardarUsuarioButton.Location = new Point(354, 444);
            GuardarUsuarioButton.Margin = new Padding(3, 4, 3, 4);
            GuardarUsuarioButton.Name = "GuardarUsuarioButton";
            GuardarUsuarioButton.Size = new Size(176, 47);
            GuardarUsuarioButton.TabIndex = 0;
            GuardarUsuarioButton.Text = "Guardar Usuario";
            GuardarUsuarioButton.UseVisualStyleBackColor = true;
            GuardarUsuarioButton.Click += GuardarUsuarioButton_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(114, 187);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(114, 239);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 2;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(82, 304);
            label3.Name = "label3";
            label3.Size = new Size(132, 20);
            label3.TabIndex = 3;
            label3.Text = "Correo Electronico";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(527, 187);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 4;
            label4.Text = "Telefono";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(521, 243);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 5;
            label5.Text = "Direccion";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(527, 304);
            label6.Name = "label6";
            label6.Size = new Size(35, 20);
            label6.TabIndex = 6;
            label6.Text = "DNI";
            // 
            // NombresTextBox
            // 
            NombresTextBox.Anchor = AnchorStyles.None;
            NombresTextBox.Location = new Point(215, 183);
            NombresTextBox.Margin = new Padding(3, 4, 3, 4);
            NombresTextBox.Name = "NombresTextBox";
            NombresTextBox.Size = new Size(166, 27);
            NombresTextBox.TabIndex = 7;
            // 
            // ApellidosTextBox
            // 
            ApellidosTextBox.Anchor = AnchorStyles.None;
            ApellidosTextBox.Location = new Point(215, 239);
            ApellidosTextBox.Margin = new Padding(3, 4, 3, 4);
            ApellidosTextBox.Name = "ApellidosTextBox";
            ApellidosTextBox.Size = new Size(166, 27);
            ApellidosTextBox.TabIndex = 8;
            // 
            // CorreoElectronicoTextBox
            // 
            CorreoElectronicoTextBox.Anchor = AnchorStyles.None;
            CorreoElectronicoTextBox.Location = new Point(209, 304);
            CorreoElectronicoTextBox.Margin = new Padding(3, 4, 3, 4);
            CorreoElectronicoTextBox.Name = "CorreoElectronicoTextBox";
            CorreoElectronicoTextBox.Size = new Size(166, 27);
            CorreoElectronicoTextBox.TabIndex = 9;
            // 
            // TelefonoTextBox
            // 
            TelefonoTextBox.Anchor = AnchorStyles.None;
            TelefonoTextBox.Location = new Point(603, 183);
            TelefonoTextBox.Margin = new Padding(3, 4, 3, 4);
            TelefonoTextBox.Name = "TelefonoTextBox";
            TelefonoTextBox.Size = new Size(163, 27);
            TelefonoTextBox.TabIndex = 10;
            // 
            // DireccionTextBox
            // 
            DireccionTextBox.Anchor = AnchorStyles.None;
            DireccionTextBox.Location = new Point(603, 239);
            DireccionTextBox.Margin = new Padding(3, 4, 3, 4);
            DireccionTextBox.Name = "DireccionTextBox";
            DireccionTextBox.Size = new Size(163, 27);
            DireccionTextBox.TabIndex = 11;
            // 
            // DNITextBox
            // 
            DNITextBox.Anchor = AnchorStyles.None;
            DNITextBox.Location = new Point(603, 300);
            DNITextBox.Margin = new Padding(3, 4, 3, 4);
            DNITextBox.Name = "DNITextBox";
            DNITextBox.Size = new Size(164, 27);
            DNITextBox.TabIndex = 12;
            // 
            // btnRegresar
            // 
            btnRegresar.Image = (Image)resources.GetObject("btnRegresar.Image");
            btnRegresar.Location = new Point(0, 0);
            btnRegresar.Margin = new Padding(3, 4, 3, 4);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(55, 55);
            btnRegresar.TabIndex = 13;
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Sitka Small", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(209, 91);
            label7.Name = "label7";
            label7.Size = new Size(352, 49);
            label7.TabIndex = 14;
            label7.Text = "Ingresar los datos";
            // 
            // frmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(914, 600);
            Controls.Add(label7);
            Controls.Add(btnRegresar);
            Controls.Add(DNITextBox);
            Controls.Add(DireccionTextBox);
            Controls.Add(TelefonoTextBox);
            Controls.Add(CorreoElectronicoTextBox);
            Controls.Add(ApellidosTextBox);
            Controls.Add(NombresTextBox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(GuardarUsuarioButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmUsuarios";
            Text = "Usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GuardarUsuarioButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox NombresTextBox;
        private TextBox ApellidosTextBox;
        private TextBox CorreoElectronicoTextBox;
        private TextBox TelefonoTextBox;
        private TextBox DireccionTextBox;
        private TextBox DNITextBox;
        private Button btnRegresar;
        private Label label7;
    }
}