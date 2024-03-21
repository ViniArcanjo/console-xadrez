using Xadrez.Tabuleiro.Error;
using Xadrez.Xadrez;

namespace Xadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var partida = new PartidaXadrez();

            while (!partida.Terminada)
            {
                try
                {
                    Tela.ImprimirPartida(partida);

                    Console.Write("Origem: ");
                    var origem = partida.LerPosicao();
                    partida.ChecarOrigem(origem);

                    var posicoesDeJogada = partida.Tabuleiro.GetPeca(origem).PosicoesValidas();

                    Tela.ImprimirPartida(partida, posicoesDeJogada);
                    
                    Console.Write("Destino: ");
                    var destino = partida.LerPosicao();
                    partida.ChecarDestino(origem, destino);

                    partida.RealizarJogada(origem, destino);
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Pressione ENTER para tentar novamente.");
                    Console.ReadLine();
                }
            }
        }

        private static void ImprimirFormatação(PartidaXadrez partida, bool[,] posicoesDeJogada)
        {
            Console.Clear();
            Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesDeJogada);

            Console.WriteLine();

            Console.WriteLine($"Turno: {partida.Turno}");
            Console.WriteLine($"Jogador atual: {partida.JogadorAtual}");

            Console.WriteLine();
        }
    }
}