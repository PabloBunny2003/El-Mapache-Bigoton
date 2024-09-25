namespace Mapache_Bigoton
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            btn_Salida = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            btnAgregarCita = new Button();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btn_Salida
            // 
            btn_Salida.BackColor = Color.FromArgb(192, 0, 0);
            btn_Salida.BackgroundImage = (Image)resources.GetObject("btn_Salida.BackgroundImage");
            btn_Salida.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Salida.Location = new Point(715, 25);
            btn_Salida.Margin = new Padding(2, 2, 2, 2);
            btn_Salida.Name = "btn_Salida";
            btn_Salida.Size = new Size(39, 30);
            btn_Salida.TabIndex = 11;
            btn_Salida.UseVisualStyleBackColor = false;
            btn_Salida.Click += btn_Salida_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            button1.Location = new Point(470, 321);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(132, 40);
            button1.TabIndex = 10;
            button1.Text = "Ver Citas";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(164, 67);
            pictureBox1.Margin = new Padding(2, 2, 2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(549, 238);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // btnAgregarCita
            // 
            btnAgregarCita.BackColor = Color.White;
            btnAgregarCita.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnAgregarCita.Location = new Point(260, 321);
            btnAgregarCita.Margin = new Padding(2, 2, 2, 2);
            btnAgregarCita.Name = "btnAgregarCita";
            btnAgregarCita.Size = new Size(132, 40);
            btnAgregarCita.TabIndex = 8;
            btnAgregarCita.Text = "Agregar Cita";
            btnAgregarCita.UseVisualStyleBackColor = false;
            btnAgregarCita.Click += btnAgregarCita_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Historic", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(33, 12);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(172, 15);
            label2.TabIndex = 7;
            label2.Text = "\"Tú estilo, nuestra pasión\"";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(253, 24);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(331, 47);
            label1.TabIndex = 6;
            label1.Text = "El Mapache Bigotón";
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(799, 372);
            Controls.Add(btn_Salida);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(btnAgregarCita);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Principal";
            Text = "Principal";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Salida;
        private Button button1;
        private PictureBox pictureBox1;
        private Button btnAgregarCita;
        private Label label2;
        private Label label1;
    }
}