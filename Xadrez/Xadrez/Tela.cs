using Tabuleiro;
using Tabuleiro.Enum;

namespace Xadrez.Xadrez
{
    public class Tela
    {
        public static void ImprimirPartida(PartidaXadrez partida)
        {
            Console.Clear();
            ImprimirTabuleiro(partida.Tabuleiro);

            Console.WriteLine();

            Console.WriteLine($"Turno: {partida.Turno}");
            Console.WriteLine($"Jogador atual: {partida.JogadorAtual}");

            Console.WriteLine();

            ImprimirPecasCapturadas(partida);

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void ImprimirPartida(PartidaXadrez partida, bool[,] posicoesDeJogada)
        {
            Console.Clear();
            ImprimirTabuleiro(partida.Tabuleiro, posicoesDeJogada);

            Console.WriteLine();

            Console.WriteLine($"Turno: {partida.Turno}");
            Console.WriteLine($"Jogador atual: {partida.JogadorAtual}");

            Console.WriteLine();

            ImprimirPecasCapturadas(partida);

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void ImprimirTabuleiro(MesaTabuleiro tabuleiro)
        {
            for (int l = 0; l < tabuleiro.Linhas; l++)
            {
                Console.Write($"{8 - l} ");

                for (int c = 0; c < tabuleiro.Colunas; c++)
                {
                    var peca = tabuleiro.GetPeca(new Posicao(l, c));

                    ImprimirPeca(peca);
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(MesaTabuleiro tabuleiro, bool[,] posicoesDeJogada)
        {
            var backupConsoleColor = Console.BackgroundColor;

            for (int l = 0; l < tabuleiro.Linhas; l++)
            {
                Console.Write($"{8 - l} ");

                for (int c = 0; c < tabuleiro.Colunas; c++)
                {
                    if (posicoesDeJogada[l, c])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.BackgroundColor = backupConsoleColor;
                    }

                    var peca = tabuleiro.GetPeca(new Posicao(l, c));

                    ImprimirPeca(peca);
                    Console.BackgroundColor = backupConsoleColor;
                }

                Console.WriteLine();
            }

            Console.BackgroundColor = backupConsoleColor;
            Console.WriteLine("  a b c d e f g h");
        }

        private static void ImprimirPeca(Peca peca)
        {
            if (peca is null)
            {
                Console.Write("- ");
                return;
            }

            if (peca.Cor == Cor.Branca)
            {
                Console.Write($"{peca} ");
                return;
            }

            if (peca.Cor == Cor.Preta)
            {
                var backupConsoleColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write($"{peca} ");

                Console.ForegroundColor = backupConsoleColor;
            }
        }

        private static void ImprimirPecasCapturadas(PartidaXadrez partida)
        {
            var backupConsoleColor = Console.ForegroundColor;
            
            Console.WriteLine("Peças Capturadas:");

            Console.Write($"Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Pretas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = backupConsoleColor;
        }

        private static void ImprimirConjunto(HashSet<Peca> pecas)
        {
            Console.Write("[ ");

            foreach (var peca in pecas)
            {
                Console.Write($"{peca} ");
            };

            Console.Write("]");
        }
    }
}
