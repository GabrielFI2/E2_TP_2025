using SistemaGestionMusica.Modelos;
namespace SistemaGestionMusica.Tests 
{
    public class UsuarioTests
    {
        [Fact]
        public void CrearListaReproduccion_DeberiaCrearLista()
        {
            //Arrange

            var usuario = new Usuario("Favoritos");
            string nombreLista = "Favoritas";
            usuario.CrearListaReproduccion(nombreLista);
            var listaOriginal = usuario.ListasReproduccion[nombreLista];



            //Act

            usuario.CrearListaReproduccion(nombreLista);
            var listaDespuesDeCrearDeNuevo = usuario.ListasReproduccion[nombreLista];


            //Asert 
            Assert.True(usuario.ListasReproduccion.ContainsKey(nombreLista));
            Assert.Same(listaOriginal, listaDespuesDeCrearDeNuevo);
            Assert.Empty(usuario.ListasReproduccion[nombreLista]);

        }
        public void AgregarCancionALista_DebeAgregarCorrectamente()
        {
            // Arrange
            var cancion = new Cancion("Bohemian Rhapsody", "Queen", 554);
            var usuario = new Usuario("Favoritos");
            string nombreListaInexistente = "Lista Inexistente";
            var cancionAgregar = new Cancion("Bohemian Rhapsody", "Queen", 554);
            int cantidadListasInicial = usuario.ListasReproduccion.Count;

            // Act
            usuario.AgregarCancionALista(nombreListaInexistente, cancionAgregar);

            // Assert
            Assert.False(usuario.ListasReproduccion.ContainsKey(nombreListaInexistente));
            Assert.Single(usuario.ListasReproduccion["Favoritos"]);
            Assert.Equal(cancion, usuario.ListasReproduccion["Favoritos"][0]);
            Assert.Equal(cantidadListasInicial, usuario.ListasReproduccion.Count);
        }



    }
}