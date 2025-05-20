using SistemaGestionMusica.Modelos;
//using SistemaGestionMusica.Gestores;
using SistemaGestionMusica.Servicios;

namespace SistemaGestionMusica.Tests
{
    public class ServicioMusicaTests
    {
        [Fact]
        public void RegistrarUsuario_DeberiaAgregarUsuarioALista()
        {
            // Arrange
            var servicio = new ServicioMusica(GestorCanciones());
            string nombreUsuario = "NuevoUsuario";

            // Act
            servicio.RegistrarUsuario(nombreUsuario);

            // Assert
            Assert.Single(servicio.Usuarios);
            Assert.Contains(servicio.Usuarios, u => u.Nombre == nombreUsuario);
        }

        public void BuscarUsuario_UsuarioNoExistente_DeberiaRetornarNull()
        {
            // Arrange
            var servicio = new ServicioMusica();
            servicio.RegistrarUsuario("UsuarioPrueba");
            string nombreBusqueda = "UsuarioInexistente";

            // Act
            var usuarioEncontrado = servicio.BuscarUsuario(nombreBusqueda);

            // Assert
            Assert.Null(usuarioEncontrado);
        }




    }
}