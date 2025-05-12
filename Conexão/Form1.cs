using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexão
{
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
            NetworkChange.NetworkAvailabilityChanged += OnNetworkAvailabilityChanged;
            NetworkChange.NetworkAddressChanged += OnNetworkAddressChanged;

            timerrede.Interval = 10000; // 10 segundos
            timerrede.Tick += TimerRede_Tick;
            timerrede.Start();
            this.FormClosing += Form1_FormClosing;
        }

        private void OnNetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            AtualizarStatus($"[EVENTO] Rede disponível: {e.IsAvailable}");
        }

        private void OnNetworkAddressChanged(object sender, EventArgs e)
        {
            AtualizarStatus("[EVENTO] Endereço de rede alterado");
        }

        private async void TimerRede_Tick(object sender, EventArgs e)
        {
            string[] enderecos = new string[]
    {
        "8.8.8.8",          // Google DNS
        "1.1.1.1",          // Cloudflare DNS
        "www.microsoft.com", // Teste DNS + resolução de nome + porta
        "www.google.com"    // Idem
    };

            bool conectado = false;

            using (Ping ping = new Ping())
            {
                foreach (var endereco in enderecos)
                {
                    try
                    {
                        var reply = await ping.SendPingAsync(endereco, 2000);
                        if (reply.Status == IPStatus.Success)
                        {
                            conectado = true;
                            break;
                        }
                    }
                    catch
                    {
                        // Ignora falhas individuais
                    }
                }
            }

            if (conectado)
                AtualizarStatus("Conectado à internet");
            else
                AtualizarStatus("Sem conexão");
        }

        private void AtualizarStatus(string mensagem)
        {
            if (lblstatus.InvokeRequired)
            {
                lblstatus.Invoke(new MethodInvoker(() => AtualizarStatus(mensagem)));
                return;
            }

            lblstatus.Text = mensagem;

            Color cor;
            if (mensagem.Contains("Conectado"))
                cor = Color.Green;
            else if (mensagem.Contains("Sem conexão") || mensagem.Contains("Erro"))
                cor = Color.Red;
            else
                cor = SystemColors.Control;

            // Atualiza a cor de fundo
            lblstatus.BackColor = cor;
            btnligar.BackColor = cor;
            btndesligar.BackColor = cor;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            NetworkChange.NetworkAvailabilityChanged -= OnNetworkAvailabilityChanged;
            NetworkChange.NetworkAddressChanged -= OnNetworkAddressChanged;
            timerrede.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblstatus_Click(object sender, EventArgs e)
        {

        }

        private void btnligar_Click(object sender, EventArgs e)
        {
            NetworkChange.NetworkAvailabilityChanged += OnNetworkAvailabilityChanged;
            NetworkChange.NetworkAddressChanged += OnNetworkAddressChanged;
            timerrede.Start();
            AtualizarStatus("Monitoramento ativado");
        }

        private void btndesligar_Click(object sender, EventArgs e)
        {
            NetworkChange.NetworkAvailabilityChanged -= OnNetworkAvailabilityChanged;
            NetworkChange.NetworkAddressChanged -= OnNetworkAddressChanged;
            timerrede.Stop();
            AtualizarStatus("Monitoramento desativado");
        }

    }
}
