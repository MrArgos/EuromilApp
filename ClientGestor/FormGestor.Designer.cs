
namespace ClientGestor
{
    partial class FormGestor
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
            this.buttonRegistarChaveVencedora = new System.Windows.Forms.Button();
            this.buttonListarVencedores = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRegistarChaveVencedora
            // 
            this.buttonRegistarChaveVencedora.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonRegistarChaveVencedora.Location = new System.Drawing.Point(62, 40);
            this.buttonRegistarChaveVencedora.Name = "buttonRegistarChaveVencedora";
            this.buttonRegistarChaveVencedora.Size = new System.Drawing.Size(202, 30);
            this.buttonRegistarChaveVencedora.TabIndex = 0;
            this.buttonRegistarChaveVencedora.Text = "Registar Chave Vencedora";
            this.buttonRegistarChaveVencedora.UseVisualStyleBackColor = true;
            this.buttonRegistarChaveVencedora.Click += new System.EventHandler(this.buttonRegistarChaveVencedora_Click);
            // 
            // buttonListarVencedores
            // 
            this.buttonListarVencedores.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonListarVencedores.Location = new System.Drawing.Point(62, 103);
            this.buttonListarVencedores.Name = "buttonListarVencedores";
            this.buttonListarVencedores.Size = new System.Drawing.Size(202, 30);
            this.buttonListarVencedores.TabIndex = 1;
            this.buttonListarVencedores.Text = "Ver Apostas Vencedoras";
            this.buttonListarVencedores.UseVisualStyleBackColor = true;
            this.buttonListarVencedores.Click += new System.EventHandler(this.buttonListarVencedores_Click);
            // 
            // FormGestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 182);
            this.Controls.Add(this.buttonListarVencedores);
            this.Controls.Add(this.buttonRegistarChaveVencedora);
            this.Name = "FormGestor";
            this.Text = "Cliente de Gestão";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRegistarChaveVencedora;
        private System.Windows.Forms.Button buttonListarVencedores;
    }
}

