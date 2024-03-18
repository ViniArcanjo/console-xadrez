using Tabuleiro;
using Tabuleiro.Enum;

namespace Xadrez.Xadrez.Componentes
{
    public class Rei : Peca
    {
        public Rei(Cor cor, MesaTabuleiro tabuleiro) : base(cor, tabuleiro) { }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao posicaoDestino)
        {
            var peca = Tabuleiro.GetPeca(posicaoDestino);

            return peca == null || peca.Cor != Cor;
        }

        public override bool[,] PosicoesValidas()
        {
            var resposta = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            var posicaoParaChecar = new Posicao(Posicao.Linha, Posicao.Coluna);

            // Norte
            posicaoParaChecar.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.IsPosicaoValida(posicaoParaChecar) && PodeMover(posicaoParaChecar))
            {
                resposta[posicaoParaChecar.Linha, posicaoParaChecar.Coluna] = true;
            }

            // Nordeste
            posicaoParaChecar.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.IsPosicaoValida(posicaoParaChecar) && PodeMover(posicaoParaChecar))
            {
                resposta[posicaoParaChecar.Linha, posicaoParaChecar.Coluna] = true;
            }

            // Leste
            posicaoParaChecar.MudarPosicao(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.IsPosicaoValida(posicaoParaChecar) && PodeMover(posicaoParaChecar))
            {
                resposta[posicaoParaChecar.Linha, posicaoParaChecar.Coluna] = true;
            }

            // Sudeste
            posicaoParaChecar.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.IsPosicaoValida(posicaoParaChecar) && PodeMover(posicaoParaChecar))
            {
                resposta[posicaoParaChecar.Linha, posicaoParaChecar.Coluna] = true;
            }

            // Sul
            posicaoParaChecar.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.IsPosicaoValida(posicaoParaChecar) && PodeMover(posicaoParaChecar))
            {
                resposta[posicaoParaChecar.Linha, posicaoParaChecar.Coluna] = true;
            }

            // Sudoeste
            posicaoParaChecar.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.IsPosicaoValida(posicaoParaChecar) && PodeMover(posicaoParaChecar))
            {
                resposta[posicaoParaChecar.Linha, posicaoParaChecar.Coluna] = true;
            }

            // Oeste
            posicaoParaChecar.MudarPosicao(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.IsPosicaoValida(posicaoParaChecar) && PodeMover(posicaoParaChecar))
            {
                resposta[posicaoParaChecar.Linha, posicaoParaChecar.Coluna] = true;
            }

            // Noroeste
            posicaoParaChecar.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.IsPosicaoValida(posicaoParaChecar) && PodeMover(posicaoParaChecar))
            {
                resposta[posicaoParaChecar.Linha, posicaoParaChecar.Coluna] = true;
            }

            return resposta;
        }
    }
}
