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

namespace kingMe.cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblVersao.Text = Jogo.versao;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCriarPartida_Click(object sender, EventArgs e)
        {
            

            string nomePartida = txtNomePartida.Text;
            string senha = txtSenha.Text;
            string grupo = txtNomeGrupo.Text;

            Jogo.CriarPartida(nomePartida, senha, grupo);
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
            string partida = lstListarPartidas.SelectedItem.ToString();
            string[] informacaoPartida = partida.Split(',');

            int idPartida = Convert.ToInt32(informacaoPartida[0]);
            string username = txtUsername.Text;
            string senha = txtSenhaEntrar.Text;

            Jogo.Entrar(idPartida, username, senha);

            string retorno = Jogo.ListarJogadores(idPartida);
            retorno = retorno.Replace("\r", "");
            string[] jogadores = retorno.Split('\n');

            lstJogadores.Items.Clear();
            for (int i = 0; i < jogadores.Length; i++)
            {
                lstJogadores.Items.Add(jogadores[i]);
            }
        }
    }
}
