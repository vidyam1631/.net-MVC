namespace MVC_APIFirstDemo.Models
{
    public class MVC_Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

    }
}
