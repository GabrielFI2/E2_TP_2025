
namespace SistemaGestionMusica.Modelos
{
    public class Cancion
    {
        public string Nombre { get; set; }
        public string Artista { get; set; }
        public int DuracionSegundos { get; set; }


        //Constructor

        public Cancion(string nombre, string artista, int duracionsegundos)
        {
            Nombre = nombre;
            Artista = artista;
            DuracionSegundos = duracionsegundos;
        }

        // To string 
        public override string ToString()
        {
            int minutos = DuracionSegundos / 60;
            int segundos = DuracionSegundos % 60;
            return $"{Nombre} - {Artista} ({minutos:D2}:{segundos:D2})";
        }

    }
}
