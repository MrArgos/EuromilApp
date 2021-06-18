using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Grpc.Core;
using Grpc.Net.Client;

namespace ClientUser
{

    public partial class FormUtilizador : Form
    {
        
        public FormUtilizador()
        {
            InitializeComponent();
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            if (textBoxNome.Text.Length >= 3 || textBoxNome.Text.Length < 50)
            {
                try
                {
                    //AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                    var httpHandler = new HttpClientHandler();
                    httpHandler.ServerCertificateCustomValidationCallback =
                        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                    // Endereço IP do servidor
                    using var channel = GrpcChannel.ForAddress("https://192.168.1.93:5001",
                        new GrpcChannelOptions { HttpHandler = httpHandler });

                    Hide();
                    using (FormMenu fm = new FormMenu(textBoxNome.Text, channel))
                        fm.ShowDialog();
                    Show();
                }
                catch (RpcException exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }

                
            }
            else
            {
                MessageBox.Show("Insira um nome entre 3 a 50 caracteres.", 
                    "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
