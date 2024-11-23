namespace CastCradleDesktopApp.Features.Model
{
    public class CriadorCadastroRequest
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required string Pergunta { get; set; }
        public required string Resposta { get; set; }
    }
}