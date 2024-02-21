namespace RecaudaciónImpuestosVehiculos
{
    partial class frmEnvioCartas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvioCartas));
            btnRegresar = new Button();
            txtPlaca = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            btnBuscar = new Button();
            richTextBox = new RichTextBox();
            btnImprimir = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            btnRegresar.TabIndex = 2;
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // txtPlaca
            // 
            txtPlaca.Anchor = AnchorStyles.None;
            txtPlaca.Location = new Point(241, 135);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(225, 23);
            txtPlaca.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(269, 9);
            label1.Name = "label1";
            label1.Size = new Size(265, 45);
            label1.TabIndex = 10;
            label1.Text = "Envios de Cartas";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(192, 77);
            label2.Name = "label2";
            label2.Size = new Size(421, 15);
            label2.TabIndex = 11;
            label2.Text = "Ingrese la Placa del Vehículo para hallar la ultima notificación de pago enviada.";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(125, 138);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 13;
            label4.Text = "Placa del Vehículo";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(529, 176);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(221, 167);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.None;
            btnBuscar.Location = new Point(498, 135);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 18;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // richTextBox
            // 
            richTextBox.Anchor = AnchorStyles.None;
            richTextBox.Location = new Point(66, 176);
            richTextBox.Name = "richTextBox";
            richTextBox.ReadOnly = true;
            richTextBox.Size = new Size(457, 245);
            richTextBox.TabIndex = 19;
            richTextBox.Text = "";
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.None;
            btnImprimir.Location = new Point(529, 361);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(221, 50);
            btnImprimir.TabIndex = 20;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // frmEnvioCartas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(818, 503);
            Controls.Add(btnImprimir);
            Controls.Add(richTextBox);
            Controls.Add(btnBuscar);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPlaca);
            Controls.Add(btnRegresar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmEnvioCartas";
            Text = "Envio de cartas";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegresar;
        private TextBox txtPlaca;
        private Label label1;
        private Label label2;
        private Label label4;
        private PictureBox pictureBox1;
        private Button btnBuscar;
        private RichTextBox richTextBox;
        private Button btnImprimir;
    }
}