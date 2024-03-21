using System.Runtime.ConstrainedExecution;
using Tabuleiro;
using Tabuleiro.Enum;
using Xadrez.Infra.Const;
using Xadrez.Tabuleiro.Error;
using Xadrez.Xadrez.Componentes;

namespace Xadrez.Xadrez
{
    public class PartidaXadrez
    {
        public MesaTabuleiro Tabuleiro { get; private set; }
        private HashSet<Peca> _pecasXadrez;
        private HashSet<Peca> _pecasXadrezCapturadas;
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Xeque { get; private set; }
        public bool Terminada { get; private set; }

        public PartidaXadrez()
        {
            Tabuleiro = new MesaTabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            _pecasXadrez = new HashSet<Peca>();
            _pecasXadrezCapturadas = new HashSet<Peca>();
            IniciarTabuleiro();
        }

        public Posicao LerPosicao()
        {
            var posicao = Console.ReadLine();
            var coluna = posicao[0];
            var linha = int.Parse(posicao[1].ToString());

            var posicaoDaJogada = new PosicaoXadrez(coluna, linha).ParaPosicao();

            if (!Tabuleiro.IsPosicaoValida(posicaoDaJogada))
            {
                throw new TabuleiroException(ErrorMessage.PosicaoInvalida);
            }

            return posicaoDaJogada;
        }

        public void RealizarJogada(Posicao origem, Posicao destino)
        {
            ExecutarMovimento(origem, destino);

            Xeque = EstaEmXeque(GetCorOposta(JogadorAtual));

            TrocarJogador();

            Turno++;
        }

        private void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            var pecaMovida = Tabuleiro.TirarPeca(origem);
            pecaMovida.IncrementarMovimentos();

            var pecaCapturada = Tabuleiro.GetPeca(destino);
            if (pecaCapturada != null)
            {
                _pecasXadrezCapturadas.Add(pecaCapturada);
                pecaCapturada = Tabuleiro.TirarPeca(destino);
            }

            Tabuleiro.ColocarPeca(pecaMovida, destino);
        }

        public void ChecarOrigem(Posicao origem)
        {
            var peca = Tabuleiro.GetPeca(origem) ?? throw new TabuleiroException(ErrorMessage.SemPecaNaPosicao);

            if (JogadorAtual != peca.Cor)
            {
                throw new TabuleiroException(ErrorMessage.PecaInvalidaSelecionada);
            }

            if (!peca.TemPosicaoValida())
            {
                throw new TabuleiroException(ErrorMessage.SemJogadasPossíveis);
            }
        }

        public void ChecarDestino(Posicao origem, Posicao destino)
        {
            var peca = Tabuleiro.GetPeca(origem);

            if (!peca.PodeMoverPara(destino))
            {
                throw new TabuleiroException(ErrorMessage.MovimentoInvalido);
            }

            if (peca is Rei)
            {
                VerificarXequeProprio(peca, destino);
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            return _pecasXadrezCapturadas.Where(peca => peca.Cor == cor).ToHashSet();
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            var pecasDaCor = _pecasXadrez.Where(peca => peca.Cor == cor).ToHashSet();
            pecasDaCor.ExceptWith(PecasCapturadas(cor));

            return pecasDaCor;
        }

        private void TrocarJogador()
        {
            JogadorAtual = GetCorOposta(JogadorAtual);
        }

        private Cor GetCorOposta(Cor cor)
        {
            return cor == Cor.Branca ? Cor.Preta : Cor.Branca;
        }

        #region Xeque
        private Peca? GetRei(Cor cor)
        {
            foreach (var peca in PecasEmJogo(cor))
            {
                if (peca is Rei)
                {
                    return peca;
                }
            }

            return null;
        }

        private void VerificarXequeProprio(Peca rei, Posicao destino)
        {
            var backup = new Rei(rei.Cor, rei.Tabuleiro)
            {
                Posicao = destino
            };

            if (EstaEmXeque(backup))
                throw new TabuleiroException(ErrorMessage.XequeProprio);
        }

        private bool EstaEmXeque(Peca rei)
        {
            foreach (var peca in PecasEmJogo(GetCorOposta(rei.Cor)))
            {
                var jogadasPossiveis = peca.PosicoesValidas();

                if (jogadasPossiveis[rei.Posicao!.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }

            return false;
        }

        private bool EstaEmXeque(Cor cor)
        {
            var rei = GetRei(cor) ?? throw new TabuleiroException(ErrorMessage.ReiNaoEncontrado);

            foreach (var peca in PecasEmJogo(GetCorOposta(rei.Cor)))
            {
                var jogadasPossiveis = peca.PosicoesValidas();

                if (jogadasPossiveis[rei.Posicao!.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region Inicialização
        private void ColocarPecaXadrez(Peca peca, Posicao posicao)
        {
            Tabuleiro.ColocarPeca(peca, posicao);

            _pecasXadrez.Add(peca);
        }

        private void ColocarPecasEspeciais(Cor cor, Posicao posicao)
        {
            switch (posicao.Coluna)
            {
                case 0:
                    ColocarPecaXadrez(new Torre(cor, Tabuleiro), posicao);
                    break;
                case 1:
                    //ColocarPecaXadrez(new Cavalo(cor, Tabuleiro), posicao);
                    break;
                case 2:
                    //ColocarPecaXadrez(new Bispo(cor, Tabuleiro), posicao);
                    break;
                case 3:
                    ColocarPecaXadrez(new Rei(cor, Tabuleiro), posicao);
                    break;
                case 4:
                    //ColocarPecaXadrez(new Dama(cor, Tabuleiro), posicao);
                    break;
                case 5:
                    //ColocarPecaXadrez(new Bispo(cor, Tabuleiro), posicao);
                    break;
                case 6:
                    //ColocarPecaXadrez(new Cavalo(cor, Tabuleiro), posicao);
                    break;
                case 7:
                    ColocarPecaXadrez(new Torre(cor, Tabuleiro), posicao);
                    break;
            }
        }

        private void IniciarTabuleiro()
        {
            for (var l = 0; l < Tabuleiro.Linhas; l++)
            {
                for (var c = 0; c < Tabuleiro.Colunas; c++)
                {
                    if (l == 0) ColocarPecasEspeciais(Cor.Branca, new Posicao(l, c));

                    //if (l == 1) ColocarPecaXadrez(new Peao(Cor.Branca, Tabuleiro), new Posicao(l, c));

                    //if (l == 6) ColocarPecaXadrez(new Peao(Cor.Preta, Tabuleiro), new Posicao(l, c));

                    if (l == 7) ColocarPecasEspeciais(Cor.Preta, new Posicao(l, c));
                }
            }
        }
        #endregion
    }
}
