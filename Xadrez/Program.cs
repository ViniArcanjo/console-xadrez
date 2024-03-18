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
                    ImprimirFormatação(partida);

                    Console.Write("Origem: ");
                    var origem = partida.LerPosicao();
                    partida.ChecarJogadaDeOrigem(origem);

                    var posicoesDeJogada = partida.Tabuleiro.GetPeca(origem).PosicoesValidas();

                    ImprimirFormatação(partida, posicoesDeJogada);

                    Console.Write("Destino: ");
                    var destino = partida.LerPosicao();
                    partida.ChecarJogadaDeDestino(origem, destino);

                    partida.RealizarJogada(origem, destino);
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Pressione qualquer tecla para tentar novamente.");
                    Console.ReadLine();
                }
            }
        }

        private static void ImprimirFormatação(PartidaXadrez partida)
        {
            Console.Clear();
            Tela.ImprimirTabuleiro(partida.Tabuleiro);

            Console.WriteLine();

            Console.WriteLine($"Turno: {partida.Turno}");
            Console.WriteLine($"Jogador atual: {partida.JogadorAtual}");

            Console.WriteLine();
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