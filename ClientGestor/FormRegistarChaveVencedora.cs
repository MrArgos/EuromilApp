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
    public partial class FormRegistarChaveVencedora : Form
    {
        public FormRegistarChaveVencedora()
        {
            InitializeComponent();
        }

        private void buttonRegistar_Click(object sender, EventArgs e)
        {
            var chave = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " "
                + textBox4.Text + " " + textBox5.Text + " + " + textBox6.Text + " " + textBox7.Text;

            try
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var client = new Apostas.ApostasClient(channel);
                var reply = client.RegistarChaveVencedora(new ChaveVencedora { Chave = chave });
                MessageBox.Show(reply.Sucesso ? "Chave Registada com Sucesso" : "Erro a registar chave.");
            }
            catch (RpcException)
            {
                MessageBox.Show("Erro no serviço gRPC. Por favor tente de novo mais tarde ou contacte o administrador do serviço.",
                     "Erro no serviço gRPC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
