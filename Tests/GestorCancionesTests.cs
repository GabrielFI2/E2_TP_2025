using SistemaGestionMusica.Modelos;
using SistemaGestionMusica.Gestores;

namespace SistemaGestionMusica.Tests
{
    public class GestorCancionesTests
    {
        [Fact]
        public void AgregarCancion_DeberiaAgregarlaComoNuevaEntrada()
        {
            // Arrange
            var gestor = new GestorCanciones();
            gestor.AgregarCancion("Bohemian Rhapsody", "Queen", 554);
            int cantidadInicial = gestor.cancionesDisponibles.Count;
            var nuevaCancionConMismosDatos = new Cancion("Bohemian Rhapsody", "Queen", 554);

            // Act
            gestor.AgregarCancion("Bohemian Rhapsody", "Queen", 554);

            // Assert
            Assert.Equal(cantidadInicial + 1, gestor.cancionesDisponibles.Count);
            Assert.Contains(nuevaCancionConMismosDatos, gestor.cancionesDisponibles);
            Assert.Equal(2, gestor.cancionesDisponibles.Count(c => c.Nombre == "Existe cancion" && c.Artista == "Existe Artista" && c.DuracionSegundos == 554));
        }

        public void BuscarPorNombre_DeberiaRetornarListaVacia()
        {
            // Arrange
            var canciones = new List<Cancion>
            {
                new Cancion("Bohemian Rhapsody", "Queen", 355),
                new Cancion("Another One Bites the Dust", "Queen", 214)
            };
            string nombreBusqueda = "bohemian rhapsody";

            // Act
            var resultado = GestorCanciones.BuscarPorNombre(canciones, nombreBusqueda);

            // Assert
            Assert.NotNull(resultado.Item1);
            Assert.Equal("Bohemian Rhapsody", resultado.Item1.Nombre);
            Assert.Equal(0, resultado.Item2);

        }
        public void QuickSortDuracionSegundos__DeberiaOrdenarPorDuracionAscendente()
        {
            // Arrange
            var canciones = new List<Cancion>
            {
                new Cancion("Cancion A", "Artista 1", 180),
                new Cancion("Cancion B", "Artista 2", 240),
                new Cancion("Cancion C", "Artista 3", 120)
            };
            var cancionesOrdenadasEsperadas = canciones.OrderBy(c => c.DuracionSegundos).ToList();

            // Act
            GestorCanciones.QuickSortDuracionSegundos(canciones);

            // Assert
            Assert.Equal(cancionesOrdenadasEsperadas.Count, canciones.Count);
            for (int i = 0; i < canciones.Count; i++)
            {
                Assert.Equal(cancionesOrdenadasEsperadas[i].DuracionSegundos, canciones[i].DuracionSegundos);
            }
        }
    }
}