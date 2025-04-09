using System.Drawing;

namespace kingMe
{
    public class Personagem
    {
        public string NomeCompleto { get; private set; }
        public char Letra { get; private set; }
        public int Setor { get; set; }
        public Image Sprite { get; private set; }

        public Personagem(string nomeCompleto, char letra, int setor, Image sprite)
        {
            NomeCompleto = nomeCompleto;
            Letra = letra;
            Setor = setor;
            Sprite = sprite;
        }
    }
}
