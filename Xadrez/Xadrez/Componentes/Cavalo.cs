using Tabuleiro;
using Tabuleiro.Enum;

namespace Xadrez.Xadrez.Componentes
{
    public class Cavalo : Peca
    {
        public Cavalo(Cor cor, MesaTabuleiro tabuleiro) : base(cor, tabuleiro) { }

        public override string ToString()
        {
            return "C";
        }

        public override bool[,] PosicoesValidas()
        {
            throw new NotImplementedException();
        }
    }
}
