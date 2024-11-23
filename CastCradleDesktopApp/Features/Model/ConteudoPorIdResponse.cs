namespace CastCradleDesktopApp.Features.Model
{
    public class ConteudoPorIdResponse
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public required string Miniatura { get; set; }
        public required string TipoConteudo { get; set; }
        public required List<PlaylistOpcoes> Playlists { get; set; }
    }
}