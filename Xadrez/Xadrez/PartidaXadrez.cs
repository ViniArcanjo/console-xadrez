using Tabuleiro;
using Tabuleiro.Enum;
using Xadrez.Xadrez.Componentes;

namespace Xadrez.Xadrez
{
    public class PartidaXadrez
    {
        public MesaTabuleiro Tabuleiro { get; private set; }
        private int _turno;
        private Cor _jogadorAtual;
        public bool Terminada { get; private set; }

        public PartidaXadrez()
        {
            Tabuleiro = new MesaTabuleiro(8, 8);
            _turno = 1;
            _jogadorAtual = Cor.Branca;
            Terminada = false;
            IniciarTabuleiro();
        }

        public Posicao LerPosicao()
        {
            var posicao = Console.ReadLine();
            var coluna = posicao[0];
            var linha = int.Parse(posicao[1].ToString());

            var resposta = new PosicaoXadrez(coluna, linha).ParaPosicao();
            Tabuleiro.ValidarAto(resposta);

            return resposta;
        }

        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            var pecaMovida = Tabuleiro.TirarPeca(origem);
            pecaMovida.IncrementarMovimentos();

            var pecaCapturada = Tabuleiro.GetPeca(destino);
            if (pecaCapturada != null)
            {
                pecaCapturada = Tabuleiro.TirarPeca(destino);
            }

            Tabuleiro.ColocarPeca(pecaMovida, destino);
        }

        #region Inicialização
        private void IniciarTabuleiro()
        {
            for (var l = 0; l < Tabuleiro.Linhas; l++)
            {
                for (var c = 0; c < Tabuleiro.Colunas; c++)
                {
                    if (l == 0) ColocarPecasEspeciais(Cor.Branca, new Posicao(l, c));
                    
                    if (l == 1) Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new Posicao(l, c));

                    if (l == 6) Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new Posicao(l, c));

                    if (l == 7) ColocarPecasEspeciais(Cor.Preta, new Posicao(l, c));
                }
            }
        }

        private void ColocarPecasEspeciais(Cor cor, Posicao posicao)
        {
            switch (posicao.Coluna)
            {
                case 0:
                    Tabuleiro.ColocarPeca(new Torre(cor, Tabuleiro), posicao);
                    break;
                case 1:
                    Tabuleiro.ColocarPeca(new Cavalo(cor, Tabuleiro), posicao);
                    break;
                case 2:
                    Tabuleiro.ColocarPeca(new Bispo(cor, Tabuleiro), posicao);
                    break;
                case 3:
                    Tabuleiro.ColocarPeca(new Rei(cor, Tabuleiro), posicao);
                    break;
                case 4:
                    Tabuleiro.ColocarPeca(new Dama(cor, Tabuleiro), posicao);
                    break;
                case 5:
                    Tabuleiro.ColocarPeca(new Bispo(cor, Tabuleiro), posicao);
                    break;
                case 6:
                    Tabuleiro.ColocarPeca(new Cavalo(cor, Tabuleiro), posicao);
                    break;
                case 7:
                    Tabuleiro.ColocarPeca(new Torre(cor, Tabuleiro), posicao);
                    break;
            }
        }
        #endregion
    }
}
