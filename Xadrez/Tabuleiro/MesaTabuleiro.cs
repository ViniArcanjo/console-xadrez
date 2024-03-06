using Xadrez.Infra.Const;
using Xadrez.Tabuleiro.Error;

namespace Tabuleiro
{
    public class MesaTabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] _pecas;

        public MesaTabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            _pecas = new Peca[linhas, colunas];
        }

        public Peca GetPeca(Posicao posicao)
        {
            return _pecas[posicao.Linha, posicao.Coluna];
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            ValidarPosicao(posicao);

            _pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        #region Private
        private void ValidarPosicao(Posicao posicao)
        {
            if (!IsPosicaoValida(posicao))
            {
                throw new TabuleiroException(ErrorMessage.PosicaoInvalida);
            }

            if (GetPeca(posicao) != null)
            {
                throw new TabuleiroException(ErrorMessage.PosicaoOcupada);
            }
        }

        private bool IsPosicaoValida(Posicao posicao)
        {
            return posicao.Linha >= 0 && posicao.Linha < Linhas && posicao.Coluna >= 0 && posicao.Coluna < Colunas;
        }
        #endregion
    }
}
