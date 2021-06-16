
namespace ClientUser
{
    partial class FormMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.buttonApostar = new System.Windows.Forms.Button();
            this.buttonListarApostas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bem-vindo";
            // 
            // labelNome
            // 
            this.labelNome.AutoEllipsis = true;
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNome.Location = new System.Drawing.Point(158, 36);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(33, 15);
            this.labelNome.TabIndex = 1;
            this.labelNome.Text = "User";
            // 
            // buttonApostar
            // 
            this.buttonApostar.Location = new System.Drawing.Point(75, 77);
            this.buttonApostar.Name = "buttonApostar";
            this.buttonApostar.Size = new System.Drawing.Size(145, 29);
            this.buttonApostar.TabIndex = 2;
            this.buttonApostar.Text = "Apostar";
            this.buttonApostar.UseVisualStyleBackColor = true;
            this.buttonApostar.Click += new System.EventHandler(this.buttonApostar_Click);
            // 
            // buttonListarApostas
            // 
            this.buttonListarApostas.Location = new System.Drawing.Point(75, 130);
            this.buttonListarApostas.Name = "buttonListarApostas";
            this.buttonListarApostas.Size = new System.Drawing.Size(145, 29);
            this.buttonListarApostas.TabIndex = 3;
            this.buttonListarApostas.Text = "Ver as minhas Apostas";
            this.buttonListarApostas.UseVisualStyleBackColor = true;
            this.buttonListarApostas.Click += new System.EventHandler(this.buttonListarApostas_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 201);
            this.Controls.Add(this.buttonListarApostas);
            this.Controls.Add(this.buttonApostar);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.label1);
            this.Name = "FormMenu";
            this.Text = "Cliente Utilizador: Área Pessoal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Button buttonApostar;
        private System.Windows.Forms.Button buttonListarApostas;
    }
}