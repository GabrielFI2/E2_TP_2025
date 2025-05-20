
using SistemaGestionMusica.Modelos;
using SistemaGestionMusica.Gestores;
using SistemaGestionMusica.Servicios;
public class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenido al sistema de Música Simple");

        GestorCanciones gestor = new GestorCanciones();
        ServicioMusica servicioMusica = new ServicioMusica(gestor);

        // Agregar canciones de ejemplo
        gestor.AgregarCancion("¿Cómo Asi?", "Kali Uchis", 169);
        gestor.AgregarCancion("Digital Bath", "Deftones", 255);
        gestor.AgregarCancion("Makes Me Wonder", "Concorde", 197);
        gestor.AgregarCancion("Blue Velvet", "Lana del Rey", 169);
        gestor.AgregarCancion("Lo Siento BB :/", "Tainy", 206);
        gestor.AgregarCancion("Still Cold", "Mazzy Star", 288);
        gestor.AgregarCancion("Zombie Boy", "Lady Gaga", 213);
        gestor.AgregarCancion("Dare", "Gorillaz", 239);

        // Registro de usuario
        Console.Write("\nIngrese su nombre de usuario: ");
        string nombreUsuario = Console.ReadLine() ?? "";
        servicioMusica.RegistrarUsuario(nombreUsuario);

        Usuario usuario = new Usuario(nombreUsuario);

        // Creación de la primera lista de reproducción
        Console.Write("\nIngrese un nombre para su primera lista de reproducción: ");
        string nombreLista = Console.ReadLine() ?? "";
        usuario.CrearListaReproduccion(nombreLista);

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\n--- MENU PRINCIPAL ---");
            Console.WriteLine("1. Buscar canción y añadirla a una lista de reproducción.");
            Console.WriteLine("2. Ordenar lista por duración y mostrar duración total.");
            Console.WriteLine("3. Mostrar canciones disponibles.");
            Console.WriteLine("4. Crear nueva lista de reproducción.");
            Console.WriteLine("5. Mostrar todas las listas de reproducción.");
            Console.WriteLine("0. Salir.");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    Console.Write("\nIngrese el nombre de la canción a buscar: ");
                    string nombreCancionBuscar = Console.ReadLine() ?? "";
                    var (cancionEncontrada, indice) = GestorCanciones.BuscarPorNombre(gestor.cancionesDisponibles, nombreCancionBuscar);

                    if (cancionEncontrada != null)
                    {
                        Console.WriteLine($"Canción encontrada: {cancionEncontrada} (posición {indice})");

                        // Mostrar listas disponibles
                        Console.WriteLine("\nListas de reproducción disponibles:");
                        foreach (var lista in usuario.ListasReproduccion.Keys)
                        {
                            Console.WriteLine($"- {lista}");
                        }

                        // Pedir al usuario que seleccione una lista
                        Console.Write("\nIngrese el nombre de la lista donde desea añadir la canción: ");
                        string listaSeleccionada = Console.ReadLine() ?? "";

                        if (usuario.ListasReproduccion.ContainsKey(listaSeleccionada))
                        {
                            usuario.AgregarCancionALista(listaSeleccionada, cancionEncontrada);

                        }
                        else
                        {
                            Console.WriteLine("Error: La lista seleccionada no existe.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Canción no encontrada.");
                    }
                    break;
                case "2":
                    if (usuario.ListasReproduccion.ContainsKey(nombreLista))
                    {
                        GestorCanciones.QuickSortDuracionSegundos(usuario.ListasReproduccion[nombreLista]);
                        Console.WriteLine($"\nLista '{nombreLista}' ordenada por duración (de mayor a menor):");

                        foreach (var cancion in usuario.ListasReproduccion[nombreLista])
                        {
                            Console.WriteLine(cancion.ToString()); // Se usa ToString() para una presentación clara
                        }
                    }
                    else
                    {
                        Console.WriteLine("La lista no existe.");
                    }
                    break;

                case "3":
                    Console.WriteLine("\n--- Canciones Disponibles ---");
                    foreach (var cancion in gestor.cancionesDisponibles)
                    {
                        Console.WriteLine(cancion);
                    }
                    break;
                case "4":
                    Console.Write("Ingrese el nombre de la nueva lista: ");
                    string nuevaLista = Console.ReadLine() ?? "";
                    usuario.CrearListaReproduccion(nuevaLista);
                    break;

                case "5":
                    usuario.MostrarListasReproduccion();
                    break;

                case "0":
                    continuar = false;
                    Console.WriteLine("¡Gracias por usar Música Simple!");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

}