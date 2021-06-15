
namespace ClientAdministrador
{
    partial class FormAdministrador
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
            this.buttonArquivar = new System.Windows.Forms.Button();
            this.buttonListarApostas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonArquivar
            // 
            this.buttonArquivar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonArquivar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonArquivar.Location = new System.Drawing.Point(92, 36);
            this.buttonArquivar.Name = "buttonArquivar";
            this.buttonArquivar.Size = new System.Drawing.Size(152, 23);
            this.buttonArquivar.TabIndex = 0;
            this.buttonArquivar.Text = "Arquivar Apostas";
            this.buttonArquivar.UseVisualStyleBackColor = true;
            this.buttonArquivar.Click += new System.EventHandler(this.buttonArquivar_Click);
            // 
            // buttonListarApostas
            // 
            this.buttonListarApostas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonListarApostas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonListarApostas.Location = new System.Drawing.Point(91, 81);
            this.buttonListarApostas.Name = "buttonListarApostas";
            this.buttonListarApostas.Size = new System.Drawing.Size(153, 23);
            this.buttonListarApostas.TabIndex = 1;
            this.buttonListarApostas.Text = "Ver Apostas Registadas";
            this.buttonListarApostas.UseVisualStyleBackColor = true;
            this.buttonListarApostas.Click += new System.EventHandler(this.buttonListarApostas_Click);
            // 
            // FormAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 136);
            this.Controls.Add(this.buttonListarApostas);
            this.Controls.Add(this.buttonArquivar);
            this.Name = "FormAdministrador";
            this.Text = "Cliente Administrador";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonArquivar;
        private System.Windows.Forms.Button buttonListarApostas;
    }
}

