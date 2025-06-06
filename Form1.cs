﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
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
        private bool acabouDeVotar;
        int numeroDeNaos;
        int numeroDeNaosPartida;
        int rodadaAtual;

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

        // Define os setores que não podem ser sorteados
        private HashSet<int> setoresProibidos = new HashSet<int> { 0, 5, 10 };

        private HashSet<string> personagensUsados = new HashSet<string>();

        public Form1()
        {
            InitializeComponent();
            pnlTeste2.Paint += pnlTeste_Paint;
            string versaoJogo = Jogo.versao;
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

                Jogo.ListarSetores();
            }
        }

        private void btnListarPartidas_Click(object sender, EventArgs e)
        {
            string status = cmbOpcoes.Text;
            string retorno = Jogo.ListarPartidas(status);

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

        private void btnEntrarNasPartidas_Click(object sender, EventArgs e)
        {
            pnlEscolhaJogar.Visible = false;
            pnlEntrarPartida.Visible = true;
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
                switch (jogadores.Length)
                {
                    case 2:
                        numeroDeNaos = 6;
                        numeroDeNaosPartida = 6;
                        break;
                    case 3:
                        numeroDeNaos = 4;
                        numeroDeNaosPartida = 4;
                        break;
                    case 4:
                        numeroDeNaos = 3;
                        numeroDeNaosPartida = 3;
                        break;
                    default:
                        numeroDeNaos = 2;
                        numeroDeNaosPartida = 2;
                        break;
                }
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

                for (int i = 0; i < jogadores.Length; i++)
                {
                    lstJogadoresDaPartida.Items.Add(jogadores[i]);
                }
            }

            string retornoIniciar = Jogo.VerificarVez(idPartida);

            // Dividir no primeiro \r\n encontrado
            string[] separador = retornoIniciar.Split(new[] { "\r\n" }, 2, StringSplitOptions.None);

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

            //Informações do Jogo
            string statusDaPartida = vezInfo[1];
            string rodadaDaPartida = vezInfo[2];
            string faseDaPartida = vezInfo[3];

            
            lblRodada.Text = rodadaDaPartida;
            lblFase.Text = faseDaPartida;



            tmrVerificarVez.Enabled = true;
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

        private void lstNomePersonagens_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void colocarPersonagem()
        {
            if (idJogador.ToString() != idJogadorDaVez)
            {
                MessageBox.Show("Ocorreu um erro: \nNão é a sua vez", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int totalPersonagens = personagensNosSetores.Sum(s => s.Value.Count);

            Random rnd = new Random();

            int setor;
            if (totalPersonagens >= 12)
            {
                setor = 0;
            }
            else
            {
                List<int> setoresDisponiveis = contagemSetores
                    .Where(kv => !setoresProibidos.Contains(kv.Key) && kv.Value < limiteSetores[kv.Key])
                    .Select(s => s.Key)
                    .ToList();

                if (setoresDisponiveis.Count == 0)
                {
                    MessageBox.Show("Todos os setores estão cheios!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                setor = setoresDisponiveis[rnd.Next(setoresDisponiveis.Count)];
                label4.Text = setor.ToString();
            }

            // Filtra os personagens que ainda não foram usados
            List<string> personagensDisponiveis = sprites.Keys
                .Where(p => !personagensUsados.Contains(p))
                .ToList();

            if (personagensDisponiveis.Count == 0)
            {
                MessageBox.Show("Todos os personagens já foram alocados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string personagem = personagensDisponiveis[rnd.Next(personagensDisponiveis.Count)];
            personagensUsados.Add(personagem);

            label5.Text = personagem;

            if (string.IsNullOrEmpty(personagem) || personagem.Length != 1)
            {
                MessageBox.Show("Personagem inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (totalPersonagens < 12 && contagemSetores[setor] >= limiteSetores[setor])
            {
                MessageBox.Show("O setor está cheio!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstTabuleiro.Items.Clear();

            string infoTabuleiro = Jogo.ColocarPersonagem(idJogador, senhaJogador, setor, personagem);
            infoTabuleiro = infoTabuleiro.Replace("\r", "").Trim();
            string[] infoSetor = infoTabuleiro.Split('\n');

            atualizarDicionarios(infoSetor);

            foreach (var setorEntry in personagensNosSetores)
            {
                foreach (var personagemEntry in setorEntry.Value)
                {
                    lstTabuleiro.Items.Add($"Setor {setorEntry.Key}: {personagemEntry}");
                }
            }
        }

        private void PromoverPersonagemDaRodada()
                {
                    List<(string personagem, int setorAtual, int proximoSetor)> promoviveis = new List<(string, int, int)>();

                    // Monta a lista de personagens que podem ser promovidos
                    foreach (var setor in personagensNosSetores.Keys)
                    {
                        int proximoSetor = setor == 5 ? 10 : setor + 1;

                        if (!limiteSetores.ContainsKey(proximoSetor) || contagemSetores[proximoSetor] >= limiteSetores[proximoSetor])
                            continue;

                        foreach (var personagem in personagensNosSetores[setor])
                        {
                            promoviveis.Add((personagem, setor, proximoSetor));
                        }
                    }

                    if (promoviveis.Count == 0)
                    {
                        MessageBox.Show("Nenhum personagem pode ser promovido nesta rodada.");
                        return;
                    }

                    // Sorteia um personagem entre os possíveis
                    Random rand = new Random();
                    var escolhido = promoviveis[rand.Next(promoviveis.Count)];

                    // Atualiza os dicionários
                    personagensNosSetores[escolhido.setorAtual].Remove(escolhido.personagem);
                    contagemSetores[escolhido.setorAtual]--;

                    personagensNosSetores[escolhido.proximoSetor].Add(escolhido.personagem);
                    contagemSetores[escolhido.proximoSetor]++;

                    // Chama a função de promoção
                    Jogo.Promover(idJogador, senhaJogador, escolhido.personagem);

                    label7.Text = escolhido.personagem;
                }

        private void Votar()
        {
            string voto;

            if(numeroDeNaos > 0) 
            {
                Random sorteio = new Random();
                int votoSN = sorteio.Next(0, 2);

                voto = votoSN == 0 ? "N" : "S";

                if (voto == "N")
                {
                    numeroDeNaos--;
                }
            }
            else 
            {
                voto = "S";
            }
           
            string retorno = Jogo.Votar(idJogador, senhaJogador, voto);
            label7.Text = voto;
            acabouDeVotar = true;
        }

        private void verificarVez()
        {
            // Labels com infos do jogador
            lblIdDaVez.Text = "";
            lblNomeDaVez.Text = "";

            string retornoPartida = Jogo.VerificarVez(idPartida);
            label8.Text = retornoPartida; // <--- remover dps

            // Dividir no primeiro \r\n encontrado separando em duas partes:
            string[] separador = retornoPartida.Split(new[] { "\r\n" }, 2, StringSplitOptions.None);
            /* 
            separador[0]: id do jogador, status, rodada e fase;
            separador[1]: todas as posições dos personagens no tabuleiro
            */
            string infoPartida = separador[0];
            string infoPosicaoPersonagem = separador.Length > 1 ? separador[1] : ""; // posições dos personagens no tabuleiro

            // Mostrar nome e jogador da vez
            string[] vezInfo = infoPartida.Split(',');
            /*
            vezInfo[0]: id do jogador.  
            vezInfo[1]: status da partida.
            vezInfo[2]: rodada da partida.
            vezInfo[3]: fase da partida.
            */


            int id = Array.FindIndex(jogadores, elemento => elemento.StartsWith(vezInfo[0]));
            string infoJogadorDaVez = jogadores[id]; // id, nome, pontuação \n\r
            string[] jogadorDaVez = infoJogadorDaVez.Split(',');
            /*
            jogadorDaVez[0]: id do jogador.  
            jogadorDaVez[1]: nome do jogador.
            jogadorDaVez[2]: pontuação do jogador.
            */
            idJogadorDaVez = jogadorDaVez[0];
            nomeJogadorDaVez = jogadorDaVez[1];

            // imprimir id e nome do jogador na tela
            lblIdDaVez.Text = "Id do jogador da vez:" + idJogadorDaVez;
            lblNomeDaVez.Text = "Nome do jogador da vez:" + nomeJogadorDaVez;

            //Informações do Jogo
            string statusDaPartida = vezInfo[1];
            string rodadaDaPartida = vezInfo[2];
            string faseDaPartida = vezInfo[3];

            lblRodada.Text = rodadaDaPartida;
            lblFase.Text = faseDaPartida;

            if (int.Parse(rodadaDaPartida) != rodadaAtual) 
            {
                numeroDeNaos = numeroDeNaosPartida;
            }

            lblNumeroDeNaos.Text = numeroDeNaos.ToString();
            lblNumeroDeNaosPartida.Text = numeroDeNaosPartida.ToString();

            // Atualizar tabuleiro
            infoPosicaoPersonagem = infoPosicaoPersonagem.Replace("\r", "");
            string[] infoSetor = infoPosicaoPersonagem
                .Replace("\r", "")
                .Split('\n')
                .Where(linha => !string.IsNullOrWhiteSpace(linha))
                .ToArray();

            /*
            infoSetor[0]: setor do personagem 1, caracter do personagem 1 
            infoSetor[1]: setor do personagem 2, caracter do personagem 2
                                    ....
            */

            // Limpa o dicionario que guarda cada personagem em cada setor.
            foreach (var key in personagensNosSetores.Keys.ToList())
            {
                personagensNosSetores[key].Clear();
            }

            // Atualiza o dicionario com os personagens com base na resposta do banco de dados.
            foreach (string item in infoSetor)
            {
                string[] dadosDoPersonagem = item.Split(',');
                /*
                 dados[0]: setor
                 dados[1]: caracter
                 */
                if (dadosDoPersonagem.Length == 2)
                {
                    int setorRecebido = int.Parse(dadosDoPersonagem[0].Trim());
                    string personagemRecebido = dadosDoPersonagem[1].Trim();
                    personagensNosSetores[setorRecebido].Add(personagemRecebido);
                }
            }

            // Atualiza o dicionario de contagem de personagens nos setores.
            foreach (var key in personagensNosSetores.Keys)
            {
                contagemSetores[key] = personagensNosSetores[key].Count;
            }

            // Limpa e atualiza o HashSet de personagens usados com base na resposta do banco.
            personagensUsados.Clear();
            foreach (var lista in personagensNosSetores.Values)
            {
                foreach (var personagem in lista)
                {
                    personagensUsados.Add(personagem);
                }
            }

            // Atualiza a exibição do tabuleiro
            pnlTeste2.Invalidate();

            int totalPersonagens = contagemSetores.Sum(s => s.Value);

            if (int.Parse(idJogadorDaVez) == idJogador && totalPersonagens < 12)
            {
                colocarPersonagem();
            }

            if (int.Parse(idJogadorDaVez) == idJogador && faseDaPartida == "P")
            {
                atualizarDicionarios(infoSetor);
                List<(string personagem, int setorAtual, int proximoSetor)> promoviveis = new List<(string, int, int)>();

                // Monta a lista de personagens que podem ser promovidos
                foreach (var setor in personagensNosSetores.Keys)
                {
                    int proximoSetor = setor == 5 ? 10 : setor + 1;

                    if (!limiteSetores.ContainsKey(proximoSetor) || contagemSetores[proximoSetor] >= limiteSetores[proximoSetor])
                        continue;

                    foreach (var personagem in personagensNosSetores[setor])
                    {
                        promoviveis.Add((personagem, setor, proximoSetor));
                    }
                }

                if (promoviveis.Count == 0)
                {
                    MessageBox.Show("Nenhum personagem pode ser promovido nesta rodada.");
                    return;
                }

                // Sorteia um personagem entre os possíveis
                Random rand = new Random();
                var escolhido = promoviveis[rand.Next(promoviveis.Count)];

                // Atualiza os dicionários
                personagensNosSetores[escolhido.setorAtual].Remove(escolhido.personagem);
                contagemSetores[escolhido.setorAtual]--;

                personagensNosSetores[escolhido.proximoSetor].Add(escolhido.personagem);
                contagemSetores[escolhido.proximoSetor]++;

                // Chama a função de promoção
                Jogo.Promover(idJogador, senhaJogador, escolhido.personagem);

                label7.Text = escolhido.personagem;
            }

            if (int.Parse(idJogadorDaVez) == idJogador && faseDaPartida == "V")
            {
                if (!acabouDeVotar)
                {
                    Votar();
                    verificarVez(); // Atualiza tabuleiro depois do voto
                }
                else
                {
                    acabouDeVotar = false; // Reseta para próxima vez
                }
            }

            string retorno = Jogo.ListarJogadores(idPartida);
            retorno = retorno.Replace("\r", "");
            jogadores = retorno.Split('\n');

            lstJogadoresDaPartida.Items.Clear();
            for (int i = 0; i < jogadores.Length; i++)
            {
                lstJogadoresDaPartida.Items.Add(jogadores[i]);
            }

            rodadaAtual = int.Parse(rodadaDaPartida);
        }

        private void atualizarDicionarios(string[] infoSetor)
        {
  
            // Limpa o dicionario que guarda cada personagem em cada setor.
            foreach (var key in personagensNosSetores.Keys.ToList())
            {
                personagensNosSetores[key].Clear();
            }

            // Atualiza o dicionario com os personagens com base na resposta do banco de dados.
            foreach (string item in infoSetor)
            {
                string[] dadosDoPersonagem = item.Split(',');
                /*
                 dados[0]: setor
                 dados[1]: caracter
                 */
                if (dadosDoPersonagem.Length == 2)
                {
                    int setorRecebido = int.Parse(dadosDoPersonagem[0].Trim());
                    string personagemRecebido = dadosDoPersonagem[1].Trim();
                    personagensNosSetores[setorRecebido].Add(personagemRecebido);
                }
            }

            // Atualiza o dicionario de contagem de personagens nos setores.
            foreach (var key in personagensNosSetores.Keys)
            {
                contagemSetores[key] = personagensNosSetores[key].Count;
            }

            // Limpa e atualiza o HashSet de personagens usados com base na resposta do banco.
            personagensUsados.Clear();
            foreach (var lista in personagensNosSetores.Values)
            {
                foreach (var personagem in lista)
                {
                    personagensUsados.Add(personagem);
                }
            }
        }

        private void tmrVerificarVez_Tick(object sender, EventArgs e)
        {
            tmrVerificarVez.Enabled = false;
            verificarVez();
            tmrVerificarVez.Enabled = true;
        }

        private void pnlPartida_Paint(object sender, PaintEventArgs e)
        {

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

            // Atualiza a exibição do painel
            pnlTeste2.Invalidate();
        }

        private void btnPromoverPersonagem_Click(object sender, EventArgs e)
        {
            string personagem = txtPersonagem.Text.Trim();

            string infoTabuleiro = Jogo.Promover(idJogador, senhaJogador, personagem);

            infoTabuleiro = infoTabuleiro.Replace("\r", "").Trim();
            string[] infoSetor = infoTabuleiro.Split('\n');

            atualizarDicionarios(infoSetor);

            // Atualiza a exibição no ListBox
            foreach (var setorEntry in personagensNosSetores)
            {
                foreach (var personagemEntry in setorEntry.Value)
                {
                    lstTabuleiro.Items.Add($"Setor {setorEntry.Key}: {personagemEntry}");
                }
            }
        }

        private void btnVotar_Click(object sender, EventArgs e)
        {
            string voto = txtVoto.Text.Trim();
            string retorno = Jogo.Votar(idJogador, senhaJogador, voto);
        }

        private void btnVerificarVez_Click(object sender, EventArgs e)
        {
            lblIdDaVez.Text = "";
            lblNomeDaVez.Text = "";
            string retornoIniciar = Jogo.VerificarVez(idPartida);

            // Dividir no primeiro \r\n encontrado
            string[] separador = retornoIniciar.Split(new[] { "\r\n" }, 2, StringSplitOptions.None);

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

            //Informações do Jogo
            string statusDaPartida = vezInfo[1];
            string rodadaDaPartida = vezInfo[2];
            string faseDaPartida = vezInfo[3];

            lblRodada.Text = rodadaDaPartida;
            lblFase.Text = faseDaPartida;

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

            lstJogadoresDaPartida.Items.Clear();
            for (int i = 0; i < jogadores.Length; i++)
            {
                lstJogadoresDaPartida.Items.Add(jogadores[i]);
            }
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {

        }

        private void btnComoJogar_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {

        }
    }
}