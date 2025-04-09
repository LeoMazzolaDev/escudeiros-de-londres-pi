using System;
using System.Collections.Generic;
using System.Linq;
using kingMe.kingMe;

namespace kingMe
{
    public class Partida
    {
        public List<Jogador> Jogadores { get; private set; }
        public Tabuleiro Tabuleiro { get; private set; }

        public Partida()
        {
            Jogadores = new List<Jogador>();
            Tabuleiro = new Tabuleiro();
        }

        public void AdicionarJogador(Jogador jogador)
        {
            if (!Jogadores.Contains(jogador))
                Jogadores.Add(jogador);
        }

        // Setup: Posiciona personagem em um setor inicial (1 a 4)
        public void PosicionarPersonagem(char personagemChar, int setor)
        {
            if (setor < 1 || setor > 4)
                throw new ArgumentException("Setor inválido para posicionamento inicial.");

            Personagem personagem = Tabuleiro.ObterPersonagemPorChar(personagemChar);
            if (personagem == null)
                throw new InvalidOperationException("Personagem não encontrado.");

            personagem.Setor = setor;
        }

        // Promoção: Sobe o personagem de setor, iniciando votação se for para o setor 6
        public bool PromoverPersonagem(char personagemChar)
        {
            Personagem personagem = Tabuleiro.ObterPersonagemPorChar(personagemChar);
            if (personagem == null)
                throw new InvalidOperationException("Personagem não encontrado.");

            int setorAtual = personagem.Setor;
            if (setorAtual >= 10)
                return false;

            int novoSetor = setorAtual == 5 ? 10 : setorAtual + 1;

            bool sucesso = Tabuleiro.MoverPersonagem(personagem, novoSetor);

            // Se foi promovido do setor 5 para o 10 (rei), inicia votação
            return sucesso && novoSetor == 10;
        }


        // Votação: Recebe votos e verifica se todos votaram "sim"
        public bool VerificarVotacao(Dictionary<Jogador, bool> votos)
        {
            return votos.Values.All(v => v == true);
        }

        public Dictionary<Jogador, int> CalcularPontuacao()
        {
            var pontuacoes = new Dictionary<Jogador, int>();

            foreach (var jogador in Jogadores)
            {
                int pontuacao = 0;

                foreach (var personagem in jogador.Influencias)
                {
                    pontuacao += Tabuleiro.ObterPontuacaoDoSetor(personagem.Setor);
                }

                pontuacoes[jogador] = pontuacao;
            }

            return pontuacoes;
        }

    }
}
