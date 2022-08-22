namespace ProyectoUdemy.Entidades
{
    public class PeliculasActores
    {
        /*Tbla de relacion de peliculas y actores*/
        public int ActoresId { get; set; }
        public int PeliculaId { get; init; }
        public int Orden { get; set; }
        public string Personaje { get; set; }
        public Actor Actor{ get; set; }
        public Pelicula Pelicula {get; set;}
        
        
        
        
    }
}