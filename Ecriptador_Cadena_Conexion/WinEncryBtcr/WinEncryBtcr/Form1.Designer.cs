namespace WinEncryBtcr
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TxtTextoEncrypt = new TextBox();
            RtxtResultado = new RichTextBox();
            BtnEjecutarEnc = new Button();
            BtnEjecutarDec = new Button();
            BtnEjecutarConSt = new Button();
            BtnEjecutarDecConSt = new Button();
            SuspendLayout();
            // 
            // TxtTextoEncrypt
            // 
            TxtTextoEncrypt.Location = new Point(82, 130);
            TxtTextoEncrypt.Name = "TxtTextoEncrypt";
            TxtTextoEncrypt.Size = new Size(648, 23);
            TxtTextoEncrypt.TabIndex = 0;
            // 
            // RtxtResultado
            // 
            RtxtResultado.Location = new Point(82, 234);
            RtxtResultado.Name = "RtxtResultado";
            RtxtResultado.Size = new Size(648, 96);
            RtxtResultado.TabIndex = 2;
            RtxtResultado.Text = "";
            // 
            // BtnEjecutarEnc
            // 
            BtnEjecutarEnc.Location = new Point(181, 178);
            BtnEjecutarEnc.Name = "BtnEjecutarEnc";
            BtnEjecutarEnc.Size = new Size(98, 23);
            BtnEjecutarEnc.TabIndex = 3;
            BtnEjecutarEnc.Text = "Ejecutar Enc";
            BtnEjecutarEnc.UseVisualStyleBackColor = true;
            BtnEjecutarEnc.Click += BtnEjecutarEnc_Click;
            // 
            // BtnEjecutarDec
            // 
            BtnEjecutarDec.Location = new Point(334, 178);
            BtnEjecutarDec.Name = "BtnEjecutarDec";
            BtnEjecutarDec.Size = new Size(98, 23);
            BtnEjecutarDec.TabIndex = 4;
            BtnEjecutarDec.Text = "Ejecutar Dec";
            BtnEjecutarDec.UseVisualStyleBackColor = true;
            BtnEjecutarDec.Click += BtnEjecutarDec_Click;
            // 
            // BtnEjecutarConSt
            // 
            BtnEjecutarConSt.Location = new Point(466, 178);
            BtnEjecutarConSt.Name = "BtnEjecutarConSt";
            BtnEjecutarConSt.Size = new Size(98, 23);
            BtnEjecutarConSt.TabIndex = 5;
            BtnEjecutarConSt.Text = "Ejecutar ConSt";
            BtnEjecutarConSt.UseVisualStyleBackColor = true;
            BtnEjecutarConSt.Click += BtnEjecutarConSt_Click;
            // 
            // BtnEjecutarDecConSt
            // 
            BtnEjecutarDecConSt.Location = new Point(589, 178);
            BtnEjecutarDecConSt.Name = "BtnEjecutarDecConSt";
            BtnEjecutarDecConSt.Size = new Size(127, 23);
            BtnEjecutarDecConSt.TabIndex = 6;
            BtnEjecutarDecConSt.Text = "Ejecutar DecConSt";
            BtnEjecutarDecConSt.UseVisualStyleBackColor = true;
            BtnEjecutarDecConSt.Click += BtnEjecutarDecConSt_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnEjecutarDecConSt);
            Controls.Add(BtnEjecutarConSt);
            Controls.Add(BtnEjecutarDec);
            Controls.Add(BtnEjecutarEnc);
            Controls.Add(RtxtResultado);
            Controls.Add(TxtTextoEncrypt);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtTextoEncrypt;
        private RichTextBox RtxtResultado;
        private Button BtnEjecutarEnc;
        private Button BtnEjecutarDec;
        private Button BtnEjecutarConSt;
        private Button BtnEjecutarDecConSt;
    }
}
