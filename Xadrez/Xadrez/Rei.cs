using Tabuleiro;
using Tabuleiro.Enum;

namespace Xadrez.Xadrez
{
    public class Rei : Peca
    {
        public Rei(Cor cor, MesaTabuleiro tabuleiro) : base(cor, tabuleiro) { }

        public override string ToString()
        {
            return "R";
        }
    }
}
