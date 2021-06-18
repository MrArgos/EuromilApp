using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientAdministrador
{
    public partial class FormAdministrador : Form
    {
        private GrpcChannel channel;
        public FormAdministrador()
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

        private void buttonArquivar_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new Apostas.ApostasClient(channel);
                var reply = client.ArquivarApostas(new PedidoArquivar());
                MessageBox.Show(reply.Sucesso ? "Apostas foram arquivadas com Sucesso." : "Erro a arquivar apostas.");
            }
            catch (RpcException)
            {
                MessageBox.Show("Erro no serviço gRPC. Por favor tente de novo mais tarde ou contacte o administrador do serviço.",
                    "Erro no serviço gRPC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonListarApostas_Click(object sender, EventArgs e)
        {
            Hide();
            using (FormListarApostas fla = new FormListarApostas(channel))
                fla.ShowDialog();
            Show();
        }

        private void buttonListarUtilizadores_Click(object sender, EventArgs e)
        {
            Hide();
            using (FormListarUtilizadores flu = new FormListarUtilizadores(channel))
                flu.ShowDialog();
            Show();
        }
    }
}
