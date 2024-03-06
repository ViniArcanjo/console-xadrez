namespace Xadrez.Tabuleiro.Error
{
    public class TabuleiroException : Exception
    {
        public TabuleiroException(string mensagem): base(mensagem) { }
    }
}
