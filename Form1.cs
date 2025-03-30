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

        private Dictionary<string, Image> sprites = new Dictionary<string, Image>()
        {
            { "A", Properties.Resources.A },
            { "B", Properties.Resources.B },
            { "C", Properties.Resources.C },
            { "D", Properties.Resources.D },
            { "E", Properties.Resources.E },
            { "G", Properties.Resources.G },
            { "H", Properties.Resources.H },
            { "K", Properties.Resources.K },
            { "L", Properties.Resources.L },
            { "M", Properties.Resources.M },
            { "Q", Properties.Resources.Q },
            { "R", Properties.Resources.R },
            { "T", Properties.Resources.T }
        };

        private Dictionary<int, Point> posicaoSetores = new Dictionary<int, Point>()
        {
            { 0, new Point(200, 490) },  // Setor 0
            { 1, new Point(100, 420) },
            { 2, new Point(100, 350) },
            { 3, new Point(100, 275) },
            { 4, new Point(100, 200) },
            { 5, new Point(100, 125) },
            { 10, new Point(200, 60)  }  // Setor 10
        };

        private Dictionary<int, int> contagemSetores = new Dictionary<int, int>()
        {
            { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 },
            { 4, 0 }, { 5, 0 }, { 10, 0 }
        }; 

        private Dictionary<int, int> limiteSetores = new Dictionary<int, int>()
        {
            { 0, 1 }, { 1, 4 }, { 2, 4 }, { 3, 4 },
            { 4, 4 }, { 5, 4 }, { 10, 1 }
        };

        private Dictionary<int, List<string>> personagensNosSetores = new Dictionary<int, List<string>>()
        {
            { 0, new List<string>() }, { 1, new List<string>() }, { 2, new List<string>() }, { 3, new List<string>() },
            { 4, new List<string>() }, { 5, new List<string>() }, { 10, new List<string>() }
        };

        public Form1()
        {
            InitializeComponent();
            pnlTeste2.Paint += pnlTeste_Paint;
            string versaoJogo = Jogo.versao;
            pnlEscolhaJogar.Visible = false;
            pnlEntrarPartida.Visible = false;
            pnlCriarPartida.Visible = false;
            pnlLobby.Visible = false;
            pnlPartida.Visible = false;
            this.Text = "Escudeiros de Londres | versão: " + versaoJogo;
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
            if (idJogador.ToString() != idJogadorDaVez)
            {
                MessageBox.Show("Ocorreu um erro: \nNão é a sua vez", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Conta quantos personagens já foram colocados
            int totalPersonagens = personagensNosSetores.Sum(s => s.Value.Count);

            // Se for o 13º personagem, ele vai automaticamente para o setor 0
            int setor = (totalPersonagens < 12) ? int.Parse(txtSetor.Text) : 0;

            if (!posicaoSetores.ContainsKey(setor))
            {
                MessageBox.Show("Setor inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string personagem = txtPersonagem.Text.Trim();
            if (string.IsNullOrEmpty(personagem) || personagem.Length != 1)
            {
                MessageBox.Show("Personagem inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Se não for o 13º personagem, verifica se há espaço no setor
            if (totalPersonagens < 12 && contagemSetores[setor] >= limiteSetores[setor])
            {
                MessageBox.Show("O setor está cheio!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstTabuleiro.Items.Clear();

            // Envia o personagem para o banco e recebe o estado atualizado do tabuleiro
            string infoTabuleiro = Jogo.ColocarPersonagem(idJogador, senhaJogador, setor, personagem);
            infoTabuleiro = infoTabuleiro.Replace("\r", "").Trim();
            string[] infoSetor = infoTabuleiro.Split('\n');

            // Limpa os personagens dos setores antes de atualizar
            foreach (var key in personagensNosSetores.Keys.ToList())
            {
                personagensNosSetores[key].Clear();
            }

            // Atualiza os personagens com base na resposta do banco de dados
            foreach (string item in infoSetor)
            {
                string[] dados = item.Split(',');
                if (dados.Length == 2)
                {
                    int setorRecebido = int.Parse(dados[0].Trim());
                    string personagemRecebido = dados[1].Trim();

                    if (!personagensNosSetores.ContainsKey(setorRecebido))
                    {
                        personagensNosSetores[setorRecebido] = new List<string>();
                    }
                    personagensNosSetores[setorRecebido].Add(personagemRecebido);
                }
            }

            // Atualiza a contagem de personagens nos setores
            foreach (var key in personagensNosSetores.Keys)
            {
                contagemSetores[key] = personagensNosSetores[key].Count;
            }

            // Atualiza a exibição no ListBox
            foreach (var setorEntry in personagensNosSetores)
            {
                foreach (var personagemEntry in setorEntry.Value)
                {
                    lstTabuleiro.Items.Add($"Setor {setorEntry.Key}: {personagemEntry}");
                }
            }
        }

        private void pnlTeste_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Desenha os personagens de acordo com os setores
            foreach (var setor in personagensNosSetores)
            {
                int index = 0;
                foreach (var personagem in setor.Value)
                {
                    if (sprites.ContainsKey(personagem))
                    {
                        Point posicaoBase = posicaoSetores[setor.Key];
                        Point posicaoFinal = new Point(posicaoBase.X + (index * 65), posicaoBase.Y);

                        g.DrawImage(sprites[personagem], posicaoFinal);
                    }
                    index++;
                }
            }
        }


        // Código para verificar quem é o jogador da vez
        private void btnVerificarVez_Click(object sender, EventArgs e)
        {
            lblIdDaVez.Text = "";
            lblNomeDaVez.Text = "";
            string retorno = Jogo.VerificarVez(idPartida);

            // Dividir no primeiro \r\n encontrado
            string[] separador = retorno.Split(new[] { "\r\n" }, 2, StringSplitOptions.None);

            string infoPartida = separador[0]; // Primeira linha
            string infoPosicao = separador.Length > 1 ? separador[1] : ""; // O resto da string

            // Mostrar nome e jogador da vez
            string[] vezInfo = infoPartida.Split(',');
            int indice = Array.FindIndex(jogadores, elemento => elemento.StartsWith(vezInfo[0]));
            string infoJogadorDaVez = jogadores[indice];
            string[] jogadorDaVez = infoJogadorDaVez.Split(',');
            idJogadorDaVez = jogadorDaVez[0];
            nomeJogadorDaVez = jogadorDaVez[1];
            lblIdDaVez.Text = "Id do jogador da vez:" + idJogadorDaVez;
            lblNomeDaVez.Text = "Nome do jogador da vez:" + nomeJogadorDaVez;

            // Atualizar tabuleiro
            infoPosicao = infoPosicao.Replace("\r", "");
            string[] infoSetor = infoPosicao.Split('\n');

            // Limpa os personagens dos setores antes de atualizar
            foreach (var key in personagensNosSetores.Keys.ToList())
            {
                personagensNosSetores[key].Clear();
            }

            // Atualiza os personagens com base na resposta do banco de dados
            foreach (string item in infoSetor)
            {
                string[] dados = item.Split(',');
                if (dados.Length == 2)
                {
                    int setorRecebido = int.Parse(dados[0].Trim());
                    string personagemRecebido = dados[1].Trim();

                    if (!personagensNosSetores.ContainsKey(setorRecebido))
                    {
                        personagensNosSetores[setorRecebido] = new List<string>();
                    }
                    personagensNosSetores[setorRecebido].Add(personagemRecebido);
                }
            }

            // Atualiza a contagem de personagens nos setores
            foreach (var key in personagensNosSetores.Keys)
            {
                contagemSetores[key] = personagensNosSetores[key].Count;
            }

            // Atualiza a exibição do painel
            pnlTeste2.Invalidate();
        }

        private void btnMostrarImg_Click(object sender, EventArgs e)
        {
            //if (picAprov.Visible == false)
            //{
            //    picAprov.Visible = true;
            //}
        }

        private void picAprov_Click(object sender, EventArgs e)
        {

        }


        private void btnPromoverPersonagem_Click(object sender, EventArgs e)
        {
            string personagem = txtPersonagem.Text.Trim();
            
            string infoTabuleiro = Jogo.Promover(idJogador, senhaJogador, personagem);

            infoTabuleiro = infoTabuleiro.Replace("\r", "").Trim();
            string[] infoSetor = infoTabuleiro.Split('\n');

            // Limpa os personagens dos setores antes de atualizar
            foreach (var key in personagensNosSetores.Keys.ToList())
            {
                personagensNosSetores[key].Clear();
            }

            // Atualiza os personagens com base na resposta do banco de dados
            foreach (string item in infoSetor)
            {
                string[] dados = item.Split(',');
                if (dados.Length == 2)
                {
                    int setorRecebido = int.Parse(dados[0].Trim());
                    string personagemRecebido = dados[1].Trim();

                    if (!personagensNosSetores.ContainsKey(setorRecebido))
                    {
                        personagensNosSetores[setorRecebido] = new List<string>();
                    }
                    personagensNosSetores[setorRecebido].Add(personagemRecebido);
                }
            }

            // Atualiza a contagem de personagens nos setores
            foreach (var key in personagensNosSetores.Keys)
            {
                contagemSetores[key] = personagensNosSetores[key].Count;
            }

            // Atualiza a exibição no ListBox
            foreach (var setorEntry in personagensNosSetores)
            {
                foreach (var personagemEntry in setorEntry.Value)
                {
                    lstTabuleiro.Items.Add($"Setor {setorEntry.Key}: {personagemEntry}");
                }
            }
        }

        private void btnComoJogar_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {

        }
    }
}