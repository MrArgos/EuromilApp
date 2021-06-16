using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClientUser
{
    public partial class FormMenu : Form
    {
        private string userName;
        public FormMenu(string _userName)
        {
            InitializeComponent();
            userName = _userName;
            labelNome.Text = userName;
        }

        private void buttonApostar_Click(object sender, EventArgs e)
        {
            Hide();
            using (FormApostar fa = new FormApostar(userName))
                fa.ShowDialog();
            Show();
        }

        private void buttonListarApostas_Click(object sender, EventArgs e)
        {
            Hide();
            using (FormListarApostas fl = new FormListarApostas(userName))
                fl.ShowDialog();
            Show();
        }
    }
}
