using Tabuleiro;

namespace Xadrez.Xadrez
{
    public class PosicaoXadrez
    {
        public int Linha { get; set; }
        public char Coluna { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Linha = linha;
            Coluna = Char.ToLower(coluna);
        }

        public Posicao ParaPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return $"{Coluna.ToString().ToUpperInvariant()}{Linha}";
        }
    }
}
