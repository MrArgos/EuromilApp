using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClientGestor
{
    public partial class FormListarVencedores : Form
    {
        public FormListarVencedores()
        {
            InitializeComponent();

            try
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var client = new Apostas.ApostasClient(channel);
                var reply = client.ListarApostasVencedoras(new PedidoApostasVencedoras());

                foreach (var aposta in reply.Aposta)
                {
                    listViewVencedores.Items.Add(new ListViewItem(new[] {  aposta.Nome, aposta.Chave, aposta.Data }));
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
