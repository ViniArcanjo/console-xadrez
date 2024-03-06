using Tabuleiro;

namespace Xadrez
{
    public class Tela
    {
        public static void ImprimirTabuleiro(MesaTabuleiro tabuleiro)
        {
            for (int l = 0; l < tabuleiro.Linhas;  l++)
            {
                for (int c = 0; c < tabuleiro.Colunas; c++)
                {
                    var peca = tabuleiro.GetPeca(new Posicao(l, c));

                    if (peca is null)
                    {
                        Console.Write(" - ");
                    }
                    else
                    {
                        Console.Write($" {peca} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
