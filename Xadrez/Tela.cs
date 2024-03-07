using Tabuleiro;
using Tabuleiro.Enum;

namespace Xadrez
{
    public class Tela
    {
        public static void ImprimirTabuleiro(MesaTabuleiro tabuleiro)
        {
            for (int l = 0; l < tabuleiro.Linhas;  l++)
            {
                Console.Write($"{8 - l} ");

                for (int c = 0; c < tabuleiro.Colunas; c++)
                {
                    var peca = tabuleiro.GetPeca(new Posicao(l, c));

                    ImprimirPeca(peca);
                }

                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H");
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
    }
}
