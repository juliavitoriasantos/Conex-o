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
            using (Ping ping = new Ping())
            {
                try
                {
                    var reply = await ping.SendPingAsync("8.8.8.8", 2000);
                    if (reply.Status == IPStatus.Success)
                        AtualizarStatus("Conectado à internet");
                    else
                        AtualizarStatus("Sem conexão");
                }
                catch
                {
                    AtualizarStatus("Erro ao verificar conexão");
                }
            }
        }

        private void AtualizarStatus(string mensagem)
        {
            if (lblstatus.InvokeRequired)
            {
                // Se não estivermos na thread da UI, invoca o método na thread da UI
                lblstatus.Invoke(new MethodInvoker(delegate { lblstatus.Text = mensagem; }));
            }
            else
            {
                // Se já estivermos na thread da UI, faz a atualização diretamente
                lblstatus.Text = mensagem;
            }
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
