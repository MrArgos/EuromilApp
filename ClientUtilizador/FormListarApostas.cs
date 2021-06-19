using Grpc.Core;
using Grpc.Net.Client;
using System.Windows.Forms;

namespace ClientUtilizador
{
    public partial class FormListarApostas : Form
    {
        public FormListarApostas(string userName, GrpcChannel channel)
        {
            InitializeComponent();

            try
            {
                // enviar nome do utilizador para o servidor
                // no pedido de lista de apostas
                var client = new Apostas.ApostasClient(channel);
                var reply = client.ListarApostas(new PedidoListaApostas { Nome = userName });

                // Apresentar a lista de apostas do utilizador
                foreach (var r in reply.Aposta)
                {
                    listViewApostas.Items.Add(new ListViewItem(new[] { r.Nome, r.Chave, r.Data }));
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
