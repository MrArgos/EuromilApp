using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClientUser
{
    public partial class FormUtilizador : Form
    {
        public FormUtilizador()
        {
            InitializeComponent();
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            if (textBoxNome.Text.Length >= 3 || textBoxNome.Text.Length < 50)
            {
                Hide();
                using (FormMenu fm = new FormMenu(textBoxNome.Text))
                    fm.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Insira um nome entre 3 a 50 caracteres.", "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
