using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            string chave = OrdenarChave();
            if (chave == "-1")
            {
                MessageBox.Show("Chave não está no formato correto.", "Erro na chave", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
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

        private string OrdenarChave()
        {
            int[] numeros = new int[5];
            int[] estrelas = new int[2];
            int i = 0;
            string erro = "-1";

            List<TextBox> textBoxesNumeros = new List<TextBox> {
                textBoxNumero1,
                textBoxNumero2,
                textBoxNumero3,
                textBoxNumero4,
                textBoxNumero5};

            List<TextBox> textBoxesEstrelas = new List<TextBox> {
                textBoxEstrela1,
                textBoxEstrela2};

            foreach (var t in textBoxesNumeros)
            {
                if (!Int32.TryParse(t.Text, out numeros[i++]))
                    return erro;
            }
            i = 0;
            foreach (var t in textBoxesEstrelas)
            {
                if (!Int32.TryParse(t.Text, out estrelas[i++]))
                    return erro;
            }

            if (numeros.Max() > 50 || numeros.Min() < 1 || estrelas.Max() > 12 || estrelas.Min() < 1)
            {
                return erro;
            }
            Array.Sort(numeros);
            Array.Sort(estrelas);

            for (i = 0; i < numeros.Length - 1; i++)
            {
                if (numeros[i] == numeros[i + 1])
                    return erro;
            }

            if (estrelas[0] == estrelas[1])
                return erro;

            string chaveOrdenada = string.Join(" ", numeros);
            string estrelasOrdenada = string.Join(" ", estrelas);
            string chave = chaveOrdenada + " + " + estrelasOrdenada;
            return chave;
        }
    }
}
