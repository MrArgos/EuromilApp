
namespace ClientGestor
{
    partial class FormListarVencedores
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
            this.listViewVencedores = new System.Windows.Forms.ListView();
            this.columnHeaderNome = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderChave = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderData = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listViewVencedores
            // 
            this.listViewVencedores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewVencedores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNome,
            this.columnHeaderChave,
            this.columnHeaderData});
            this.listViewVencedores.GridLines = true;
            this.listViewVencedores.HideSelection = false;
            this.listViewVencedores.Location = new System.Drawing.Point(12, 12);
            this.listViewVencedores.Name = "listViewVencedores";
            this.listViewVencedores.Size = new System.Drawing.Size(605, 337);
            this.listViewVencedores.TabIndex = 0;
            this.listViewVencedores.UseCompatibleStateImageBehavior = false;
            this.listViewVencedores.View = System.Windows.Forms.View.Details;
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
            // FormListarVencedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 361);
            this.Controls.Add(this.listViewVencedores);
            this.Name = "FormListarVencedores";
            this.Text = "Lista de Vencedores";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewVencedores;
        private System.Windows.Forms.ColumnHeader columnHeaderNome;
        private System.Windows.Forms.ColumnHeader columnHeaderChave;
        private System.Windows.Forms.ColumnHeader columnHeaderData;
    }
}