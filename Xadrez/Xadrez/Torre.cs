using Tabuleiro;
using Tabuleiro.Enum;

namespace Xadrez.Xadrez
{
    public class Torre : Peca
    {
        public Torre(Cor cor, MesaTabuleiro tabuleiro) : base(cor, tabuleiro) { }

        public override string ToString()
        {
            return "T";
        }
    }
}
