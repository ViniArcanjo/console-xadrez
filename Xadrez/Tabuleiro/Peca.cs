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

        public abstract bool[,] PosicoesValidas();

        public void IncrementarMovimentos()
        {
            QtdMovimentos++;
        }

        public bool TemPosicaoValida()
        {
            var posicoesValidas = PosicoesValidas();

            for (var l = 0; l < posicoesValidas.GetLength(0); l++)
            {
                for (var c = 0; c < posicoesValidas.GetLength(1); c++)
                {
                    if (posicoesValidas[l, c])
                        return true;
                }
            }

            return false;
        }

        public bool PodeMoverPara(Posicao posicao)
        {
            return PosicoesValidas()[posicao.Linha, posicao.Coluna];
        }
    }
}
