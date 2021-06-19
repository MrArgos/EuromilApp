using Grpc.Core;
using Grpc.Net.Client;
using System.Windows.Forms;

namespace ClientAdministrador
{
    public partial class FormListarUtilizadores : Form
    {
        public FormListarUtilizadores(GrpcChannel channel)
        {
            InitializeComponent();

            // Fazer o pedido para ver os Utilizadores com apostas em jogo
            try
            {
                var client = new Apostas.ApostasClient(channel);
                var reply = client.ListarUtilizadores(new PedidoListaUtilizadores());

                // Apresentar a lista recebida do servidor
                foreach (var user in reply.Utilizador)
                {
                    listViewUtilizadores.Items.Add(new ListViewItem(new[] { user }));
                }
            }
            catch (RpcException)
            {
                MessageBox.Show("Erro no serviço gRPC. Por favor tente de novo mais tarde " +
                                "ou contacte o administrador do serviço.",
                    "Erro no serviço gRPC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
