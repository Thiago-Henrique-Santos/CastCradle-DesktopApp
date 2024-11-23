namespace CastCradleDesktopApp.Features.Model
{
    public class ConteudoSalvarRequest
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public required string TipoConteudo { get; set; }
    }
}