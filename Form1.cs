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
        public int idPartida;
        private string[] jogadores;
        private string idJogadorDaVez;
        private string nomeJogadorDaVez;



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
            if (retorno.Substring(0, 1) == "E")
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
            jogadores = retorno.Split('\n');

            lstJogadores.Items.Clear();
            for (int i = 0; i < jogadores.Length; i++) { 
                lstJogadores.Items.Add(jogadores[i]);
            }
        }



        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string partida = lstListarPartidas.SelectedItem.ToString();
            string[] informacaoPartida = partida.Split(',');

            char statusPartida = Convert.ToChar(informacaoPartida[3]);

            if(statusPartida == 'E') 
            {
                MessageBox.Show("Ocorreu um erro: \n Essa partida já foi encerrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (statusPartida == 'J') 
            {
                MessageBox.Show("Ocorreu um erro: \n Essa partida já foi iniciada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else 
            {
                pnlEntrarPartida.Visible = false;
                pnlLobby.Visible = true;



                idPartida = Convert.ToInt32(informacaoPartida[0]);
                string username = txtUsername.Text;
                string senha = txtSenhaEntrar.Text;

                string Jogador = Jogo.Entrar(idPartida, username, senha);
                string[] infoJogador = Jogador.Split(',');
                idJogadorTxt = infoJogador[0];
                senhaJogador = infoJogador[1];

                lblIdJogador.Text = "Id do jogador: " + idJogadorTxt;
                lblSenhaJogador.Text = "Senha do jogador: " + senhaJogador;

                idJogador = Convert.ToInt32(idJogadorTxt);



                string listarJogadores = Jogo.ListarJogadores(idPartida);
                listarJogadores = listarJogadores.Replace("\r", "");
                listarJogadores = listarJogadores.Substring(0, listarJogadores.Length - 1);
                jogadores = listarJogadores.Split('\n');

                lstJogadores.Items.Clear();
                for (int i = 0; i < jogadores.Length; i++)
                {
                    lstJogadores.Items.Add(jogadores[i]);
                }
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
            string atualizarJogadores = Jogo.ListarJogadores(idPartida);
            atualizarJogadores = atualizarJogadores.Replace("\r", "");
            atualizarJogadores = atualizarJogadores.Substring(0, atualizarJogadores.Length - 1);
            jogadores = atualizarJogadores.Split('\n');


            if (jogadores.Length <= 1) 
            {
                MessageBox.Show("Ocorreu um erro: \n A partida só pode ser iniciada com mais de dois jogadores", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else 
            {
                pnlLobby.Visible = false;
                pnlPartida.Visible = true;
                Jogo.Iniciar(idJogador, senhaJogador);

                string retorno = Jogo.ListarPersonagens();
                retorno = retorno.Replace("\r", "");
                string[] nomePersonagens = retorno.Split('\n');
                for (int i = 0; i < nomePersonagens.Length; i++)
                {
                    lstNomePersonagens.Items.Add(nomePersonagens[i]);
                }
            }


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

        private void lstNomePersonagens_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnlPartida_Paint(object sender, PaintEventArgs e)
        {

        }

         private void btnColocarPersonagem_Click(object sender, EventArgs e)
        {
            string txtIdJogador = idJogador.ToString();

            if (txtIdJogador != idJogadorDaVez)
            {
                MessageBox.Show("Ocorreu um erro: \n Não é a sua vez", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                //Colocar o nome do jogador da Vez
            }
            else
            {
                lstTabuleiro.Items.Clear();
                int setor = Convert.ToInt32(txtSetor.Text);
                string personagem = txtPersonagem.Text;

                string infoTabuleiro = Jogo.ColocarPersonagem(idJogador, senhaJogador, setor, personagem);
                infoTabuleiro = infoTabuleiro.Replace("\r", "");
                infoTabuleiro = infoTabuleiro.Substring(0, infoTabuleiro.Length - 1);
                string[] infoSetor = infoTabuleiro.Split('\n');
                for (int i = 0; i < infoSetor.Length; i++)
                {
                    lstTabuleiro.Items.Add(infoSetor[i]);
                }
            }
        }

        // Código para verificar quem é o jogador da vez
        private void btnVerificarVez_Click(object sender, EventArgs e)
        {
            lblIdDaVez.Text = "";
            lblNomeDaVez.Text = "";
            string retorno = Jogo.VerificarVez(idPartida);
            retorno = retorno.Replace("\r\n", "");
            string[] vezInfo = retorno.Split(',');

            int indice = Array.FindIndex(jogadores, elemento => elemento.StartsWith(vezInfo[0]));

            string infoJogadorDaVez = jogadores[indice];

            string[] jogadorDaVez = infoJogadorDaVez.Split(',');
            idJogadorDaVez = jogadorDaVez[0];
            nomeJogadorDaVez = jogadorDaVez[1];
            lblIdDaVez.Text = "Id do jogador da vez:" + idJogadorDaVez;
            lblNomeDaVez.Text = "Nome do jogador da vez:" + nomeJogadorDaVez;
            
    }
}
        }