using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KingMeServer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace kingMe.cs
{
    public partial class Form1 : Form
    {
        private string idJogadorTxt;
        private int idJogador;
        private string senhaJogador;
        public string nomeGrupo = "Escudeiros de Londres";
        public Form1()
        {
            InitializeComponent();
            lblVersao.Text = "Versão" + Jogo.versao;
            pnlEscolhaJogar.Visible = false;
            pnlEntrarPartida.Visible = false;
            pnlCriarPartida.Visible = false;
            pnlLobby.Visible = false;
            pnlPartida.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblNomeGrupo.Text = nomeGrupo;
        }

        private void btnCriarPartida_Click(object sender, EventArgs e)
        {

            txtNomeGrupo.Text = nomeGrupo;
            string nomePartida = txtNomePartida.Text;
            string senha = txtSenha.Text;
            string grupo = txtNomeGrupo.Text;

            string retorno = Jogo.CriarPartida(nomePartida, senha, grupo);
            if (retorno.Substring(0, 4) == "ERRO")
            {
                MessageBox.Show("Ocorreu um erro: \n" + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                pnlCriarPartida.Visible = false;
                pnlEntrarPartida.Visible = true;
            }
        }

        private void btnListarPartidas_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.ListarPartidas("T");
            lstListarPartidas.Text = retorno;

            retorno = retorno.Replace("\r", "");
            retorno = retorno.Substring(0, retorno.Length - 1);
            string[] partidas = retorno.Split('\n');

            lstListarPartidas.Items.Clear();
            for (int i = 0; i < partidas.Length; i++)
            {
                lstListarPartidas.Items.Add(partidas[i]);
            }
        }

        private void lstListarPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string partida = lstListarPartidas.SelectedItem.ToString();
            string[] informacaoPartida = partida.Split(',');

            int idPartida = Convert.ToInt32(informacaoPartida[0]);
            string nomePartida = informacaoPartida[1];
            string data = informacaoPartida[2];

            txtNomePartidaEntrar.Text = nomePartida;

            //string senha = txtSenhaEntrar.Text;
            //string username = txtUsername.Text;

            string retorno = Jogo.ListarJogadores(idPartida);
            retorno = retorno.Replace("\r", "");
            string[] jogadores = retorno.Split('\n');

            lstJogadores.Items.Clear();
            for (int i = 0; i < jogadores.Length; i++) { 
                lstJogadores.Items.Add(jogadores[i]);
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            pnlEntrarPartida.Visible = false;
            pnlLobby.Visible = true;

            string partida = lstListarPartidas.SelectedItem.ToString();
            string[] informacaoPartida = partida.Split(',');

            int idPartida = Convert.ToInt32(informacaoPartida[0]);
            string username = txtUsername.Text;
            string senha = txtSenhaEntrar.Text;

            string Jogador = Jogo.Entrar(idPartida, username, senha);
            string[] infoJogador = Jogador.Split(',');
            idJogadorTxt = infoJogador[0];
            senhaJogador = infoJogador[1];

            lblIdJogador.Text = "Id do jogador: " + idJogadorTxt;
            lblSenhaJogador.Text = "Senha do jogador: " + senhaJogador;

            idJogador = Convert.ToInt32(idJogadorTxt);

            Jogo.Iniciar(idJogador, senhaJogador);

            string retorno = Jogo.ListarJogadores(idPartida);
            retorno = retorno.Replace("\r", "");
            string[] jogadores = retorno.Split('\n');

            lstJogadores.Items.Clear();
            for (int i = 0; i < jogadores.Length; i++)
            {
                lstJogadores.Items.Add(jogadores[i]);
            }
        }

        private void btnJogar_Click_1(object sender, EventArgs e)
        {
            pnlMenuInicial.Visible = false;
            pnlEscolhaJogar.Visible = true;
        }

        private void btnEntrarNasPartidas_Click(object sender, EventArgs e)
        {
            pnlEscolhaJogar.Visible = false;
            pnlEntrarPartida.Visible = true;
        }

        private void btnCriarUmaPartida_Click(object sender, EventArgs e)
        {
            pnlEscolhaJogar.Visible = false;
            pnlCriarPartida.Visible = true;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            pnlLobby.Visible = false;
            pnlPartida.Visible = true;  
        }

        private void btnListarCartas_Click(object sender, EventArgs e)
        {
            lstCartas.Items.Clear();
            string cartas = Jogo.ListarCartas(idJogador, senhaJogador);
            char[] iniciais = cartas.ToCharArray();

            Dictionary<char, string> nomes = new Dictionary<char, string>
            {
                { 'A', "Adilson Konrad" },
                { 'B', "Beatriz Paiva" },
                { 'C', "Claro" },
                { 'D', "Douglas Baquiao" },
                { 'E', "Eduardo Takeo" },
                { 'G', "Guilherme Rey" },
                { 'H', "Heredia" },
                { 'K', "Karin" },
                { 'L', "Leonardo Takuno" },
                { 'M', "Mario Toledo" },
                { 'Q', "Quintas" },
                { 'R', "Ranulfo" },
                { 'T', "Toshio" }
            };

            lstCartas.Items.Clear();

            foreach (char inicial in iniciais)
            {
                if (nomes.ContainsKey(inicial))
                {
                    lstCartas.Items.Add(nomes[inicial]);
                }
            }
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {

        }
    }
}
