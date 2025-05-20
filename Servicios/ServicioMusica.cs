

using SistemaGestionMusica.Modelos;
using SistemaGestionMusica.Gestores;

namespace SistemaGestionMusica.Servicios
{
    public class ServicioMusica
    {
        public GestorCanciones Gestor { get; private set; }
        public List<Usuario> Usuarios { get; private set; }

        // Constructor
        public ServicioMusica(GestorCanciones gestor)
        {
            Gestor = gestor ?? throw new ArgumentNullException(nameof(gestor));
            Usuarios = new List<Usuario>();
        }

        // Método para registrar un nuevo usuario
        public void RegistrarUsuario(string nombre)
        {
            if (Usuarios.Any(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"Error: El usuario '{nombre}' ya está registrado.");
                return;
            }

            Usuario nuevoUsuario = new Usuario(nombre);
            Usuarios.Add(nuevoUsuario);
            Console.WriteLine($"Usuario '{nombre}' registrado exitosamente.");
        }

        // Método para buscar un usuario ignorando mayúsculas/minúsculas
        public Usuario BuscarUsuario(string nombre)
        {
            return Usuarios.FirstOrDefault(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
    }
}
