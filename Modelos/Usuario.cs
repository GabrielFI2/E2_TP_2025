
namespace SistemaGestionMusica.Modelos
{
    public class Usuario
    {

        public string Nombre { get; set; }
        public Dictionary<string, List<Cancion>> ListasReproduccion { get; set; }

        // Constructor
        public Usuario(string nombre)
        {
            Nombre = nombre;
            ListasReproduccion = new Dictionary<string, List<Cancion>>();
        }

        // Método para crear una nueva lista de reproducción
        public void CrearListaReproduccion(string nombreLista)
        {
            if (!ListasReproduccion.ContainsKey(nombreLista))
            {
                ListasReproduccion[nombreLista] = new List<Cancion>();
                Console.WriteLine($"Lista de reproducción '{nombreLista}' creada exitosamente.");
            }
            else
            {
                Console.WriteLine($"Error: La lista de reproducción '{nombreLista}' ya existe.");
            }
        }

        // Método para agregar una canción a una lista existente
        public void AgregarCancionALista(string nombreLista, Cancion cancion)
        {
            if (ListasReproduccion.ContainsKey(nombreLista))
            {
                ListasReproduccion[nombreLista].Add(cancion);
                Console.WriteLine($"Canción '{cancion.Nombre}' agregada a la lista '{nombreLista}'.");
            }
            else
            {
                Console.WriteLine($"Error: La lista de reproducción '{nombreLista}' no existe.");
            }
        }

        // Método para mostrar todas las listas de reproducción y sus canciones
        public void MostrarListasReproduccion()
        {
            if (ListasReproduccion.Count == 0)
            {
                Console.WriteLine("No hay listas de reproducción creadas.");
                return;
            }

            foreach (var lista in ListasReproduccion)
            {
                Console.WriteLine($"\nLista de reproducción: {lista.Key}");
                foreach (var cancion in lista.Value)
                {
                    Console.WriteLine($"  {cancion}");
                }
            }
        }
    }
}
