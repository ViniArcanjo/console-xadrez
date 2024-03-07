using Tabuleiro;
using Tabuleiro.Enum;

namespace Xadrez.Xadrez.Componentes
{
    public class Peao : Peca
    {
        public Peao(Cor cor, MesaTabuleiro tabuleiro) : base(cor, tabuleiro) { }

        public override string ToString()
        {
            return "P";
        }
    }
}
