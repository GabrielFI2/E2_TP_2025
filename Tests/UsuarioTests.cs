using SistemaGestionMusica.Modelos;
namespace SistemaGestionMusica.Tests
{
    public class UsuarioTests
    {
        [Fact]
        public void Constructor_AsignarMetodoCorrectamente()
        {
            //Arrange
            int duracion = 554;
            var cancion = new Cancion("Bohemian Rhapsody", "Queen", 554);
           

            //Act

            cancion.ToString();

            //Asert 
            Assert.Equal("Nombre esperado", cancion.Nombre);
            Assert.Equal("Artista esperado", cancion.Artista);
            Assert.Equal(duracion, cancion.DuracionSegundos);
            Assert.Equal("Bohemian Rhapsody,- Queen (5:54)", cancion.ToString());
        }
        

        
    }
}