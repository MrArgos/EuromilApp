using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientAdministrador
{
    public partial class FormAdministrador : Form
    {
        public FormAdministrador()
        {
            InitializeComponent();
        }

        private void buttonArquivar_Click(object sender, EventArgs e)
        {
            try
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var client = new Apostas.ApostasClient(channel);

                var reply = client.ArquivarApostas(new PedidoArquivar());
                MessageBox.Show(reply.Sucesso ? "Sucesso" : "Erro");
            }
            catch (RpcException)
            {
                MessageBox.Show("Erro no serviço gRPC. Por favor tente de novo mais tarde ou contacte o administrador do serviço.",
                    "Erro no serviço gRPC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonListarApostas_Click(object sender, EventArgs e)
        {
            FormListarApostas formListar = new FormListarApostas();
            formListar.ShowDialog();
        }
    }
}
