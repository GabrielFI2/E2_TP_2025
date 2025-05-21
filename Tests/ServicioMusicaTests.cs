using SistemaGestionMusica.Modelos;
using SistemaGestionMusica.Gestores;
using SistemaGestionMusica.Servicios;
using System.Numerics;

namespace SistemaGestionMusica.Tests
{
    public class ServicioMusicaTests
    {
        [Fact]
        public void RegistrarUsuario_DeberiaAgregarUsuarioALista()
        {
            // Arrange
            var gestorCanciones = new ServicioCatalogo.GestorCanciones();
            var servicio = new ServicioMusica(gestorCanciones);
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
            var gestorCanciones = new ServicioCatalogo.GestorCanciones();
            var servicio = new ServicioMusica(gestorCanciones);
            servicio.RegistrarUsuario("UsuarioPrueba");
            string nombreBusqueda = "UsuarioInexistente";

            // Act
            var usuarioEncontrado = servicio.BuscarUsuario(nombreBusqueda);

            // Assert
            Assert.Null(usuarioEncontrado);
        }




    }
}