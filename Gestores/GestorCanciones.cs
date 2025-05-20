
using SistemaGestionMusica.Modelos;

namespace SistemaGestionMusica.Gestores
{
    public class GestorCanciones
    {
        //varaible de la clase
        public List<Cancion> cancionesDisponibles;

        //constructor
        public GestorCanciones()
        {
            cancionesDisponibles = new List<Cancion>();
        }
        //Metodos

        public void AgregarCancion(string nombre, string artista, int duracionsegundos)
        {
            cancionesDisponibles.Add(new Cancion(nombre, artista, duracionsegundos));
        }

        public static (Cancion, int) BuscarPorNombre(List<Cancion> canciones, string nombre)
        {
            int i = 0;
            foreach (Cancion cancion in canciones)
            {
                i++;
                if (cancion.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    return (cancion, i);
                }
            }
            return (null, i);

        }
        public static void QuickSortDuracionSegundos(List<Cancion> canciones)
        {
            if (canciones.Count <= 1)
            {
                return;
            }

            Cancion piv = canciones[canciones.Count - 1];

            var menores = new List<Cancion>();
            var mayores = new List<Cancion>();

            for (int i = 0; i < canciones.Count - 1; i++)
            {
                if (canciones[i].DuracionSegundos < piv.DuracionSegundos)
                {
                    menores.Add(canciones[i]);
                }
                else
                {
                    mayores.Add(canciones[i]);
                }
            }
            QuickSortDuracionSegundos(menores);
            QuickSortDuracionSegundos(mayores);

            canciones.Clear();
            canciones.AddRange(menores);
            canciones.Add(piv);

        }
        public void MostrarCancionesDisponibles()
        {
            Console.WriteLine("Canciones:");

            foreach (var cancion in cancionesDisponibles)
            {
                Console.WriteLine(cancion);
            }

        }
    }
}
