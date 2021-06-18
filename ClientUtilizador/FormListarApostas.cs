﻿using System;
using System.Net.Http;
using System.Windows.Forms;
using ClientUser;
using Grpc.Core;
using Grpc.Net.Client;

namespace ClientUtilizador
{
    public partial class FormListarApostas : Form
    {
        public FormListarApostas(string userName, GrpcChannel channel)
        {
            InitializeComponent();

            try
            {
                var client = new Apostas.ApostasClient(channel);
                var reply = client.ListarApostas(new PedidoListaApostas { Nome = userName });

                foreach (var r in reply.Aposta)
                {
                    listViewApostas.Items.Add(new ListViewItem(new[] { r.Nome, r.Chave, r.Data }));
                }
            }
            catch (RpcException e)
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show("Erro no serviço gRPC. Por favor tente de novo mais tarde ou contacte o administrador do serviço.",
                    "Erro no serviço gRPC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
