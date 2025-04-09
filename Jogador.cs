using System.Collections.Generic;

namespace kingMe
{
    using System.Collections.Generic;

    namespace kingMe
    {
        public class Jogador
        {
            public string Nome { get; private set; }
            public string Id { get; private set; }
            public string Senha { get; private set; }
            public List<Personagem> Influencias { get; private set; }
            public int Pontuacao { get; set; }

            public Jogador(string nome, string id, string senha)
            {
                Nome = nome;
                Id = id;
                Senha = senha;
                Influencias = new List<Personagem>();
                Pontuacao = 0;
            }

            public void AdicionarInfluencias(List<Personagem> influencias)
            {
                Influencias.AddRange(influencias);
            }
        }
    }

}
