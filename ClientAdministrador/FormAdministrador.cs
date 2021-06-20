using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace ClientAdministrador
{
    public partial class FormAdministrador : Form
    {
        private GrpcChannel channel;
        public FormAdministrador()
        {
            InitializeComponent();

            // Criar o canal Grpc para ligação ao servidor
            try
            {
                var httpHandler = new HttpClientHandler();
                httpHandler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                channel = GrpcChannel.ForAddress("https://25.91.141.24:5001",
                    new GrpcChannelOptions { HttpHandler = httpHandler });
            }
            catch (RpcException)
            {
                MessageBox.Show("Erro no serviço gRPC. Por favor tente de novo mais tarde " +
                                "ou contacte o administrador do serviço.",
                    "Erro no serviço gRPC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Fazer o pedido para Arquivar as apostas (todas as não arquivadas)
        private void buttonArquivar_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new Apostas.ApostasClient(channel);
                var reply = client.ArquivarApostas(new PedidoArquivar());
                MessageBox.Show(reply.Sucesso ? "Apostas arquivadas com Sucesso." : "Erro a arquivar apostas.");
            }
            catch (RpcException)
            {
                MessageBox.Show("Erro no serviço gRPC. Por favor tente de novo mais tarde " +
                                "ou contacte o administrador do serviço.",
                    "Erro no serviço gRPC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Abrir janela para a Lista de Apostas não arquivadas
        private void buttonListarApostas_Click(object sender, EventArgs e)
        {
            Hide();
            using (FormListarApostas fla = new FormListarApostas(channel))
                fla.ShowDialog();
            Show();
        }

        // Abrir janela para a Lista de Utilizadores com apostas não arquivadas
        private void buttonListarUtilizadores_Click(object sender, EventArgs e)
        {
            Hide();
            using (FormListarUtilizadores flu = new FormListarUtilizadores(channel))
                flu.ShowDialog();
            Show();
        }
    }
}
