namespace CastCradleDesktopApp.Features.Model
{
    public class PlaylistOpcoes
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
    }

    public class PublicarResponse
    {
        public required List<string> TiposConteudo { get; set; }
        public required List<string> TiposMedia { get; set; }
        public required List<PlaylistOpcoes> Playlist { get; set; }
    }
}
