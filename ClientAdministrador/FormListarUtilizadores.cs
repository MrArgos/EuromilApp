using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClientAdministrador
{
    public partial class FormListarUtilizadores : Form
    {
        public FormListarUtilizadores()
        {
            InitializeComponent();

            try
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var client = new Apostas.ApostasClient(channel);
                var reply = client.ListarUtilizadores(new PedidoListaUtilizadores());

                foreach (var user in reply.Utilizador)
                {
                    listViewUtilizadores.Items.Add(new ListViewItem(new[] { user }));
                }
            }
            catch (RpcException)
            {
                MessageBox.Show("Erro no serviço gRPC. Por favor tente de novo mais tarde ou contacte o administrador do serviço.",
                    "Erro no serviço gRPC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
