namespace Xadrez.Infra.Const
{
    public static class ErrorMessage
    {
        public static string PosicaoInvalida = "Ops! Parece que você tentou selecionar uma posição inválida.";

        public static string SemPecaNaPosicao = "Ops! Parece que você selecionou uma posição em que não há uma peça para iniciar a jogada.";
        public static string SemJogadasPossíveis = "Ops! Parece que você selecionou uma peça que não possui um movimento possível.";
        public static string PecaInvalidaSelecionada = "Ops! Parece que você selecionou uma peça que não é sua.";
        public static string MovimentoInvalido = "Ops! Parece que você selecionou uma posição de destino inválida.";
    }
}
