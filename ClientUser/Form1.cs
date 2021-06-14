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
            Aposta aposta = new Aposta { Nome = "Pedro", Chave = "1 2 23 4 51 + 6 7", Data = DateTime.Now.ToString() };
            //aposta.Nome = "Joao";
            //aposta.Chave = "1 2 3 4 5 + 6 7";
            //aposta.Data = DateTime.Now.ToString();

            PedidoAposta p = new PedidoAposta { Aposta = aposta };
            //p.Aposta = aposta;

            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Apostas.ApostasClient(channel);
            var reply = client.RegistarAposta(p);
            MessageBox.Show(""+ reply.Sucesso);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormApostar dlgFormApostar = new FormApostar("Username" + DateTime.Now.Second.ToString());
            dlgFormApostar.ShowDialog();
        }
    }
}
