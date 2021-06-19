using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClientUtilizador
{
    public partial class FormApostar : Form
    {
        private string userName;
        private GrpcChannel channel;
        public FormApostar(string _Username, GrpcChannel _channel)
        {
            InitializeComponent();
            userName = _Username;
            channel = _channel;
        }

        private void buttonApostar_Click(object sender, EventArgs e)
        {
            // Verificar se há erros na conversão e ordenação da chave
            string chave = OrdenarChave();
            if (chave == "-1")
            {
                MessageBox.Show("Chave não está no formato correto.", "Erro na chave", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {  // Se não houver, enviar informação para o servidor

                Aposta aposta = new Aposta { Nome = userName, Chave = chave, Data = DateTime.Now.ToString() };

                PedidoAposta p = new PedidoAposta { Aposta = aposta };

                try
                {
                    var client = new Apostas.ApostasClient(channel);
                    var reply = client.RegistarAposta(p);
                    MessageBox.Show(reply.Sucesso ? "Chave Registada com Sucesso." : "Erro a registar chave.");
                }
                catch (RpcException)
                {
                    MessageBox.Show("Erro no serviço gRPC. Por favor tente de novo mais tarde " +
                                    "ou contacte o administrador do serviço.",
                     "Erro no serviço gRPC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }

        // Verificar e ordenar Chave inserida pelo utilizador
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

            // Converter para INT os números inseridos pelo utilizador (string)
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

            // Verificar se números estão entre 1 e 50, e estrelas entre 1 e 12
            if (numeros.Max() > 50 || numeros.Min() < 1 || estrelas.Max() > 12 || estrelas.Min() < 1)
            {
                return erro;
            }

            // Ordenar números e estrelas
            Array.Sort(numeros);
            Array.Sort(estrelas);

            // Verificar se números es estrelas são diferentes
            for (i = 0; i < numeros.Length - 1; i++)
            {
                if (numeros[i] == numeros[i+1])
                    return erro;
            }
            if(estrelas[0] == estrelas[1])
                return erro;

            // concatenar números e estrelas numa única string para enviar para o servidor
            string chaveOrdenada = string.Join(" ", numeros);
            string estrelasOrdenada = string.Join(" ", estrelas);
            string chave = chaveOrdenada + " + " + estrelasOrdenada;
            return chave;
        }
    }
}
