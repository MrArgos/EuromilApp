
namespace ClientAdministrador
{
    partial class FormListarApostas
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
            this.listViewListarApostas = new System.Windows.Forms.ListView();
            this.columnHeaderNome = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderChave = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderData = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listViewListarApostas
            // 
            this.listViewListarApostas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewListarApostas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNome,
            this.columnHeaderChave,
            this.columnHeaderData});
            this.listViewListarApostas.GridLines = true;
            this.listViewListarApostas.HideSelection = false;
            this.listViewListarApostas.Location = new System.Drawing.Point(12, 12);
            this.listViewListarApostas.Name = "listViewListarApostas";
            this.listViewListarApostas.Size = new System.Drawing.Size(456, 430);
            this.listViewListarApostas.TabIndex = 0;
            this.listViewListarApostas.UseCompatibleStateImageBehavior = false;
            this.listViewListarApostas.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNome
            // 
            this.columnHeaderNome.Text = "Nome";
            this.columnHeaderNome.Width = 150;
            // 
            // columnHeaderChave
            // 
            this.columnHeaderChave.Text = "Chave";
            this.columnHeaderChave.Width = 150;
            // 
            // columnHeaderData
            // 
            this.columnHeaderData.Text = "Data";
            this.columnHeaderData.Width = 150;
            // 
            // FormListarApostas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 454);
            this.Controls.Add(this.listViewListarApostas);
            this.Name = "FormListarApostas";
            this.Text = "FormListarApostas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewListarApostas;
        private System.Windows.Forms.ColumnHeader columnHeaderNome;
        private System.Windows.Forms.ColumnHeader columnHeaderChave;
        private System.Windows.Forms.ColumnHeader columnHeaderData;
    }
}