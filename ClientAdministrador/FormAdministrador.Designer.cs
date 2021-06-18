
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
            this.buttonListarUtilizadores = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonArquivar
            // 
            this.buttonArquivar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonArquivar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonArquivar.Location = new System.Drawing.Point(72, 36);
            this.buttonArquivar.Name = "buttonArquivar";
            this.buttonArquivar.Size = new System.Drawing.Size(203, 28);
            this.buttonArquivar.TabIndex = 0;
            this.buttonArquivar.Text = "Arquivar Apostas";
            this.buttonArquivar.UseVisualStyleBackColor = true;
            this.buttonArquivar.Click += new System.EventHandler(this.buttonArquivar_Click);
            // 
            // buttonListarApostas
            // 
            this.buttonListarApostas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonListarApostas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonListarApostas.Location = new System.Drawing.Point(71, 81);
            this.buttonListarApostas.Name = "buttonListarApostas";
            this.buttonListarApostas.Size = new System.Drawing.Size(204, 28);
            this.buttonListarApostas.TabIndex = 1;
            this.buttonListarApostas.Text = "Ver Apostas Registadas";
            this.buttonListarApostas.UseVisualStyleBackColor = true;
            this.buttonListarApostas.Click += new System.EventHandler(this.buttonListarApostas_Click);
            // 
            // buttonListarUtilizadores
            // 
            this.buttonListarUtilizadores.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonListarUtilizadores.Location = new System.Drawing.Point(72, 126);
            this.buttonListarUtilizadores.Name = "buttonListarUtilizadores";
            this.buttonListarUtilizadores.Size = new System.Drawing.Size(203, 28);
            this.buttonListarUtilizadores.TabIndex = 2;
            this.buttonListarUtilizadores.Text = "Ver Utilizadores Registados";
            this.buttonListarUtilizadores.UseVisualStyleBackColor = true;
            this.buttonListarUtilizadores.Click += new System.EventHandler(this.buttonListarUtilizadores_Click);
            // 
            // FormAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 212);
            this.Controls.Add(this.buttonListarUtilizadores);
            this.Controls.Add(this.buttonListarApostas);
            this.Controls.Add(this.buttonArquivar);
            this.Name = "FormAdministrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cliente Administrador";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonArquivar;
        private System.Windows.Forms.Button buttonListarApostas;
        private System.Windows.Forms.Button buttonListarUtilizadores;
    }
}

