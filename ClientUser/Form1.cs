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

namespace ClientUser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aposta aposta = new Aposta { Nome = textBox1.Text, Chave = "1 2 3 4 5 + 6 7", Data = DateTime.Now.ToString() };

            PedidoAposta p = new PedidoAposta { Aposta = aposta };

            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Apostas.ApostasClient(channel);

            var reply = client.RegistarAposta(p);
            MessageBox.Show(reply.Sucesso ? "Sucesso" : "Erro");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Apostas.ApostasClient(channel);
            var reply = client.ListarApostas(new PedidoListaApostas {Nome = textBox1.Text });

            foreach (var r in reply.Aposta)
            {
                listView1.Items.Add(new ListViewItem(new[]{ r.Nome, r.Chave, r.Data }));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Apostas.ApostasClient(channel);
            var reply = client.ArquivarApostas(new PedidoArquivar { });
            MessageBox.Show(reply.Sucesso ? "Sucesso" : "Erro");
        }
    }
}
