using Grpc.Core;
using Grpc.Net.Client;
using System.Windows.Forms;

namespace ClientAdministrador
{
    public partial class FormListarApostas : Form
    {
        public FormListarApostas(GrpcChannel channel)
        {
            InitializeComponent();

            try
            {
                var client = new Apostas.ApostasClient(channel);
                var reply = client.ListarApostas(new PedidoListaApostas { Nome = "" });

                foreach (var aposta in reply.Aposta)
                {
                    listViewListarApostas.Items.Add(new ListViewItem(new[] {  aposta.Chave, aposta.Nome, aposta.Data }));
                }
            }
            catch (RpcException)
            {
                MessageBox.Show("Erro no serviço gRPC. Por favor tente de novo mais tarde ou contacte o administrador do serviço.",
                    "Erro no serviço gRPC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
