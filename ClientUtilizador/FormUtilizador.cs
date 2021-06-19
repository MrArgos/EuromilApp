using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace ClientUtilizador
{

    public partial class FormUtilizador : Form
    {
        private GrpcChannel channel;
        public FormUtilizador()
        {
            InitializeComponent();

            // Criar o canal Grpc para ligação ao servidor
            try
            {
                var httpHandler = new HttpClientHandler();
                httpHandler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                channel = GrpcChannel.ForAddress("https://192.168.1.93:5001",
                    new GrpcChannelOptions { HttpHandler = httpHandler });
            }
            catch (RpcException)
            {
                MessageBox.Show("Erro no serviço gRPC. Por favor tente de novo mais tarde " +
                                "ou contacte o administrador do serviço.",
                                    "Erro no serviço gRPC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            // Verificar tamanho do nome inserido
            if (textBoxNome.Text.Length >= 3 || textBoxNome.Text.Length < 50)
            {
                // Abrir janela do menu do Cliente Utilizador
                Hide();
                using (FormMenu fm = new FormMenu(textBoxNome.Text, channel))
                    fm.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Insira um nome entre 3 a 50 caracteres.", 
                    "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
