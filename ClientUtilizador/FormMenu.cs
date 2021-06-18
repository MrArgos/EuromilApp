using Grpc.Net.Client;
using System;
using System.Windows.Forms;

namespace ClientUtilizador
{
    public partial class FormMenu : Form
    {
        private string userName;
        private GrpcChannel channel;
        public FormMenu(string _userName, GrpcChannel _channel)
        {
            InitializeComponent();
            userName = _userName;
            labelNome.Text = userName;
            channel = _channel;
        }

        private void buttonApostar_Click(object sender, EventArgs e)
        {
            Hide();
            using (FormApostar fa = new FormApostar(userName, channel))
                fa.ShowDialog();
            Show();
        }

        private void buttonListarApostas_Click(object sender, EventArgs e)
        {
            Hide();
            using (FormListarApostas fl = new FormListarApostas(userName, channel))
                fl.ShowDialog();
            Show();
        }
    }
}
