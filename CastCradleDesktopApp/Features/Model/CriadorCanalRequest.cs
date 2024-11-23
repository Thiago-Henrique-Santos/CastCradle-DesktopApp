namespace CastCradleDesktopApp.Features.Model
{
    public class CriadorCanalRequest
    {
        public string? Resposta { get; set; }
        public string? NomeCanal { get; set; }
        public string? Descricao { get; set; }
        public string? Pergunta { get; set; }
        public string? Senha { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public Stream? Avatar { get; set; }
        public Stream? Banner { get; set; }
    }
}