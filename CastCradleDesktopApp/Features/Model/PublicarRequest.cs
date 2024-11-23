namespace CastCradleDesktopApp.Features.Model
{
    public class PublicarRequest
    {
        public int? Id { get; set; }
        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public required string Pergunta { get; set; }
        public required string TipoMedia { get; set; }
        public required string TipoConteudo { get; set; }
        public Stream? Arquivo { get; set; }
        public Stream? Miniatura { get; set; }
    }
}