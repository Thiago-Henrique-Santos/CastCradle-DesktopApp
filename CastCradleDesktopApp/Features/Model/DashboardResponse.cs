namespace CastCradleDesktopApp.Features.Model
{
    public class Top5
    {
        public required string Titulo { get; set; }
        public required int Visualizacoes { get; set; }
    }

    public class DashboardResponse
    {
        public required string Status { get; set; }
        public required int Videos { get; set; }
        public required int Musicas { get; set; }
        public required int Podcast { get; set; }
        public required int Inscritos { get; set; }
        public required List<Top5> Top5 { get; set; }
    }
}