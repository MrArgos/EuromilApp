using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace ClientGestor
{
    public partial class FormGestor : Form
    {
        private GrpcChannel channel;
        public FormGestor()
        {
            InitializeComponent();

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
                MessageBox.Show("Erro no serviço gRPC. Por favor tente de novo mais tarde ou contacte o administrador do serviço.",
                                    "Erro no serviço gRPC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRegistarChaveVencedora_Click(object sender, EventArgs e)
        {
            Hide();
            using (FormRegistarChaveVencedora fr = new FormRegistarChaveVencedora(channel))
                fr.ShowDialog();
            Show();
        }

        private void buttonListarVencedores_Click(object sender, EventArgs e)
        {
            Hide();
            using (FormListarVencedores fv = new FormListarVencedores(channel))
                fv.ShowDialog();
            Show();
        }
    }
}
