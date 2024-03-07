using Tabuleiro;
using Tabuleiro.Enum;
using Xadrez.Tabuleiro.Error;
using Xadrez.Xadrez;

namespace Xadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var partida = new PartidaXadrez();

                Tela.ImprimirTabuleiro(partida.Tabuleiro);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}