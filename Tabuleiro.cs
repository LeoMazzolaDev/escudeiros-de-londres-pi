using System;
using System.Collections.Generic;
using System.Linq;
using kingMe.kingMe;

namespace kingMe
{
    public class Tabuleiro
    {
        public Dictionary<int, List<Personagem>> Setores { get; private set; }
        public Dictionary<int, int> LimiteSetores { get; private set; }

        public Tabuleiro()
        {
            Setores = new Dictionary<int, List<Personagem>>
            {
                { 0, new List<Personagem>() },
                { 1, new List<Personagem>() },
                { 2, new List<Personagem>() },
                { 3, new List<Personagem>() },
                { 4, new List<Personagem>() },
                { 5, new List<Personagem>() },
                { 10, new List<Personagem>() } // Setor do Rei
            };

            LimiteSetores = new Dictionary<int, int>
            {
                { 0, 1 },
                { 1, 4 },
                { 2, 4 },
                { 3, 4 },
                { 4, 4 },
                { 5, 4 },
                { 10, 1 } // Apenas um personagem pode ser promovido a Rei
            };
        }

        public bool SetarPersonagem(int setor, Personagem personagem)
        {
            if (!Setores.ContainsKey(setor)) return false;

            if (Setores[setor].Count < LimiteSetores[setor])
            {
                Setores[setor].Add(personagem);
                personagem.Setor = setor;
                return true;
            }

            return false;
        }

        public bool MoverPersonagem(Personagem personagem, int novoSetor)
        {
            if (!Setores.ContainsKey(novoSetor))
                return false;

            // Verifica se o novo setor tem espaço
            if (Setores[novoSetor].Count >= LimiteSetores[novoSetor])
                return false;

            int setorAtual = personagem.Setor;

            // Remove do setor atual, se ele estiver lá
            if (Setores.ContainsKey(setorAtual))
            {
                Setores[setorAtual].Remove(personagem);
            }

            // Adiciona no novo setor
            Setores[novoSetor].Add(personagem);
            personagem.Setor = novoSetor;

            return true;
        }

        public Personagem ObterPersonagemPorChar(char letra)
        {
            foreach (var setor in Setores.Values)
            {
                foreach (var personagem in setor)
                {
                    if (personagem.Letra == letra)
                    {
                        return personagem;
                    }
                }
            }

            return null; // Não encontrado
        }


        public void LimparTabuleiro()
        {
            foreach (var setor in Setores.Keys.ToList())
            {
                Setores[setor].Clear();
            }
        }

        public int ObterPontuacaoDoSetor(int setor)
        {
            if (LimiteSetores.ContainsKey(setor))
            {
                return setor; 
            }

            return 0; 
        }
    }
}
