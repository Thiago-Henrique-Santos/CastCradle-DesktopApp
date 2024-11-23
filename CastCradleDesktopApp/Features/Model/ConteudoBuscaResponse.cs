namespace CastCradleDesktopApp.Features.Model
{
    public class ConteudoBuscaResponse
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public int TotalVisualizacoes { get; set; }
        public int TotalCurtidas { get; set; }
        public required string Miniatura { get; set; }
    }
}