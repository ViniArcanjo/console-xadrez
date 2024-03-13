using Tabuleiro;
using Tabuleiro.Enum;

namespace Xadrez.Xadrez.Componentes
{
    public class Bispo : Peca
    {
        public Bispo(Cor cor, MesaTabuleiro tabuleiro) : base(cor, tabuleiro) { }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] PosicoesValidas()
        {
            throw new NotImplementedException();
        }
    }
}
