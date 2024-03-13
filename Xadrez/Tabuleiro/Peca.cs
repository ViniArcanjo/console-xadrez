using Tabuleiro.Enum;

namespace Tabuleiro
{
    public abstract class Peca
    {
        public MesaTabuleiro Tabuleiro { get; protected set; }
        public Posicao? Posicao { get; set; } = null;
        public Cor Cor { get; set; }
        public int QtdMovimentos { get; protected set; } = 0;

        public Peca (Cor cor, MesaTabuleiro tabuleiro)
        {
            Cor = cor;
            Tabuleiro = tabuleiro;
        }

        public void IncrementarMovimentos()
        {
            QtdMovimentos++;
        }

        public abstract bool[,] PosicoesValidas();
    }
}
