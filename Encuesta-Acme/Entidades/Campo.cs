namespace Encuesta_Acme.Entidades
{
    public class Campo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public bool Requerido { get; set; }
        public TipoCampo TipoCampo { get; set; }
        public Encuesta Encuesta { get; set; }
        public int EncuestaId { get; set; }
    }
}
