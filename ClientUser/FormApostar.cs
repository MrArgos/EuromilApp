using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClientUser
{
    public partial class FormApostar : Form
    {
        public FormApostar(string _Username)
        {
            InitializeComponent();
            UserName = _Username;
        }
        public string UserName;

        private void buttonApostar_Click(object sender, EventArgs e)
        {
            if( VerificarSeNumerosEstrelasEstaoCorretos() == true)
            {
                string chave = textBoxNumero1.Text + " " + textBoxNumero2.Text + " " + textBoxNumero3.Text + " " +
                    textBoxNumero4.Text + " " + textBoxNumero5.Text + " + " + textBoxEstrela1.Text + " " +
                    textBoxEstrela2;

               // enviar para o server
                Aposta aposta = new Aposta();
                aposta.Nome = UserName;
                aposta.Chave = chave;
                aposta.Data = DateTime.Now.ToString();//meti a enviar em string 

                PedidoAposta p = new PedidoAposta();
                p.Aposta = aposta;

                using var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var client = new Apostas.ApostasClient(channel);
                var reply = client.RegistarAposta(p);
                MessageBox.Show("" + reply.Sucesso);

                //verificar se aposta foi recebida pelo server se sim aparece aquela messagebox

                MessageBox.Show("Aposta realizada com sucesso");
            }
            else
            {
                MessageBox.Show("Insira uma chave possivel !!");
            }
        }

        private bool VerificarSeNumerosEstrelasEstaoCorretos()
        {
            bool chavePossivel;
            chavePossivel = true;
            int[] numeros;            
            numeros = new int[5];   
            
            //verificar se todos os numeros são de 0 a 50
            int Estrela1, Estrela2;
            numeros[0] = Convert.ToInt32(textBoxNumero1.Text);
            numeros[1] = Convert.ToInt32(textBoxNumero2.Text);
            numeros[2] = Convert.ToInt32(textBoxNumero3.Text);
            numeros[3] = Convert.ToInt32(textBoxNumero4.Text);
            numeros[4] = Convert.ToInt32(textBoxNumero5.Text);
            Estrela1 = Convert.ToInt32(textBoxEstrela1.Text);
            Estrela2 = Convert.ToInt32(textBoxEstrela2.Text);

            if(numeros[0] > 0 && numeros[0] <= 50 
                && numeros[1] > 0 && numeros[1] <= 50
                && numeros[2] > 0 && numeros[2] <= 50
                && numeros[3] > 0 && numeros[3] <= 50
                && numeros[4] > 0 && numeros[4] <= 50
                && Estrela1 > 0 && Estrela1 <= 12  //meti a estrelas de 0 a 12, se não for depois trocasse
                && Estrela2 > 0 && Estrela2 <= 12)
            {
                chavePossivel = true;
            }
            else
            {
                chavePossivel = false;

            }
            //verificar se existem numeros repetidos
            for(int j = 0; j < 5; j++)
            {
                for(int i = 0; i < 5; i++)
                {
                    if(numeros[j] == numeros[i] && j != i)
                    {
                        chavePossivel = false;
    
                    }
                }
            }
            //verificar se existem estrelas repetidas
            if (Estrela1 == Estrela2)
            {
                chavePossivel = false;

            }

            return chavePossivel;
        }
    }
}
