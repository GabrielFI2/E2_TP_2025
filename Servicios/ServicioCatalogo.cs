
using SistemaGestionMusica.Modelos;

namespace SistemaGestionMusica.Servicios
{
    public class ServicioCatalogo
    {
        public class GestorCanciones
        {
            public List<Cancion> Catalogo { get; private set; }

            public GestorCanciones()
            {
                Catalogo = new List<Cancion>();
            }

            public void AgregarCancion(Cancion cancion)
            {
                Catalogo.Add(cancion);
                Console.WriteLine($"Canción '{cancion.Nombre}' agregada al catálogo.");
            }
        }
    }
}
