
namespace ClientUtilizador
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
            this.listViewApostas = new System.Windows.Forms.ListView();
            this.columnHeaderNome = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderChave = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderData = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listViewApostas
            // 
            this.listViewApostas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewApostas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNome,
            this.columnHeaderChave,
            this.columnHeaderData});
            this.listViewApostas.GridLines = true;
            this.listViewApostas.HideSelection = false;
            this.listViewApostas.Location = new System.Drawing.Point(12, 12);
            this.listViewApostas.Name = "listViewApostas";
            this.listViewApostas.Size = new System.Drawing.Size(606, 431);
            this.listViewApostas.TabIndex = 0;
            this.listViewApostas.UseCompatibleStateImageBehavior = false;
            this.listViewApostas.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNome
            // 
            this.columnHeaderNome.Text = "Nome";
            this.columnHeaderNome.Width = 200;
            // 
            // columnHeaderChave
            // 
            this.columnHeaderChave.Text = "Chave";
            this.columnHeaderChave.Width = 200;
            // 
            // columnHeaderData
            // 
            this.columnHeaderData.Text = "Data";
            this.columnHeaderData.Width = 200;
            // 
            // FormListarApostas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 455);
            this.Controls.Add(this.listViewApostas);
            this.Name = "FormListarApostas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lista de Apostas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewApostas;
        private System.Windows.Forms.ColumnHeader columnHeaderNome;
        private System.Windows.Forms.ColumnHeader columnHeaderChave;
        private System.Windows.Forms.ColumnHeader columnHeaderData;
    }
}