using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGestor
{
    public partial class FormGestor : Form
    {
        public FormGestor()
        {
            InitializeComponent();
        }

        private void buttonRegistarChaveVencedora_Click(object sender, EventArgs e)
        {
            Hide();
            using (FormRegistarChaveVencedora fr = new FormRegistarChaveVencedora())
                fr.ShowDialog();
            Show();
        }

        private void buttonListarVencedores_Click(object sender, EventArgs e)
        {
            Hide();
            using (FormListarVencedores fv = new FormListarVencedores())
                fv.ShowDialog();
            Show();
        }
    }
}
