
namespace ClientAdministrador
{
    partial class FormListarUtilizadores
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
            this.listViewUtilizadores = new System.Windows.Forms.ListView();
            this.columnHeaderNome = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listViewUtilizadores
            // 
            this.listViewUtilizadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewUtilizadores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNome});
            this.listViewUtilizadores.GridLines = true;
            this.listViewUtilizadores.HideSelection = false;
            this.listViewUtilizadores.Location = new System.Drawing.Point(12, 12);
            this.listViewUtilizadores.Name = "listViewUtilizadores";
            this.listViewUtilizadores.Size = new System.Drawing.Size(205, 335);
            this.listViewUtilizadores.TabIndex = 0;
            this.listViewUtilizadores.UseCompatibleStateImageBehavior = false;
            this.listViewUtilizadores.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNome
            // 
            this.columnHeaderNome.Text = "Nome";
            this.columnHeaderNome.Width = 200;
            // 
            // FormListarUtilizadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 359);
            this.Controls.Add(this.listViewUtilizadores);
            this.Name = "FormListarUtilizadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lista Utilizadores";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewUtilizadores;
        private System.Windows.Forms.ColumnHeader columnHeaderNome;
    }
}