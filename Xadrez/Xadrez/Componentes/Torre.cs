using Tabuleiro;
using Tabuleiro.Enum;

namespace Xadrez.Xadrez.Componentes
{
    public class Torre : Peca
    {
        public Torre(Cor cor, MesaTabuleiro tabuleiro) : base(cor, tabuleiro) { }

        public override string ToString()
        {
            return "T";
        }

        private bool PodeMover(Posicao posicaoDestino)
        {
            var peca = Tabuleiro.GetPeca(posicaoDestino);

            return peca == null || peca.Cor != Cor;
        }

        public override bool[,] PosicoesValidas()
        {
            var resposta = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            var posicaoParaChecar = new Posicao(0, 0);

            // Norte
            posicaoParaChecar.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.IsPosicaoValida(posicaoParaChecar) && PodeMover(posicaoParaChecar))
            {
                resposta[posicaoParaChecar.Linha, posicaoParaChecar.Coluna] = true;

                var pecaAdversaria = Tabuleiro.GetPeca(posicaoParaChecar);

                if (pecaAdversaria != null && pecaAdversaria.Cor != Cor)
                    break;

                posicaoParaChecar.Linha--;
            }

            // Sul
            posicaoParaChecar.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.IsPosicaoValida(posicaoParaChecar) && PodeMover(posicaoParaChecar))
            {
                resposta[posicaoParaChecar.Linha, posicaoParaChecar.Coluna] = true;

                var pecaAdversaria = Tabuleiro.GetPeca(posicaoParaChecar);

                if (pecaAdversaria != null && pecaAdversaria.Cor != Cor)
                    break;

                posicaoParaChecar.Linha++;
            }

            // Leste
            posicaoParaChecar.MudarPosicao(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.IsPosicaoValida(posicaoParaChecar) && PodeMover(posicaoParaChecar))
            {
                resposta[posicaoParaChecar.Linha, posicaoParaChecar.Coluna] = true;

                var pecaAdversaria = Tabuleiro.GetPeca(posicaoParaChecar);

                if (pecaAdversaria != null && pecaAdversaria.Cor != Cor)
                    break;

                posicaoParaChecar.Coluna++;
            }

            // Oeste
            posicaoParaChecar.MudarPosicao(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.IsPosicaoValida(posicaoParaChecar) && PodeMover(posicaoParaChecar))
            {
                resposta[posicaoParaChecar.Linha, posicaoParaChecar.Coluna] = true;

                var pecaAdversaria = Tabuleiro.GetPeca(posicaoParaChecar);

                if (pecaAdversaria != null && pecaAdversaria.Cor != Cor)
                    break;

                posicaoParaChecar.Coluna--;
            }

            return resposta;
        }
    }
}
